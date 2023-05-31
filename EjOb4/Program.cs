using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb4
{
	class Electrodomestico
	{
		private double preciobase = 100;
		private string color = "blanco";
		private char consumo = 'F';
		private double peso = 5;

		public Electrodomestico() {}

		public Electrodomestico(double preciobase, double peso)
		{
			this.preciobase = preciobase;
			this.peso = peso;

		}

		public Electrodomestico(double preciobase, string color, char consumo, double peso)
		{
			this.preciobase = preciobase;
			comprobarColor(color);
			comprobarConsumoEner(consumo);
			this.peso = peso;
		}

		public double Preciobase
		{
			get
			{
				return this.preciobase;
			}
		}

		public string Color
		{
			get
			{
				return this.color;
			}
		}

		public char Consumo
		{
			get
			{
				return this.consumo;
			}
		}

		public double Peso
		{
			get
			{
				return this.peso;
			}
		}

		private void comprobarConsumoEner(char letra)
		{
			const string letrasposi = "ABCDEF";
			if(letrasposi.Contains(letra))
			{
				this.consumo = letra;
			}
			else
			{
				this.consumo = 'F';
			}
		}

		private void comprobarColor(string color)
		{
			const string coloresposi = "BLANCONEGROROJOSAZULGRIS";
			if (coloresposi.Contains(color))
			{
				this.color = color;
			}
			else
			{
				this.color = "BLANCO";
			}
		}

		public double precio_final()
		{
			double precio = preciobase; 
			switch(this.consumo)
			{
				case 'A':
					preciobase += 100;
					break;
				case 'B':
					preciobase += 80;
					break;
				case 'C':
					preciobase += 60;
					break;
				case 'D':
					preciobase += 50;
					break;
				case 'E':
					preciobase += 30;
					break;
				case 'F':
					preciobase += 10;
					break;
			}

			if(this.peso > 0 && this.peso < 19)
			{
				this.peso += 10;
			}
			else if (this.peso > 20 && this.peso < 49)
			{
				this.peso += 50;
			}
			else if (this.peso > 50 && this.peso < 79)
			{
				this.peso += 80;
			}
			else if (this.peso > 80)
			{
				this.peso += 100;
			}
			return precio;
		}
	}

	class Lavadora : Electrodomestico
	{
		private double carga = 5;

		public Lavadora(): base() { }

		public Lavadora (double precio, double peso) : base(precio, peso) {}

		public Lavadora(double precio, string color, char consumo, double peso, double carga) : base (precio, color, consumo, peso)
		{
			this.carga = carga;
		}

		public double Carga
		{
			get
			{
				return this.carga;
			}
		}

		public double precioFinal()
		{
			double precio = base.precio_final();
			if(this.carga > 30 )
			{
				precio += 50;
			}

			return precio;
		}
	}

	class Television : Electrodomestico
	{
		private double resolucion = 20;
		private bool TDT = false;

		public Television(): base() { }

		public Television(double precio, double peso):base(precio, peso) { }

		public Television(double precio, string color, char consumo, double peso, double resolucion, bool TDT) : base(precio, color, consumo, peso)
		{
			this.resolucion = resolucion;
			this.TDT = TDT;
		}

		public double Resolucion
		{
			get
			{
				return this.resolucion;
			}
		}

		public bool Tdt
		{
			get
			{
				return this.TDT;
			}
		}

		public double preciofinal()
		{
			double precio = base.precio_final();
			if(this.resolucion > 40)
			{
				precio *= 1.30F;;
			}
			return precio;
		}

	}

	class Ejecutable
	{
		static void Main(string[] args)
		{

			Electrodomestico[] electrodomesticos = new Electrodomestico[10];

			electrodomesticos[0] = new Television(10, "Rosa", 'Z', 65, 50, false);
			electrodomesticos[1] = new Lavadora(10, "Violeta", 'A', 81, 20);
			electrodomesticos[2] = new Television();
			electrodomesticos[3] = new Television(10,15);
			electrodomesticos[4] = new Lavadora(30,26);
			electrodomesticos[5] = new Television();
			electrodomesticos[6] = new Lavadora(40, "rojo", 'B', 20, 15);
			electrodomesticos[7] = new Lavadora();
			electrodomesticos[8] = new Lavadora();
			electrodomesticos[9] = new Television();

			for (int i = 0; i < electrodomesticos.Length; i++)
			{
				electrodomesticos[i].precio_final();
				Console.WriteLine(electrodomesticos[i].Preciobase + " " + electrodomesticos[i].Peso);
			}






			Console.ReadLine();

		}
	}
}

