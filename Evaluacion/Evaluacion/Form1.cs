using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] n = { "tamara", "chanculio", "mortadela", "renata", "michael jackson", "ñ", "siete", "c#", "linea", "intro" };
            string[] n2 = { "rojas", "chanjunio", "caballo", "serenata", "mercury", "n", "ziete", "c#sharp", "liea", "io" };
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(n[i]);
                listBox2.Items.Add(n2[i]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string n, n2;
            for (int i = 0;i < listBox1.Items.Count; i++)
            {
                n = listBox1.Items[i].ToString();
                
                if (n.Length <= 5)
                {
                    listBox1.Items.RemoveAt(i);

                    i = i - 1;
                }   
            }
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                n2 = listBox2.Items[i].ToString();
                if (n2.Length <= 5)
                {
                    listBox2.Items.RemoveAt(i);

                    i--;
                }
            }
        }

        private void Ordenar_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = true;
            listBox2.Sorted = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string n, n2;
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                n = listBox1.Items[i].ToString();

                if (n.Length <= 5)
                {
                    list.Add(n);
                }
            }
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                n2 = listBox2.Items[i].ToString();
                if (n2.Length <= 5)
                {
                    list2.Add(n2);
                }
            }

            for(int i = 0;i < list.Count;i++) 
            {
                listBox2.Items.Add(list[i]);
            }

            for (int i = 0; i < list2.Count; i++)
            {
                listBox1.Items.Add(list2[i]);
            }

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                for (int j = 0; j < list.Count; ++j)
                if (listBox1.Items[i].ToString() == list[j])
                {
                    listBox1.Items.RemoveAt(i);
                }
            }

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                for (int j = 0; j < list2.Count; ++j)
                    if (listBox2.Items[i].ToString() == list2[j])
                    {
                        listBox2.Items.RemoveAt(i);
                    }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //tarde mucho y no alcance ñe
            int aux = listBox1.Items.Count;
            string pr = listBox1.Items[0].ToString();
            string ult = listBox1.Items[aux-1].ToString();

            int aux2 = listBox2.Items.Count;
            string pr2 = listBox2.Items[0].ToString();
            string ult2 = listBox2.Items[aux2 - 1].ToString();

            listBox1.Text.Insert(0, "");
        }
    }
}
 