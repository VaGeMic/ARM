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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ARM
{
    public struct Pair
    {
        public System.Windows.Forms.Button button;
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
            tableLayoutPanel2.DragDrop += TextBox_DragDrop;
            tableLayoutPanel2.DragEnter += TextBox_DragEnter;


        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            // ���������, ��� ��������������� �����
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // ������������� ������ �����������
            }
            else
            {
                e.Effect = DragDropEffects.None; // ���������
            }
        }

        // ��������� ������� DragDrop (���������� ������)
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            // �������� ������ ����� � ������
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                // ���������� ���� � ������
                if (Path.GetExtension(file).Equals(".py", StringComparison.OrdinalIgnoreCase))
                {
                    // ���� ���� � ����������� .py, ��������� ��� ���� � TextBox
                    //MessageBox.Show("This file is .py");

                    ScriptFile sf = Adder_Script.Add_Script_with_drag_n_drop(file);
                    MessageBox.Show($"{sf.filename}");
                }
                else
                {
                    MessageBox.Show("This file is not .py!!!");
                }
            }
        }







        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("this is a freakin' string you arsewipe" + Environment.NewLine);
        }
        /// <summary>
        /// ������ ���������� �������, �������� ����� ���������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            NewScriptForm newScriptForm = new NewScriptForm(this);
            newScriptForm.Show();
        }
        /// <summary>
        /// ������� ���������� ������ ������� � ������� �����
        /// </summary>
        /// <param name="name">�������� �������</param>
        public void AddNewScript(string name)
        {
            System.Windows.Forms.Button scriptButton = new System.Windows.Forms.Button();
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
