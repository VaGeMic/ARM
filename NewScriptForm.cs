using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class NewScriptForm : Form
    {
        private Form1 parentForm;

        public NewScriptForm(Form1 pForm)
        {
            InitializeComponent();
            parentForm = pForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.AddNewScript(textBox1.Text);
            Close();
        }

    }
}
