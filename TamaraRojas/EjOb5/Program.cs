using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb5
{

	interface IEntregable
	{
		bool entregar();
		bool devolver();
		bool isEntregado();
		int compareTo(Object a);
	}

	class Serie : IEntregable
	{
		private string titulo;
		private int cantTemp = 3;
		private bool entregado = false;
		private string genero;
		private string creador;

		public Serie() { }

		public Serie(string titulo, string creador)
		{
			this.titulo = titulo;
			this.creador = creador;
		}

		public Serie(string titulo, int cantTemp, string genero, string creador)
		{
			this.titulo = titulo;
			this.cantTemp = cantTemp;
			this.genero = genero;
			this.creador = creador;
		}

		public string Titulo
		{
			get
			{
				return this.titulo;
			}
		}

		public int CantTemp
		{
			get
			{
				return this.cantTemp;
			}
		}

		public string Genero
		{
			get
			{
				return this.genero;
			}
		}

		public string Creador
		{
			get
			{
				return this.creador;
			}
		}

		public void setTitulo(string titulo)
		{
			this.titulo = titulo;
		}

		public void setCantTemp(int cantTemp)
		{
			this.cantTemp = cantTemp;
		}

		public void setGenero(string genero)
		{
			this.genero = genero;
		}

		public void setCreador(string creador)
		{
			this.creador = creador;
		}

		public bool entregar()
		{
			return entregado = true;
		}

		public bool devolver()
		{
			return entregado = false;
		}

		public bool isEntregado()
		{
			return entregado;
		}

		public int compareTo(Object a)
		{
			Serie v = (Serie)a;
			if (this.cantTemp < v.cantTemp)
			{
				return -1;
			}
			else if (this.cantTemp > v.cantTemp)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}

	class Videojuego : IEntregable
	{
		private string titulo;
		private int horasEstimadas = 10;
		private bool entregado = false;
		private string genero;
		private string compania;

		public Videojuego() { }

		public Videojuego(string titulo, int horasEstimadas)
		{
			this.titulo = titulo;
			this.horasEstimadas = horasEstimadas;
		}

		public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
		{
			this.titulo = titulo;
			this.horasEstimadas = horasEstimadas;
			this.genero = genero;
			this.compania = compania;
		}

		public string Titulo
		{
			get
			{
				return this.titulo;
			}
		}

		public int HorasEstimadas
		{
			get
			{
				return this.horasEstimadas;
			}
		}

		public string Genero
		{
			get
			{
				return this.genero;
			}
		}

		public string Compania
		{
			get
			{
				return this.compania;
			}
		}

		public void setTitulo(string titulo)
		{
			this.titulo = titulo;
		}

		public void setHorasEstimadas(int horasEstimadas)
		{
			this.horasEstimadas = horasEstimadas;
		}

		public void setGenero(string genero)
		{
			this.genero = genero;
		}

		public void setCompania(string compania)
		{
			this.compania = compania;
		}

		public bool entregar()
		{
			return entregado = true;
		}

		public bool devolver()
		{
			return entregado = false;
		}

		public bool isEntregado()
		{
			return entregado;
		}

		public int compareTo(Object a)
		{
			Videojuego v = (Videojuego)a;
			if (horasEstimadas < v.horasEstimadas)
			{
				return -1;
			}
			else if (horasEstimadas > v.horasEstimadas)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Serie[] series = new Serie[5];

			series[0] = new Serie("Salame", 3, "Fiambreria", "Don Tito");
			series[1] = new Serie("Moon Knight", 1, "Accion", "Doug Moench");
			series[2] = new Serie("Mortadela", 4, "Fiambre", "Caballo");
			series[3] = new Serie("Silla", 1, "Madera", "Jose Carpintero");
			series[4] = new Serie("a", 2, "a", "a");

			Videojuego[] videojuegos = new Videojuego[5];

			videojuegos[0] = new Videojuego("Burger time", 5);
			videojuegos[1] = new Videojuego("Genshin Impact", 1, "Aventura", "Mihoyo");
			videojuegos[2] = new Videojuego("Free fire", 7);
			videojuegos[3] = new Videojuego("a", 1);
			videojuegos[4] = new Videojuego("Angry Birds", 4, "Puzzle", " Rovio Entertainment");

			int cant = 0;

			for (int i = 0; i < series.Length; i++)
			{
				if (i / 2 == 0)
				{
					series[i].entregar();
					videojuegos[i].entregar();
					cant++;
				}
			}

			Console.SetCursorPosition(1, 1);
			Console.Write("Videojuegos entregados: " + cant);

			Console.SetCursorPosition(1, 6);
			Console.Write("Series entregadas: " + cant);

			for (int i = 0; i < series.Length; i++)
			{
				if (videojuegos[i].isEntregado() == true)
				{
					Console.SetCursorPosition(1, 3 + i);
					Console.Write("Titulo: " + videojuegos[i].Titulo + " Horas estimadas: " + videojuegos[i].HorasEstimadas + " Genero: " + videojuegos[i].Genero + " Compañia: " + videojuegos[i].Compania);
				}
				if (series[i].isEntregado() == true)
				{
					Console.SetCursorPosition(1, 8 + i);
					Console.Write("Titulo: " + series[i].Titulo + " Cantidad de temporadas: " + series[i].CantTemp + " Genero: " + series[i].Genero + " Creador: " + series[i].Creador);
				}

			}

			int max = 0;

			for (int i = 0; i < videojuegos.Length; i++)
			{
				if (videojuegos[i].compareTo(videojuegos[max]) == 1)
				{
					max = i;
				}
			}

			int max2 = 0;

			for (int i = 0; i < series.Length; i++)
			{
				if (series[i].compareTo(series[max2]) == 1)
				{
					max2 = i;
				}
			}
			Console.SetCursorPosition(1, 11);
			Console.WriteLine("Videojuego con mas horas estimadas");
			Console.WriteLine(" Titulo: " + videojuegos[max].Titulo + " Horas estimadas: " + videojuegos[max].HorasEstimadas + " Genero: " + videojuegos[max].Genero + " Compañia: " + videojuegos[max].Compania);

			Console.SetCursorPosition(1, 14);
			Console.WriteLine("Serie con mas temporadas");
			Console.Write(" Titulo: " + series[max2].Titulo + " Cantidad de temporadas: " + series[max2].CantTemp + " Genero: " + series[max2].Genero + " Creador: " + series[max2].Creador);


			Console.Read();

		}
	}
}