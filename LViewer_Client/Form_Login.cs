﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LViewer_Client
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }
        public string labelName= "";
        private void Form_Login_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button_Login.PerformClick();
            }

        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            labelName = textBox_UserFormLogin.Text;
            this.Dispose();
        }
    }
}
