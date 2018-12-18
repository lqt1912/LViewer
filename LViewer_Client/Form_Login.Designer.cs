namespace LViewer_Client
{
    partial class Form_Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UserFormLogin = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập username";
            // 
            // textBox_UserFormLogin
            // 
            this.textBox_UserFormLogin.Location = new System.Drawing.Point(171, 59);
            this.textBox_UserFormLogin.Name = "textBox_UserFormLogin";
            this.textBox_UserFormLogin.Size = new System.Drawing.Size(156, 20);
            this.textBox_UserFormLogin.TabIndex = 1;
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(129, 100);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(75, 23);
            this.button_Login.TabIndex = 2;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            // 
            // Form_Login
            // 
            this.AcceptButton = this.button_Login;
            this.AccessibleDescription = "Login Form";
            this.AccessibleName = "Login Form";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(362, 135);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_UserFormLogin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Login";
            this.Text = "Form_Login";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Login_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Login;
        public System.Windows.Forms.TextBox textBox_UserFormLogin;
    }
}