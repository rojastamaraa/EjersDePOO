using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjOb10
{
	class Baraja
	{
		public List<Carta> baraja;
		public List<Carta> monton;
		public static Random r = new Random();

		public Baraja()
		{
			baraja = new List<Carta>();
			monton = new List<Carta>();
			cartas();
		}

		private void cartas()
		{
			int[] valores = { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12};
			string[] palo = { "espada", "basto", "oro", "copas"};

			for (int i = 0; i < palo.Length; i++)
			{
				for (int j = 0; j < valores.Length; j++)
				{
					Carta c = new Carta(valores[j], palo[i]);
					baraja.Add(c);
				}
			}
		}

		public void barajar()
		{
			for (int i = 0; i < baraja.Count; i++)
			{
				int indice = r.Next(0, baraja.Count);
				Carta cc = baraja[indice];
				baraja.Insert(i, cc);
				baraja.Remove(cc);

			}
		}

		public Carta siguienteCarta()
		{
			if (baraja.Count > 0)
			{
				Carta ca = baraja[0];
				monton.Add(ca);
				baraja.Remove(ca);
				return ca;
			}
			else
			{
				return null;
			}
		}

		public int cartasDisponibles()
		{
			return baraja.Count;
		}

		public List<Carta> darCartas(int peticion)
		{
			List<Carta> cartass = new List<Carta>();
			if (cartasDisponibles() >= peticion)
			{
				for (int i = 0; i < peticion; i++)
				{
					cartass.Add(siguienteCarta());
				}
			}
			else
			{
				return null;
			}
			return cartass;
		}

		public List<Carta> cartasMonton()
		{
			if (monton.Count > 0)
			{
				return monton;
			}
			else
			{
				return null;
			}
		}

		public void mostrarBaraja(List<Carta> baraja)
		{
			for (int i = 0; i < baraja.Count; i++)
			{
				Console.SetCursorPosition(50, i + 1);
				Console.BackgroundColor = ConsoleColor.Black;
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Palo: " + baraja[i].palo + " Valor: " + baraja[i].valor);
			}
		}
	}

	class Carta
	{
		public int valor;
		public string palo;

		public Carta(int valor, string palo)
		{
			this.valor = valor;
			this.palo = palo;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Baraja b = new Baraja();
			string[] menu =
			{
				"	     Barajar	    ",
				"	  Siguiente Carta   ",
				"	Cartas Disponibles  ",
				"      Dar cartas       ",
				"	     Monton         ",
				"	  Mostrar baraja    " 
			};

			bool salir = false;
			int pos = 0;
			Console.CursorVisible = false;

			for (int i = 0; i < menu.Length; i++)
			{
				if (i == 0)
				{
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.SetCursorPosition(5, i + 1);
				Console.Write(menu[i]);
			}
			while (!salir)
			{
				//COMIENZO MENU
				ConsoleKeyInfo tecla = Console.ReadKey(true);
				if (tecla.Key == ConsoleKey.DownArrow && pos < 5)
				{
					Console.SetCursorPosition(5, pos + 1);
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(menu[pos]);
					pos++;
					Console.SetCursorPosition(5, pos + 1);
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write(menu[pos]);
				}
				if (tecla.Key == ConsoleKey.UpArrow && pos >  0)
				{
					Console.SetCursorPosition(5, pos + 1);
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(menu[pos]);
					pos = pos - 1;
					Console.SetCursorPosition(5, pos + 1);
					Console.BackgroundColor = ConsoleColor.Gray;
					Console.ForegroundColor = ConsoleColor.Black;
					Console.Write(menu[pos]);
				}
				//FIN MENU
		
				if (tecla.Key == ConsoleKey.Enter && pos == 0)
				{
					Console.Clear();
					b.barajar();
					b.barajar();
					b.barajar();
					b.mostrarBaraja(b.baraja);
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 1)
				{
					Console.SetCursorPosition(50, 1);
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
					Carta car = b.siguienteCarta();
					if (car != null)
					{
						Console.WriteLine("Palo: " + car.palo + " Valor: " + car.valor);
					}
					else
					{
						Console.WriteLine("No hay mas cartas");
					}
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 2)
				{
					int cartatas = b.cartasDisponibles();
					Console.SetCursorPosition(50, 1);
					Console.BackgroundColor = ConsoleColor.Black;
					Console.ForegroundColor = ConsoleColor.White;
					if (cartatas > 0)
					{
						Console.WriteLine("Cartas disponibles: " + cartatas);
					}
					else
					{
						Console.WriteLine("No hay cartas disponibles");
					}
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 3)
				{

				}
				if (tecla.Key == ConsoleKey.Enter && pos == 4)
				{
					List<Carta> mon = b.cartasMonton();
					if (mon != null)
					{
						b.mostrarBaraja(b.monton);
					}
					else
					{
						Console.SetCursorPosition(50, 1);
						Console.BackgroundColor = ConsoleColor.Black;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("No hay cartas en el monton");
					}
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 5)
				{
					b.mostrarBaraja(b.baraja);
				}
			}
		}
	}
}
