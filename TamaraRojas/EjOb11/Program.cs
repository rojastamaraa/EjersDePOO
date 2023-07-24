using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb11
{
	interface Interfaz
	{
		void info(Random r);
	}

	class Apuesta : Interfaz
	{
		public int resultado;
		public int pozo;

		public Apuesta(Random r)
		{
			info(r);
		}

		public void info(Random r)
		{
			resultado = r.Next(1, 10);
		}

		public bool resultados(List<Participante> p)
		{
			for (int i = 0; i < p.Count; i++)
			{
				pozo = pozo + 1;
			}

			for (int i = 0; i < p.Count; i++)
			{
				if (p[i].resultado == resultado)
				{
					p[i].vecesGanadas = p[i].vecesGanadas + 1;
					return true;
				}
			}
			return false;
		}

		public bool juegoFinalizado(List<Participante> p)
		{
			for (int i = 0; i < p.Count; i++)
			{
				if (p[i].vecesGanadas == 2)
				{
					p[i].dinero = p[i].dinero + pozo;
					pozo = 0;
					return true;
				}
			}
			return false;
		}
	}

	class Participante
	{
		public int resultado;
		public int dinero;
		public int vecesGanadas;

		public Participante(Random r)
		{
			info(r);
		}

		public void info(Random r)
		{
			dinero = r.Next(5,20);
		}

		public void apostar(Random r)
		{
			if (dinero > 0)
			{
				resultado = r.Next(1, 10);
				dinero = dinero - 1;
			}
			else
			{
				//el resultado es cero entonces no participa de la apuesta B)
				resultado = 0;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Random r = new Random();
			Apuesta a = new Apuesta(r);
			List<Participante> p = new List<Participante>();
			for (int i = 0; i < 5; i++)
			{
				p.Add(new Participante(r));
			}

			Console.WriteLine("Resultado: " + a.resultado + " Pozo: " + a.pozo);

			bool juego = false;
			while (juego == false)
			{
				ConsoleKeyInfo tecla = Console.ReadKey(true);
				if (tecla.Key == ConsoleKey.Enter)
				{
					Console.Clear();
					Console.WriteLine("Resultado: " + a.resultado + " Pozo: " + a.pozo);
					for (int i = 0; i < p.Count; i++)
					{
						p[i].apostar(r);
					}

					a.resultados(p);
					bool aa = a.juegoFinalizado(p);
					if (aa == true)
					{
						Console.Clear();
						Console.WriteLine("Resultado: " + a.resultado + " Pozo: " + a.pozo);
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine("¡¡¡Hubo un ganador!!!");
						for (int i = 0; i < p.Count; i++)
						{
							Console.ForegroundColor = ConsoleColor.White;
							Console.WriteLine("Jugador: " + i + " Resultado: " + p[i].resultado + " Dinero: " + p[i].dinero + " Veces ganadas: " + p[i].vecesGanadas);
						}
						juego = true;
					}
					else
					{
						Console.Clear();
						Console.WriteLine("Resultado: " + a.resultado + " Pozo: " + a.pozo);
						Console.WriteLine("Aun no hay ganadores");
						for (int i = 0; i < p.Count; i++)
						{
							if (p[i].dinero > 0)
							{
								Console.WriteLine("Jugador: " + i + " Resultado: " + p[i].resultado + " Dinero: " + p[i].dinero + " Veces ganadas: " + p[i].vecesGanadas);
							}
							else
							{
								Console.WriteLine("Jugador: " + i + " ya no participa debido a que se quedo sin dinero");
							}
						}
					}
					a.info(r);
				}
			}

			Console.Read();
		}
	}
}
