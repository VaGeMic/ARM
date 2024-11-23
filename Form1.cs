using System.Numerics;

namespace ARM
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Список скриптов, у каждого есть имя, путь и аргументы
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
        /// Кнопка добавления скрипта, вызывает форму добавления скрипта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            NewScriptForm newScriptForm = new NewScriptForm(this);
            newScriptForm.Show();
        }
        /// <summary>
        /// Функция добавления кнопки скрипта в главную форму
        /// </summary>
        /// <param name="name">Название скрипта</param>
        public void AddNewScript(string name)
        {
            Button scriptButton = new Button();
            scriptButton.Text = $"{name}";
            scriptButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            scriptButton.AutoSize = true;
            tableLayoutPanel2.Controls.Add(scriptButton); // все кнопки скриптов в этом контейнере
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].Height = 30;

            textBox1.AppendText(Environment.NewLine + "Скрипт добавлен:" + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filename + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filepath + Environment.NewLine);
            foreach (KeyValuePair<string, string> param in ScriptFiles.Last().param)
            {
                textBox1.AppendText(param.Key + ": " + param.Value + Environment.NewLine);
            }
        }
    }
}
