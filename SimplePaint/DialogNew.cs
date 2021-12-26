using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePaint
{
    public partial class DialogNew : Form
    {
        private Size selectedDimensions = Size.Empty;

        public Size SelectedDimensions
        {
            get => selectedDimensions;
            private set => selectedDimensions = value;
        }

        public DialogNew()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SelectedDimensions = new Size((int)numericUpDownW.Value, (int)numericUpDownH.Value);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
