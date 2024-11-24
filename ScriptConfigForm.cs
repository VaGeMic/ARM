using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class ScriptConfigForm : Form
    {
        private Form1 parentForm;
        private ScriptFile scriptFile;
        public ScriptConfigForm(Form1 pForm)
        {
            InitializeComponent();
            parentForm = pForm;
            scriptFile = parentForm.ScriptFiles.Last();

            textBox1.Text = scriptFile.filename;
            textBox2.Text = scriptFile.filepath;

            foreach (KeyValuePair<string, string> param in scriptFile.param)
            {
                Label attributeLabel = new Label();
                TextBox attributeTextBox = new TextBox();
                TableLayoutPanel attributeTLPanel = new TableLayoutPanel();

                attributeLabel.Text = param.Key;
                attributeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                attributeTextBox.Text = param.Value;
                attributeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                attributeTextBox.BorderStyle = BorderStyle.FixedSingle;

                attributeTLPanel.Controls.Add(attributeLabel);
                attributeTLPanel.Controls.Add(attributeTextBox);
                attributeTLPanel.AutoSize = true;
                attributeTLPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                attributeTLPanel.BorderStyle = BorderStyle.FixedSingle;

                tableLayoutPanel1.Controls.Add(attributeTLPanel);
                tableLayoutPanel1.RowStyles[tableLayoutPanel1.RowStyles.Count - 1].Height = 60;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parentForm.ScriptFiles.Last().filename = textBox1.Text;
            parentForm.ScriptFiles.Last().filepath = textBox2.Text;

            int index = 0;
            foreach (KeyValuePair<string, string> param in scriptFile.param)
            {
                parentForm.ScriptFiles.Last().param[param.Key] = tableLayoutPanel1.Controls[index++].Controls[1].Text;
            }
            parentForm.textBox1.AppendText(Environment.NewLine + "Скрипт изменён:" + Environment.NewLine);
            parentForm.textBox1.AppendText(parentForm.ScriptFiles.Last().filename + Environment.NewLine);
            parentForm.textBox1.AppendText(parentForm.ScriptFiles.Last().filepath + Environment.NewLine);
            foreach (KeyValuePair<string, string> param in parentForm.ScriptFiles.Last().param)
            {
                parentForm.textBox1.AppendText(param.Key + ": " + param.Value + Environment.NewLine);
            }
            Close();
        }
    }
}
