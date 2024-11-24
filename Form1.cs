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
        /// Список скриптов, у каждого есть имя, путь и аргументы
        /// </summary>
        internal List<ScriptFile> ScriptFiles { get; set; } = new List<ScriptFile>();
        public ScriptRun script;
        public Form1()
        {
            InitializeComponent();
            script = new ScriptRun(this);
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
            scriptButton.Name = $"scriptButton{ScriptFiles.Count - 1}";
            script.ScripRun(scriptButton, ScriptFiles.Count - 1); // передаю индекс кнопки
            //scriptButton.Click += (sender, args) => { Process.Start(new ProcessStartInfo(parentForm.ScriptFiles.Last().filepath) { UseShellExecute = true }); };
            tableLayoutPanel2.Controls.Add(scriptButton);
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].SizeType = SizeType.Absolute;
            tableLayoutPanel2.RowStyles[tableLayoutPanel2.RowCount - 1].Height = 30;

            Button configButton = new Button();
            configButton.Text = "...";
            configButton.AutoSize = true;
            configButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            configButton.Click += (sender, args) => ConfigButton_Click(sender, args);
            configButton.Name = $"configButton{ScriptFiles.Count - 1}";

            tableLayoutPanel2.Controls.Add(configButton);

            textBox1.AppendText(Environment.NewLine + "Скрипт добавлен:" + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filename + Environment.NewLine);
            textBox1.AppendText(ScriptFiles.Last().filepath + Environment.NewLine);
            foreach (KeyValuePair<string, string> param in ScriptFiles.Last().param)
            {
                textBox1.AppendText(param.Key + ": " + param.Value + Environment.NewLine);
            }
        }
        public void ConfigButton_Click(object sender, EventArgs e)
        {
            int number = 0;
            int len = "configButton".Length;
            number = int.Parse((sender as Button).Name.Substring(len));

            ScriptConfigForm scriptConfigForm = new ScriptConfigForm(this, number); // тут тоже передаю индекс кнопки, но всё работает
            scriptConfigForm.Show();
        }
    }
}
