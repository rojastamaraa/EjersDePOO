using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjOb12
{
	class Revolver
	{
		public int posicionActual;
		public int posicionBala;

		public Revolver(Random r)
		{
			posicionActual = r.Next(1,6);
			posicionBala = r.Next(1,6);
		}

		public bool disparar()
		{
			siguienteBala();
			if (posicionActual == posicionBala)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void siguienteBala()
		{
			if (posicionActual + 1 > 6)
			{
				posicionActual = 1;
			}
			else
			{
				posicionActual = posicionActual + 1;
			}
		}
	}

	class Jugador
	{
		public int ID;
		public string nombre;
		public bool vivo;

		public Jugador(int ID, string nombre)
		{
			this.ID = ID;
			this.nombre = nombre;
			vivo = true;
		}

		public void disparar(Revolver r)
		{
			bool d = r.disparar();
			if (d == true)
			{
				vivo = false;
			}
		}
	}

	class Jugadores
	{
		public List<Jugador> j;
		public Revolver r;

		public Jugadores(List<Jugador> j, Revolver r)
		{
			this.j = j;
			this.r = r;
		}

		public bool finJuego(Jugador j)
		{
			if (j.vivo == false)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool ronda(Jugador j, Revolver r)
		{
			j.disparar(r);
			return finJuego(j);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Random rr = new Random();
			List<Jugador> j = new List<Jugador>();
			Revolver r = new Revolver(rr);

			Console.CursorVisible = false;

			Console.SetCursorPosition(45, 13);
			Console.Write("Ingrese cantidad de jugadores: ");
			int cant = int.Parse(Console.ReadLine());

			if (cant < 1 || cant > 6)
			{
				cant = 6;
			}

			for (int i = 0; i < cant; i++)
			{
				j.Add(new Jugador(i, "Jugador" + (i + 1)));
			}

			Jugadores js = new Jugadores(j, r);

			Console.Clear();
			Console.SetCursorPosition(45, 13);
			Console.Write("Presione Enter para disparar");
			
			bool fin = false;
			int jugadorActual = 0;

			while (fin == false)
			{

				ConsoleKeyInfo tecla = Console.ReadKey(true);

				Console.Clear();

				if (tecla.Key == ConsoleKey.Enter)
				{
					Console.Clear();

					bool estado = js.ronda(j[jugadorActual], r);
					//Console.WriteLine("Posicion actual: " + r.posicionActual + " Posicion de la bala: " + r.posicionBala);

					if (estado == true)
					{
						for (int i = 0; i < 2; i++)
						{
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.Red;
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.White;
							Console.Clear();
							Console.BackgroundColor = ConsoleColor.Yellow;						
						}
	
						Console.BackgroundColor = ConsoleColor.Black;
						Console.Clear();
						Console.SetCursorPosition(45, 13);
						Console.ForegroundColor = ConsoleColor.Red;
						string mensaje = "El " + j[jugadorActual].nombre + " se disparo y murio";
						for (int i = 0; i < mensaje.Length; i++)
						{
							Console.SetCursorPosition(45 + i, 13);
							Console.Write(mensaje[i]);
							Thread.Sleep(60);
						}

						for (int i = 0; i < 28; i++)
						{
							Console.BackgroundColor = ConsoleColor.Red;
							Console.SetCursorPosition(0, 0 + i);
							Console.WriteLine("                                                                                                                        ");
							Thread.Sleep(100);
						}

						Console.SetCursorPosition(55, 13);
						Console.ForegroundColor = ConsoleColor.Black;
						Console.WriteLine("Fin del juego");

						fin = true;
					}
					else
					{
						Console.SetCursorPosition(43, 13);
						Console.WriteLine("El " + j[jugadorActual].nombre + " se disparo y no habia bala");
					}

					if (jugadorActual + 1 >= cant)
					{
						jugadorActual = 0;
					}
					else
					{
						jugadorActual = jugadorActual + 1;
					}
				}
			}
			Console.Read();
		}
	}
}
