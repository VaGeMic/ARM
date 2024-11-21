using System.Reflection.Emit;
using System.Windows.Forms;

namespace ARM
{
    /// <summary>
    /// ����� ��� ���������� ������� � ���������
    /// </summary>
    static class Adder_Script
    {
        /// <summary>
        /// ���������� ���� ���������� �����
        /// </summary>
        /// <returns>���������� ���� ���� � �����</returns>
        public static ScriptFile Add_Script()
        {
            var fileContent = string.Empty; // ���������� �����
            var filePath = string.Empty;    // ���� � �����+���+����������
            Dictionary<string, string> param = new Dictionary<string, string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; //������������� �������, ������� ������������ ��� ������ ������ ����
                //openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Filter = "python files (*.py)|*.py"; //������ ���������� �������� ����� (���������� � 1)
                openFileDialog.FilterIndex = 2; //������ �������, ����� � ����� ������� ������ ��������� ���������� � �� �������(�� ��������� 1) 
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK) //�������� ����������� ����
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    
                   
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string line;
                        bool fl = true;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("##") && fl == true)
                            {
                                line = reader.ReadLine();
                                string str = line;
                                string nameparam=line.Split(' ')[0];
                                string valueparam = line.Split(' ')[2];
                                param.Add(nameparam, valueparam);
                            }
                            else if  (line.Contains("##") && fl == false)
                            {
                                break;
                            }
                        }
                    }

                }
                string fileName = Path.GetFileName(filePath);
                ScriptFile scriptFile = new ScriptFile(filePath, fileName, param);
                return scriptFile;
            }
        }
    }
     
}