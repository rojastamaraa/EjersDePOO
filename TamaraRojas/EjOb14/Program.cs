using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb14
{
	class Producto
	{
		private string nombre;
		private double precio;

		public Producto(string nombre, double precio)
		{
			this.nombre = nombre;
			this.precio = precio;
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		public double Precio
		{
			get { return precio; }
			set { precio = value; }
		}

		public override string ToString()
		{
			return "Nombre: " + nombre + "\n" + "Precio: " + precio;
		}

		public virtual void calcular(int cant)
		{
			precio = precio * cant;
		}
	}

	class Perecedero: Producto
	{
		private int diasCaducar;

		public Perecedero(string nombre, double precio, int diasCaducar) : base(nombre, precio)
		{
			this.diasCaducar = diasCaducar;
		}

		public int DiasCaducar
		{
			get { return diasCaducar; }
			set { diasCaducar = value; }
		}

		public override string ToString()
		{
			return "Nombre: " + Nombre + "\n" + "Precio: " + Precio + "\n" + "Dias a caducar: " + diasCaducar;
		}

		public override void calcular(int cant)
		{
			base.calcular(cant);
			switch (diasCaducar)
			{
				case 1:
					Precio = Precio / 4;
					break;
				case 2:
					Precio = Precio / 3;
					break;
				case 3:
					Precio = Precio / 2;
					break;
			}
		}
	}

	class NoPerecedero : Producto
	{
		private string tipo;

		public NoPerecedero(string nombre, double precio, string tipo) : base(nombre, precio)
		{
			this.tipo = tipo;
		}

		public string Tipo
		{
			get { return tipo; }
			set { tipo = value; }
		}

		public override string ToString()
		{
			return "Nombre: " + Nombre + "\n" + "Precio: " + Precio + "\n" + "Tipo: " + tipo;
		}

		public override void calcular(int cant)
		{
			base.calcular(cant);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			string[] nombres = new string[] {"Manzana", "Pan", "Cereal", "Arroz", "Pasta", "Chantilly", "Crema", "Yogur", "Queso", "Leche"};
			Random r = new Random();
			Producto[] productos = new Producto[10];
			double pere = 0;
			double noPere = 0;;
			for (int i = 0; i < nombres.Length; i++)
			{
				if (i < 5)
				{
					productos[i] = new Perecedero(nombres[i], r.Next(100, 500), r.Next(1, 3));
					productos[i].calcular(1);;
					pere = pere + productos[i].Precio;
				}
				else
				{
					productos[i] = new NoPerecedero(nombres[i], r.Next(100, 500), "Lacteo");
					productos[i].calcular(1);
					noPere = noPere + productos[i].Precio;
				}
			}
			
			Console.WriteLine("Perecederos precio total: " + pere);
			Console.WriteLine("No perecederos precio total: " + noPere);

			Console.Read();

		}
	}
}
