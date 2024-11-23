using System.Numerics;

namespace ARM
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// ������ ��������, � ������� ���� ���, ���� � ���������
        /// </summary>
        internal List<ScriptFile> ScriptFiles { get; set; } = new List<ScriptFile>();
        public Form1()
        {
            InitializeComponent();
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
            Button scriptButton = new Button();
            scriptButton.Text = $"{name}";
            scriptButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            scriptButton.AutoSize = true;
            tableLayoutPanel2.Controls.Add(scriptButton); // ��� ������ �������� � ���� ����������
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
