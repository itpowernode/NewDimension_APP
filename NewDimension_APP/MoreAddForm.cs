using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDimension_APP
{
    public partial class MoreAddForm : Form
    {
        public MoreAddForm(string type, string message)
        {
            InitializeComponent();
            this.Text = type;
            label_message.Text = message;
        }

        private void MoreAddForm_Load(object sender, EventArgs e)
        {

        }

        private void button_havemore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void button_lastone_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
