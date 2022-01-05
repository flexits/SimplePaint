using System;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class DialogAbout : Form
    {
        public DialogAbout()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://icons8.com/");
        }
    }
}
