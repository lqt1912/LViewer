using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace LViewer_Client
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }
        const int MAX_BUFFER_SIZE = 255;
        const int PORT_NUMBER = 9998;
        TcpClient client;
        public string Username;
        byte[] readBuffer = new byte[MAX_BUFFER_SIZE];
        string myString = "noname";
        private int p, q, n, e, d, phi_n;

        //Khi MainForm load, trình biên dịch sẽ tạo một Form Login mới yêu cầu kết nối tới sever và đăng nhập.
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Form_Login myfrmLogin = new Form_Login();
            try
            {
                //Tạo client mới. 
                //client = new TcpClient("127.0.0.1", PORT_NUMBER);
                //client = new TcpClient(IPAddress.Any.ToString(), PORT_NUMBER);
                client = new TcpClient("192.168.0.1", PORT_NUMBER);
                //Sử dụng Async và Invoking để đọc nhằm tránh lag. 
                client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(DoRead), null);

                //Chắc chắn form đã mở.
                this.Show();
                AttemptLogin();
                textBox_Status.ReadOnly = true;
            }
            catch
            {
                MessageBox.Show("Unable to connect to sever. Login again", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        }

        //Callback Tcpclient.getstream()
        private void DoRead(IAsyncResult iar)
        {
            int BytesRead;
            string strMes;

            try
            {
                //Kết thúc Async, trả về số Bytes đã đọc (read) trong BytesRead
                BytesRead = client.GetStream().EndRead(iar);
                if (BytesRead < 1)
                {
                    //nếu không có byte nào được đọc, đóng cửa sổ
                    MarkAsDisconnected(); //Đánh dấu ngắt kết nối.
                    return;
                }
                //chuyển định dạng
                strMes = Encoding.UTF8.GetString(readBuffer, 0, BytesRead - 2);
                ProcessCommandsSignal(strMes);
                //Khởi động tiến trình mới 
                client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(DoRead), null);

            }
            catch
            {
                MarkAsDisconnected();
            }
        }

        //Khi sever bị ngắt kết nối, ngăn chặn các tin nhắn được gửi đến và đi. 
        private void MarkAsDisconnected()
        {
            CheckForIllegalCrossThreadCalls = false;
            textBox_Input.ReadOnly = true;  //thuộc tính Readonly cấm nhập vào.
            button_Send.Enabled = false;    //Thuộc tính ẩn đi button.
        }

        //hiển thị text ra màn hình.
        private void DisplayText(string texttodisplay)
        {
            textBox_Status.AppendText(texttodisplay);
        }

        //Gửi dử liệu  
        private void SendData(string data)
        {
            StreamWriter streamWriter = new StreamWriter(client.GetStream());
           
            streamWriter.Write(data + (char)13);
            streamWriter.Flush();
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (textBox_Input.Text != "")
            {
                byte[] readString = Encoding.UTF8.GetBytes(textBox_Input.Text);
         
                DisplayText(Username + ":" + textBox_Input.Text + (char)13 + (char)10);
                // SendData("CHAT|" + Ecrypt(textBox_Input.Text) );

                SendData("CHAT|" + (textBox_Input.Text) );
               // SendData("CHAT|" + readString.ToString());
                textBox_Input.Text = string.Empty;
            }
        }

        private void ProcessCommandsSignal(string signal)
        {
            string[] dataArray;
            dataArray = signal.Split('|');
            switch (dataArray[0])
            {
                case "JOIN":
                    // Server acknowledged login.
                    DisplayText("Bạn đã đăng nhập thành công. Hãy sẵn sàng cho những cuộc trò chuyện chứ?" + (char)13 + (char)10);
                    break;
                case "CHAT":
                    // Received chat message, display it.
                    if (dataArray[1].Substring(0, 10) == "Waiting...")
                        DisplayText(dataArray[1] + (char)13 + (char)10);
                    else
                    {
                        string data = dataArray[1];
                        string subStringYes = data.Substring(data.Length - Username.Length, Username.Length);
                        string subStringNo = data.Substring(data.Length - "noname".Length, "noname".Length);
                        if (subStringYes == Username)
                            DisplayText(getString(data.Substring(0, data.Length - Username.Length)) + (char)13 + (char)10);
                        else if (subStringNo == "noname")
                            DisplayText(getString(data.Substring(0, data.Length - "noname".Length)) + (char)13 + (char)10);
                    }
                    break;
                case "REFUSE":
                    // Server refused login with this user name, try to log in with another.
                    AttemptLogin();
                    break;
                case "LISTUSERS":
                    // Server sent a list of users.
                    ListUsers(dataArray);
                    break;
                case "BROAD":
                    // Server sent a broadcast message
                    DisplayText("Máy chủ: " + dataArray[1] + (char)13 + (char)10);
                    break;
            }
        }
        //Region bên dưới sử dụng RSA mã hóa dữ liệu

        #region Su_dung_RSA_de_ma_hoa_du_lieu
        private string getString(string str)
        {
            int bre = 0;
            string s1 = null;
            string s2 = null;
            string s = null;
            char[] getChar = new char[str.Length];
            getChar = str.ToCharArray();
            for (int i = 0; i < str.Length; i++)
            {
                if (getChar[i] == ':')
                {
                    bre = i + 1;
                    break;
                }
            }
            for (int k = 0; k < bre; k++)
            {
                s1 += getChar[k].ToString();
            }
            for (int j = bre; j < str.Length; j++)
            {
                s2 += getChar[j].ToString();
            }
            s2 = Decipher(s2);
            s = s1 + " " + s2;
            return s;
        }

        //Hàm Decipher copy trên mạng 
        private string Decipher(string str)
        {
            //str = getString(str);
            string rtbChuoiKiTu = str.Trim() + " ";
            int chieuDaiChuoi = rtbChuoiKiTu.Length;
            char[] rtbMangKiTu;
            rtbMangKiTu = new char[chieuDaiChuoi];
            int[] rtbMangSo;
            rtbMangSo = new int[chieuDaiChuoi];
            rtbMangKiTu = rtbChuoiKiTu.ToCharArray();
            string s = "";
            int count = 0;
            int i = 0;
            for (i = 0; i < chieuDaiChuoi; i++)
            {
                if (rtbMangKiTu[i] != ' ')
                {
                    s += rtbMangKiTu[i];
                }
                else
                {
                    rtbMangSo[count] = int.Parse(s);
                    count++;
                    s = "";
                }
            }
            char[] rtbMang;
            rtbMang = new char[chieuDaiChuoi];
            int dd = rtbMangSo[0];
            int ee = rtbMangSo[1];
            int nn = rtbMangSo[2];
            for (i = 3; i < count; i++)
            {
                rtbMangSo[i] = (rtbMangSo[i] ^ dd) % nn;
                rtbMangSo[i] = (rtbMangSo[i] ^ ee) % nn;
                rtbMangSo[i] = (rtbMangSo[i] ^ dd) % nn;
                rtbMang[i] = (char)rtbMangSo[i];
                s += rtbMang[i];
            }
            return s;
        }

        private string Ecrypt(string str)
        {
            taoKhoa();
            int len = str.Length;
            char[] mangKiTu = new char[len];
            mangKiTu = str.ToCharArray();
            int[] mangAscii = new int[len];
            for (int i = 0; i < len; i++)
                mangAscii[i] = (int)mangKiTu[i];
            for (int i = 0; i < len; i++)

                mangAscii[i] = (mangAscii[i] ^ e) % n;			//Mã hóa từng kí tự trong chuỗi

            string str1 = "";					// Gán vào một chuỗi số khác
            for (int i = 0; i < len; i++)
                str1 += (mangAscii[i] + " ");
            return d.ToString() + " " + e.ToString() + " " + n.ToString() + " " + str1;
        }

        private void taoKhoa()
        {
            //Tạo hai số nguyên tố ngẫu nhine6 khác nhau
            do
            {
                p = soNgauNhien();
                q = soNgauNhien();
            }
            while (p == q || !kiemTraNguyenTo(p) || !kiemTraNguyenTo(q));

            //Tinh n=p*q
            n = p * q;

            //Tính Phi(n)=(p-1)*(q-1)
            phi_n = (p - 1) * (q - 1);

            //Tính e là một số ngẫu nhiên có giá trị 0< e <phi(n) và là số nguyên tố cùng nhau với Phi(n)
            do
            {
                Random rd = new Random();
                e = rd.Next(2, phi_n);
            }
            while (!nguyenToCungNhau(e, phi_n));

            //Tính d
            d = 0;
            int i = 2;
            while (((1 + i * phi_n) % e) != 0 || d <= 0)
            {
                i++;
                d = (1 + i * phi_n) / e;
            }
        }

        private void button_UpdateList_Click(object sender, EventArgs e)
        {
            listBox_Online.Items.Clear();
            SendData("REQUESTUSERS");
        }

        private void button_PublicChat_Click(object sender, EventArgs e)
        {
            myString = "noname";

        }

        private void textBox_Status_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox_Online_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Hàm tạo số ngẫu nhiên từ 2->10000
        private int soNgauNhien()
        {
            Random rd = new Random();
            return rd.Next(11, 101);
        }

        //Hàm kiểm tra nguyên tố
        private bool kiemTraNguyenTo(int i)
        {
            bool kiemtra = true;
            for (int j = 2; j < i; j++)
                if (i % j == 0)
                    kiemtra = false;
            return kiemtra;
        }

        //Hàm kiểm tra hai số nguyên tố cùng nhau
        private bool nguyenToCungNhau(int a, int b)
        {
            bool kiemtra = true;
            for (int i = 2; i < a; i++)
                if (a % i == 0 && b % i == 0)
                    kiemtra = false;
            return kiemtra;
        }
        #endregion

        //Add các user online vào listBox_Online
        private void ListUsers(string[] listOfUser)

        {

            for (int i = 0; i < listOfUser.Length - 1; i++)
            {
                listBox_Online.Items.Add(listOfUser[i]);
            }
        }

        //Xử lý đăng nhập
        public void AttemptLogin()
        {
            Form_Login myfrmLogin = new Form_Login();
            myfrmLogin.StartPosition = FormStartPosition.CenterParent;
            myfrmLogin.ShowDialog(this);
            SendData("CONNECT|" + myfrmLogin.textBox_Input.Text);
          
            Username = myfrmLogin.textBox_Input.Text;
            label_Username.Text = Username;

            myfrmLogin.Dispose();
           
        }
    }
}
