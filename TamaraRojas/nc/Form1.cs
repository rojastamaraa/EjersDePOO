using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nc
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			string textadd = textBox1.Text;

			if (!string.IsNullOrWhiteSpace(textadd))
			{
				listBox1.Items.Add(textadd);
				textBox1.Clear();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string textadd = textBox2.Text;
			if (!string.IsNullOrWhiteSpace(textadd))
			{
				listBox2.Items.Remove(textadd);
				textBox2.Clear();
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (listBox1.Items.Count > 0)
			{
				listBox2.Items.Add(listBox1.Items[0]);
				listBox1.Items.Remove(listBox1.Items[0]);
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{
			string textadd = textBox1.Text;

            if (!string.IsNullOrWhiteSpace(textadd))
            {
				listBox1.Items.Remove(textadd);
				textBox1.Clear();
            }
        }

		private void button5_Click(object sender, EventArgs e)
		{
			if (listBox2.Items.Count > 0)
			{
				listBox1.Items.Add(listBox2.Items[0]);
				listBox2.Items.Remove(listBox2.Items[0]);
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			int items = listBox1.Items.Count;
			for (int i = 0; i < items; i++)
			{
				listBox2.Items.Add(listBox1.Items[0]);
				listBox1.Items.Remove(listBox1.Items[0]);
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			int items = listBox2.Items.Count;
			for (int i = 0; i < items; i++)
			{
				listBox1.Items.Add(listBox2.Items[0]);
				listBox2.Items.Remove(listBox2.Items[0]);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string textadd = textBox2.Text;

			if (!string.IsNullOrWhiteSpace(textadd))
			{
				listBox2.Items.Add(textadd);
				textBox2.Clear();
			}
		}
	}
}
