using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace ARM
{
    public struct Pair
    {
        public Button button;
        public String way;
    }

    public partial class Form1 : Form
    {
        /// <summary>
        /// ������ ��������, � ������� ���� ���, ���� � ���������
        /// </summary>
        internal List<ScriptFile> ScriptFiles { get; set; } = new List<ScriptFile>();
        public ScriptRun script;
        public Form1()
        {
            InitializeComponent();
            script = new ScriptRun(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("this is a freakin' string you arsewipe" + Environment.NewLine);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewScriptForm newScriptForm = new NewScriptForm(this);
            newScriptForm.Show();
        }

        public void AddNewScript(string name)
        {
            Button scriptButton = new Button();
            scriptButton.Text = $"{name}";
            scriptButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            scriptButton.AutoSize = true;
            script.ScripRun(scriptButton);
            //scriptButton.Click += (sender, args) => { Process.Start(new ProcessStartInfo(parentForm.ScriptFiles.Last().filepath) { UseShellExecute = true }); };
            tableLayoutPanel2.Controls.Add(scriptButton);
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].Height = 30;

            textBox1.AppendText(Environment.NewLine + "������ ��������:" + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filename + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filepath + Environment.NewLine);
            foreach (KeyValuePair<string, string> param in ScriptFiles.Last().param)
            {
                textBox1.AppendText(param.Key + ": " + param.Value + Environment.NewLine);
            }
        }
    }
}
