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

namespace WindowsFormsApp3
{
    public struct Pair
    {
        public Button button;
        public String way;
    }

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public String Name(String way)
        {
            int a = way.LastIndexOf('\\') + 1, b = way.LastIndexOf('.');
            return way.Substring(a, b-a); 
        }

        public void ScripRun(List<String> wayscripts)
        {
            String name;
            int x = 0, y = 0;
            List<Pair> buttons = new List<Pair>();
            foreach (String i in wayscripts)
            {
                Pair one = new Pair();
                Button but = new Button();
                but.Text = Name(i);
                one.button = but;
                one.way = i;
                buttons.Add(one);
                one.button.Location = new System.Drawing.Point(x,y);
                this.Controls.Add(one.button);
                y+=20;
            }
            foreach (Pair i in buttons)
            {
                i.button.Click += (sender, args) => { Process.Start(i.way); };
            }


        }
    }
}
