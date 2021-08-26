using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _100procentov_ne_kyrsach
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Hide(); // this will hide the loading screen
            Form form = new lichniy_kabinet();
            form.ShowDialog(); // this will open real app
            Close(); // this would close the loading screen
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
