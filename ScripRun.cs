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
using System.Runtime.InteropServices;
//using System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.PortableExecutable;

namespace ARM
{
    public partial class ScriptRun : Form
    {
        private Form1 parentForm;
        private string outputFilePath = @"C:\Users\Роман\source\repos\ARM.git\Buffer.txt"; // Путь к файлу вывода

        public ScriptRun(Form1 pForm)
        {
            parentForm = pForm;
        }

        internal void ScripRun(Button scriptButton)
        {
            scriptButton.Click += (sender, args) =>
            {
                try
                {
                    // Код для запуска скрипта Python
                    string pythonPath = @"C:\Users\Роман\Documents\Python\python.exe";
                    string scriptPath = parentForm.ScriptFiles.Last().filepath;

                    ProcessStartInfo startInfo = new ProcessStartInfo(pythonPath);
                    startInfo.Arguments = $"\"{scriptPath}\""; // Аргументы передаются в виде строки
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardError = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.StandardErrorEncoding = Encoding.UTF8;
                    startInfo.StandardOutputEncoding = Encoding.UTF8;


                    using (Process process = Process.Start(startInfo))
                    {
                        string standardOutput = process.StandardOutput.ReadToEnd();
                        string standardError = process.StandardError.ReadToEnd();

                        File.WriteAllText(outputFilePath, standardOutput + Environment.NewLine + standardError);

                        process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Исправлена ошибка с MessageBoxButton
                }
                OutConsole();
            };

        }

        void OutConsole()
        {
            string searchWord = "Traceback";
            bool found = false;
            try
            {
                using (StreamReader reader = new StreamReader(outputFilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains(searchWord))
                        {
                            found = true;
                        }
                        if(found)
                            parentForm.textBox2.AppendText(line + Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); // Исправлена ошибка с MessageBoxButton
            }

            if (found)
            {

            }
            else
            {
                using (StreamReader reader = new StreamReader(outputFilePath))
                {
               
                    string line;
                    line = "Script executed successfully";
                    parentForm.textBox2.AppendText(line + Environment.NewLine);
                    while ((line = reader.ReadLine()) != null)
                    {
                        parentForm.textBox1.AppendText(line + Environment.NewLine);
                    }
                }
            }
            File.Create(outputFilePath).Close();
        }
    }
}