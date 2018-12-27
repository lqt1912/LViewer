using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading;

namespace LViewer
{
    public partial class Form_Main : Form
    {
        const int PORT_NUMBER = 9998;   //Port kết nối TCP.
        Hashtable hshClients = new Hashtable(); //HashTable hiển thị danh sách user.
        TcpListener listener;
        Thread listenerthread;
        string hostName;
        public Form_Main()
        {
            InitializeComponent();
           
        }

        //
        //cập nhật tin nhắnra màn hình
        //

        void update_content_board(string statusMessage)
        {
       
                listBox_Status.Items.Add(statusMessage);
        }
        //
        // cập nhật log
        //
        void update_content_board1(string statusMessage)
        {

            listBox_Log.Items.Add(statusMessage);
        }

        //
        //trả lời cho một người
        //

        void send_command_to_sender(string strMessage, user sender)
        {
            sender.data_sender(strMessage);
        }

        //
        //trả lời cho tất cả mọi người
        //

        void send_command_to_clients(string strMessage, user sender)
        {
            user client;
            foreach(DictionaryEntry de in hshClients)
            {
                client = (user)de.Value;
                if (client.username != sender.username)
                    client.data_sender(strMessage);
            }
        }

        //
        //gửi tin nhắn 
        //

        void send_chat_message(string strMessage, user sender)
        { 
           
            update_content_board(sender.username + ": " + strMessage);
           send_command_to_clients("chat|" + sender.username + ": " + strMessage, sender);
        }

        //
        //ngắt kết nối  
        //

        void user_disconnect(user sender)
        {
            update_content_board1("Waiting..." + sender.username + " đã thoát ra. ");

            send_command_to_clients("chat|" + "Waiting..." + sender.username + " đã thoát ra.", sender);
            hshClients.Remove(sender.username);
        }


        //
        //kết nối  
        //

        void user_connect(string user_name, user sender)
        {
            if (hshClients.Contains(user_name))
            {
                send_command_to_sender("refuse", sender);
            }
            else
            {
                sender.username = user_name;
                update_content_board1(user_name + " vừa đăng nhập. ");

                hshClients.Add(user_name, sender);

                send_command_to_sender("join", sender);
                send_command_to_clients("chat|" + "Waiting..." + sender.username + " vừa đăng nhập.", sender);
            }
        }

        //
        //lấy tất cả người dùng đang online
        //

        void online_user_list(user sender)
        {
            user client;
            string strUserList;
            update_content_board1("Đang gửi tới " + sender.username + " danh sách những người đang online. ");
            strUserList = "listusers";

            foreach (DictionaryEntry de in hshClients)
            {
                client = (user)de.Value;
                strUserList = strUserList + "|" + client.username;
            }

            send_command_to_sender(strUserList, sender);
        }

        //
        //gửi lệnh (lệnh  = command + tin nhắn(nếu có)
        //

        void send_command(string strMessage)
        {
            user client;
            foreach (DictionaryEntry de in hshClients)
            {
                client = (user)de.Value;
                client.data_sender(strMessage);
            }
        }

        private void button_Sender_Click(object sender, EventArgs e)
        {
            if(textBox_Input.Text!="")
               {
                update_content_board(label_IP.Text +": " + textBox_Input.Text);
                send_command("broad|" + textBox_Input.Text);
                textBox_Input.Text = string.Empty;
            }
        }

        //
        //xử lý command 
        //

        void process_command_received(user sender, string data)
        {
            string[] dataArray;

            dataArray = data.Split((char)124);

            switch(dataArray[0])
            {
                case "connect":
                    user_connect(dataArray[1], sender);
                    break;
                case "chat":
                    send_chat_message(dataArray[1], sender);
                    break;
                case "disconnect":
                    user_disconnect(sender);
                    break;
                case "requestusers":
                    online_user_list(sender);
                    break;
                default:
                    update_content_board("Unknow message:" + data);
                    break;
            }
        }

        //
        //lắng nghe
        //

        void listen()
        {
            try
            {
                listener = new TcpListener(System.Net.IPAddress.Any, PORT_NUMBER);
                listener.Start();
                do
                {
                    user client = new user(listener.AcceptTcpClient());
                    client.evData_received += new dlgData_receive(process_command_received);
                    update_content_board1("Một người đang kết nối, xin đơi...");
                } while (true);
            }
            catch
            {

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            listenerthread = new Thread(new ThreadStart(listen));
            listenerthread.Start();
            update_content_board1("Sẵn sàng kết nối. ");
            label_IP.Text = System.Net.Dns.GetHostName();
            label_Port.Text = PORT_NUMBER.ToString();
            textBox_Input.Focus();

            //test
            var host = Dns.GetHostEntry(Dns.GetHostName());           
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    label_Port.Text = ip.ToString();
                }
            }

        }

        private void button_Sender_Paint(object sender, PaintEventArgs e)
        {
            button_Sender.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void aboutLViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About myab = new About();
            myab.Show();
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            listener.Stop();
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yourProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            listBox_Status.BackColor = colorDialog1.Color;
        }

        private void inviteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            listBox_Status.Font = fontDialog1.Font;
        }

        private void textBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_Sender.PerformClick();
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này chưa được xây dựng. Xin vui lòng quay lại sau! ");
        }
    }
}
