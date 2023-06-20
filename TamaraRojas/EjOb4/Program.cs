using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb4
{
	class Electrodomestico
	{
		private double preciobase = precioDefecto;
		private string color = colorDefecto;
		private char consumoEner = consumoDefecto;
		private double peso = pesoDefecto;

		const string colorDefecto = "BLANCO";
		const char consumoDefecto = 'F';
		const double precioDefecto = 100;
		const double pesoDefecto = 5;

		public Electrodomestico() { }

		public Electrodomestico(double preciobase, double peso)
		{
			this.preciobase = preciobase;
			this.peso = peso;
		}

		public Electrodomestico(double preciobase, string color, char consumoEner, double peso)
		{
			this.preciobase = preciobase;
			comprobarColor(color);
			comprobarConsumo(consumoEner);
			this.peso = peso;
		}

		public double Preciobase
		{
			get { return preciobase; }
		}

		public string Color
		{
			get { return color; }
		}

		public char ConsumoEner
		{
			get { return consumoEner; }
		}

		public double Peso
		{
			get { return peso; }
		}

		private void comprobarConsumo(char letra)
		{
			char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F' };
			for (int i = 0; i < letras.Length; i++)
			{
				if (letra == letras[i])
				{
					consumoEner = letra;
				}
			}
		}

		private void comprobarColor(string color)
		{
			string[] colores = { "BLANCO", "NEGRO", "ROJO", "AZUL", "GRIS" };
			for (int i = 0; i < colores.Length; i++)
			{
				if (color.ToUpper() == colores[i])
				{
					this.color = color;
				}
				else
				{
					this.color = colorDefecto;
				}
			}
		}

		public double precioFinal()
		{

			switch (consumoEner)
			{
				case 'A':
					preciobase = preciobase + 100;
					break;
				case 'B':
					preciobase = preciobase + 80;
					break;
				case 'C':
					preciobase = preciobase + 60;
					break;
				case 'D':
					preciobase = preciobase + 50;
					break;
				case 'E':
					preciobase = preciobase + 30;
					break;
				case 'F':
					preciobase = preciobase + 10;
					break;
			}

			if (peso > 0 && peso <= 19)
			{
				preciobase = preciobase + 10;
			}
			else if (peso >= 20 && peso <= 49)
			{
				preciobase = preciobase + 50;
			}
			else if (peso >= 50 && peso <= 79)
			{
				preciobase = preciobase + 80;
			}
			else
			{
				preciobase = preciobase + 100;
			}
			double precio = preciobase;
			return precio;
		}
	}

	class Lavadora : Electrodomestico
	{
		private double carga;

		const double cargaDefecto = 5;

		public Lavadora() : base() { }
		public Lavadora(double precio, double peso) : base(precio, peso) { }
		public Lavadora(double preciobase, string color, char consumoEner, double peso, double carga) : base(preciobase, color, consumoEner, peso)
		{
			this.carga = carga;
		}

		public double Carga
		{
			get { return carga; }
		}

		new public double precioFinal()
		{
			double precio = base.precioFinal();
			if (carga > 30)
			{
				precio = precio + 50;
			}
			return precio;
		}
	}

	class Television : Electrodomestico
	{
		private double resolucion = pulgadasDefecto;
		private bool sintonizador = false;

		const double pulgadasDefecto = 50.8 / 2.54;

		public Television() : base() { }
		public Television(double precio, double peso) : base(precio, peso) { }
		public Television(double preciobase, string color, char consumoEner, double peso, double resolucion, bool sintonizador) : base(preciobase, color, consumoEner, peso)
		{
			this.resolucion = resolucion;
			this.sintonizador = sintonizador;
		}

		public double Resolucion
		{
			get { return resolucion; }
		}

		public bool Sintonizador
		{
			get { return sintonizador; }
		}

		new public double precioFinal()
		{
			double precio = base.precioFinal();
			if (resolucion > 40)
			{
				precio = precio + precio * 0.30;
			}

			if (sintonizador == true)
			{
				precio = precio + 50;
			}

			return precio;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			Electrodomestico[] electrodomesticos = new Electrodomestico[10];

			electrodomesticos[0] = new Television(100, "Rosa", 'A', 85, 50, true);
			electrodomesticos[1] = new Lavadora();
			electrodomesticos[2] = new Television();
			electrodomesticos[3] = new Television();
			electrodomesticos[4] = new Lavadora();
			electrodomesticos[5] = new Television();
			electrodomesticos[6] = new Lavadora();
			electrodomesticos[7] = new Lavadora();
			electrodomesticos[8] = new Lavadora();
			electrodomesticos[9] = new Television();

			double precioLavadoras = 0;
			double precioTelevisores = 0;

			for (int i = 0; i < electrodomesticos.Length; i++)
			{
				if (electrodomesticos[i] is Lavadora)
				{
					precioLavadoras = precioLavadoras + electrodomesticos[i].precioFinal();
				}
				else if (electrodomesticos[i] is Television)
				{
					precioTelevisores = precioTelevisores + electrodomesticos[i].precioFinal();
				}
			}
			double precioElectrodomesticos = precioLavadoras + precioTelevisores;

			Console.WriteLine("Precio total de electrodomésticos: " + precioElectrodomesticos);
			Console.WriteLine("Precio total de lavadoras: " + precioLavadoras);
			Console.WriteLine("Precio total de televisores: " + precioTelevisores);
			Console.Read();
		}
	}
}