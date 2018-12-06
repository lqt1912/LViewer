using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LViewer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Lê Quốc Thắng");
            listBox1.Items.Add("Huỳnh Trầm Bảo Chấn");
            listBox1.Items.Add("Trần Hiệp Nguyên Huy");

            listBox2.Items.Add("This app just a simple tool");
            listBox2.Items.Add(" to connect computer");
            listBox2.Items.Add(" via LAN.");

        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
