using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

//UserConnection là class nhằm gom các tính năng (function) của một TcpClient tạo thành một user.
namespace LViewer
{
    //delegate để tạo event nhận data
    public delegate void dlgReceiveMess(UserConnection user, string data);
    public class UserConnection
    {
        const int MAX_BUFFER_SIZE = 255; //Giá trị lớn nhất của một  Buffer.
        TcpClient client;
        byte[] readBuffer = new byte[MAX_BUFFER_SIZE];
        string username;

        //Định tên của UserConnection .
        public string Username { get => username; set => username = value; }

        //event Nhận data.
        public event dlgReceiveMess ReiceivedMess;

        //Sử dụng StreamWriter để gửi tin nhắn tới user khác.
        public void SendData(string strData)
        {
            //Khóa Thread ngăn luồng khác can thiệp vào.
            lock (client.GetStream())
            {
                StreamWriter streamwriter = new StreamWriter(client.GetStream()); 
 
                streamwriter.Write(strData + (char)13 + (char)10);
                //Chắc chắn dử liệu đã gửi khi nhận xong.
                streamwriter.Flush();
            }
        }

        //Callback TcpClient.GetStream (Bắt đầu một Asynchronous mới).
        private void StreamReiceiver(IAsyncResult iar)
        {
            int BytesRead;
            string strMessage;

            try
            {
                //Khóa Thread
                lock (client.GetStream())
                {
                    //Kết thúc quá trình đọc.
                    BytesRead = client.GetStream().EndRead(iar);
                }
                //Encode thành mảng Byte.
                strMessage = Encoding.UTF8.GetString(readBuffer, 0, BytesRead - 1);
                ReiceivedMess(this, strMessage);
                lock (client.GetStream())
                {
                    //Đọc cái khác.
                    client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(StreamReiceiver), null);
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        //Khởi tạo user connection với 1 client có sẵn
        public UserConnection(TcpClient client) 
        {
            this.client = client;
            this.client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(StreamReiceiver), null);
        }
    }
}
