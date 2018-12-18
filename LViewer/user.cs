using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LViewer
{
   public delegate void dlgData_receive(user user, string data);
   public  class user
    {
        const int max_buffer_size = 255;
        TcpClient client;
        Byte[] readBuffer = new byte[max_buffer_size];
        string user_name;

        public user( TcpClient client)
        {
            this.client = client;
            this.client.GetStream().BeginRead(readBuffer, 0, max_buffer_size, new AsyncCallback(stream_receiver), null);
        }

        public string username { get => user_name; set => user_name = value; }

        public void data_sender (string Data)
        {
            lock(client.GetStream())
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.Write(Data + (char)13 + (char)10);
                writer.Flush();
             }
        }

        private void stream_receiver(IAsyncResult iar)
        {
            int BytesRead;
            string strMessage;
            try
            {
                lock (client.GetStream())
                {
                    BytesRead = client.GetStream().EndRead(iar);
                }

                strMessage = Encoding.UTF8.GetString(readBuffer, 0, BytesRead - 1);
                evData_received(this, strMessage);

                lock (client.GetStream())
                {
                    client.GetStream().BeginRead(readBuffer, 0, max_buffer_size, new AsyncCallback(stream_receiver), null);
                }
            }
            catch(Exception exp)
            {

            }
        }

        public event dlgData_receive evData_received;
    }
}
