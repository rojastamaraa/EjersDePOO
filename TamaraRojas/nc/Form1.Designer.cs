namespace nc
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.button8 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(199, 224);
			this.listBox1.TabIndex = 12;
			this.listBox1.TabStop = false;
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.ItemHeight = 20;
			this.listBox2.Location = new System.Drawing.Point(589, 12);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(199, 224);
			this.listBox2.TabIndex = 11;
			this.listBox2.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 289);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(99, 40);
			this.button1.TabIndex = 2;
			this.button1.Text = "Agregar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(112, 289);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(99, 40);
			this.button3.TabIndex = 3;
			this.button3.Text = "Eliminar";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(293, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(212, 29);
			this.button5.TabIndex = 7;
			this.button5.Text = "<";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(293, 47);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(212, 28);
			this.button6.TabIndex = 8;
			this.button6.Text = "<<<";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(293, 172);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(212, 29);
			this.button7.TabIndex = 9;
			this.button7.Text = ">";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(293, 207);
			this.button8.Name = "button8";
			this.button8.Size = new System.Drawing.Size(212, 29);
			this.button8.TabIndex = 10;
			this.button8.Text = ">>>";
			this.button8.UseVisualStyleBackColor = true;
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 257);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(199, 26);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(589, 257);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(199, 26);
			this.textBox2.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(689, 289);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(99, 40);
			this.button2.TabIndex = 6;
			this.button2.Text = "Eliminar";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(589, 289);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(99, 40);
			this.button4.TabIndex = 5;
			this.button4.Text = "Agregar";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.listBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
	}
}

