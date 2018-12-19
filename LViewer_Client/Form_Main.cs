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
        public string user;
        byte[] readBuffer = new byte[MAX_BUFFER_SIZE];
        string str = " .  ";
        string myIP = "127.0.0.1";
       
        //
        //đánh dấu mất kết nối
        //

        void mark_as_disconected()
        {
            textBox_Input.ReadOnly = true;
            button_Send.Enabled = false;
        }

        //
        //gửi lệnh (lệnh  = command + tin nhắn(nêu có))
        //

        void send_command(string Data)
        {
            lock (client.GetStream())
            {
                StreamWriter writer = new StreamWriter(client.GetStream());
                writer.Write(Data + (char)13);
                writer.Flush();
            }

        }

        //
        //xử lý đăng nhập 
        //

        void login_process()
        {
            Form_Login frmLogin = new Form_Login();
            frmLogin.StartPosition = FormStartPosition.CenterParent;
            frmLogin.ShowDialog(this);
            //send_command("connect|" + frmLogin.textBox_UserFormLogin.Text);
            send_command("connect|" + frmLogin.labelName);
            frmLogin.Dispose();
            user = frmLogin.textBox_UserFormLogin.Text;
            user = frmLogin.labelName;
            label_UsernameFixed.Text = user; 
        }

        //
        //update tin nhắn, thông điệp lên listbox
        //

        void update_content_board(string text)
        {
           // CheckForIllegalCrossThreadCalls = false;
            textBox_Status.AppendText(text);
        }

        void update_content_board1(string text)
        {
            // CheckForIllegalCrossThreadCalls = false;
            listBox1.Items.Add(text);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Form_Login frmLogin = new Form_Login();
            try
            {
                client = new TcpClient("localhost", PORT_NUMBER);
                client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(read), null);
                this.Show();
                login_process();
                textBox_Input.Focus();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Unable to connect to sever! ", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
        } 

        //
        //Xử lý online list 
        //
        void online_user_list(string[] users)
        {
            for( int i=1; i<users.Length; i++)
            {
                listBox_Online.Items.Add(users[i]);
            }
        }

        void process_command_received(string strMessage)
        {
            string[] dataArray;
            dataArray = strMessage.Split((char)124);

            switch(dataArray[0])
            {
                case "join":
                    update_content_board1("bạn đã đăng nhập thành công!  "+(char)13 + (char)10 );
                    break;
                case "chat":
                    if (dataArray[1].Substring(0, 10) == "Waiting...")
                        update_content_board(dataArray[1] + (char)13 + (char)10);
                    else
                    {
                        string data = dataArray[1];
                        string subStringYes = data.Substring(data.Length - user.Length, user.Length);
                        string subStringNo = data.Substring(data.Length - " .  ".Length, " .  ".Length);
                        if (subStringYes == user)
                            update_content_board(((data.Substring(0, data.Length - user.Length)) + (char)13 + (char)10));
                        else if (subStringNo == " .  ")
                            update_content_board((data.Substring(0,data.Length -" .  ".Length) )+ (char)13 + (char)10);
                    }
                    break;
                case "refuse":
                    login_process();
                    break;
                case "listusers":
                    online_user_list(dataArray);
                    break;
                case "broad":
                    update_content_board("SERVER: " + dataArray[1] + (char)13 + (char)10);
                    break;
            }
            
        }

        //
        //hàm lắng nghe từ phía sever
        //

        void read(IAsyncResult iar)
        {
            int BytesRead;
            string strMessage;
            try
            {
                BytesRead = client.GetStream().EndRead(iar);
                if(BytesRead <1)
                {
                    mark_as_disconected();
                    return;
                }
                strMessage = Encoding.UTF8.GetString(readBuffer, 0, BytesRead - 2);
                process_command_received(strMessage);

                client.GetStream().BeginRead(readBuffer, 0, MAX_BUFFER_SIZE, new AsyncCallback(read), null);
            }
            catch(Exception ex)
            {
                mark_as_disconected();
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if(textBox_Input.Text!= "")
            {
                update_content_board(user + ": " + textBox_Input.Text + (char)13 + (char)10);

                send_command("chat|" +(textBox_Input.Text) +str);

                textBox_Input.Text = string.Empty;
            }
        }

        private void button_Send_Paint(object sender, PaintEventArgs e)
        {
            button_Send.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void listBox_Online_SelectedIndexChanged(object sender, EventArgs e)
        {
            str = listBox_Online.Text;
            label_Private.Text ="Bạn đang chat private với: " + str;
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_Send.Enabled == true)
                send_command("disconnect");
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            listBox_Online.Items.Clear();
            send_command("requestusers");
        }

        private void button_PublicChat_Click(object sender, EventArgs e)
        {
            str = " .  ";
            label_Private.Text = "Bạn đang chat public! ";
        }

        private void label_Private_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox_Status.BackColor = colorDialog1.Color;
        }

        private void changeFontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox_Status.Font = fontDialog1.Font;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_Send.PerformClick();
            }
        }

        private void textBox_Input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_Send.PerformClick();
            }
        }
    }
}
