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
                        bool fl = false;
                        bool skip = false;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if ( fl == true && !(line.Contains("##")))
                            {
                                
                                string str = line;
                                //MessageBox.Show(str);
                                string nameparam=line.Split(' ')[0];
                                string valueparam = line.Split(' ')[2];
                                //MessageBox.Show("name:"+nameparam + "  val:" + valueparam);
                                param.Add(nameparam, valueparam);
                            }
                            else if  (line.Contains("##") && fl == true)
                            {
                                break;
                            }                            
                            if (line.Contains("##")) fl = true;

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