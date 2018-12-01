namespace LViewer_Client
{
    partial class Form_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Status = new System.Windows.Forms.TextBox();
            this.listBox_Online = new System.Windows.Forms.ListBox();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.button_Send = new System.Windows.Forms.Button();
            this.button_UpdateList = new System.Windows.Forms.Button();
            this.button_PublicChat = new System.Windows.Forms.Button();
            this.label_Username = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hekpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Status
            // 
            this.textBox_Status.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.textBox_Status.AllowDrop = true;
            this.textBox_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Status.Location = new System.Drawing.Point(3, 2);
            this.textBox_Status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Status.Multiline = true;
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.Size = new System.Drawing.Size(594, 213);
            this.textBox_Status.TabIndex = 0;
            this.textBox_Status.TextChanged += new System.EventHandler(this.textBox_Status_TextChanged);
            // 
            // listBox_Online
            // 
            this.listBox_Online.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Online.FormattingEnabled = true;
            this.listBox_Online.ItemHeight = 16;
            this.listBox_Online.Location = new System.Drawing.Point(3, 2);
            this.listBox_Online.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Online.Name = "listBox_Online";
            this.listBox_Online.Size = new System.Drawing.Size(319, 301);
            this.listBox_Online.TabIndex = 1;
            this.listBox_Online.SelectedIndexChanged += new System.EventHandler(this.listBox_Online_SelectedIndexChanged);
            // 
            // textBox_Input
            // 
            this.textBox_Input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Input.Location = new System.Drawing.Point(3, 2);
            this.textBox_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(591, 27);
            this.textBox_Input.TabIndex = 2;
            // 
            // button_Send
            // 
            this.button_Send.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_Send.Location = new System.Drawing.Point(3, 15);
            this.button_Send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(65, 32);
            this.button_Send.TabIndex = 3;
            this.button_Send.Text = "Gửi";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // button_UpdateList
            // 
            this.button_UpdateList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_UpdateList.Location = new System.Drawing.Point(3, 14);
            this.button_UpdateList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_UpdateList.Name = "button_UpdateList";
            this.button_UpdateList.Size = new System.Drawing.Size(170, 28);
            this.button_UpdateList.TabIndex = 4;
            this.button_UpdateList.Text = "Refresh";
            this.button_UpdateList.UseVisualStyleBackColor = true;
            this.button_UpdateList.Click += new System.EventHandler(this.button_UpdateList_Click);
            // 
            // button_PublicChat
            // 
            this.button_PublicChat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_PublicChat.Location = new System.Drawing.Point(3, 57);
            this.button_PublicChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_PublicChat.Name = "button_PublicChat";
            this.button_PublicChat.Size = new System.Drawing.Size(170, 30);
            this.button_PublicChat.TabIndex = 5;
            this.button_PublicChat.Text = "Public Chat";
            this.button_PublicChat.UseVisualStyleBackColor = true;
            this.button_PublicChat.Click += new System.EventHandler(this.button_PublicChat_Click);
            // 
            // label_Username
            // 
            this.label_Username.AutoSize = true;
            this.label_Username.Location = new System.Drawing.Point(37, 14);
            this.label_Username.Name = "label_Username";
            this.label_Username.Size = new System.Drawing.Size(46, 17);
            this.label_Username.TabIndex = 6;
            this.label_Username.Text = "label1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_Status, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(36, 91);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 217);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.textBox_Input, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(36, 383);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 37);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hekpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1087, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBackgroundColorToolStripMenuItem,
            this.changeFontColorToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeBackgroundColorToolStripMenuItem
            // 
            this.changeBackgroundColorToolStripMenuItem.Name = "changeBackgroundColorToolStripMenuItem";
            this.changeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.changeBackgroundColorToolStripMenuItem.Text = "Change Background Color";
            // 
            // changeFontColorToolStripMenuItem
            // 
            this.changeFontColorToolStripMenuItem.Name = "changeFontColorToolStripMenuItem";
            this.changeFontColorToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.changeFontColorToolStripMenuItem.Text = "Change Font Color";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.exitToolStripMenuItem.Text = "Exit ";
            // 
            // hekpToolStripMenuItem
            // 
            this.hekpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.hekpToolStripMenuItem.Name = "hekpToolStripMenuItem";
            this.hekpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.hekpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.listBox_Online, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(684, 53);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(325, 305);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.button_UpdateList, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_PublicChat, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(807, 359);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(176, 89);
            this.tableLayoutPanel4.TabIndex = 12;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.button_Send, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(665, 368);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(71, 49);
            this.tableLayoutPanel5.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 494);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_Username);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Main";
            this.Text = "LViewer";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Status;
        private System.Windows.Forms.ListBox listBox_Online;
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button_UpdateList;
        private System.Windows.Forms.Button button_PublicChat;
        private System.Windows.Forms.Label label_Username;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hekpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
    }
}