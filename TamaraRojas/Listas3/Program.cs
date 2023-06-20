using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Listas3
{

	class Persona
	{
		public string nombre;
		public string apellido;
		public string nacionalidad;

		public Persona(string nombre, string apellido, string nacionalidad)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.nacionalidad = nacionalidad;
		}

		public static void natos(List<Persona> personas, Random random)
		{
			string[] nombres = { "Angus", "Bon", "Celeste", "Joan", "Gustavo", "Julian", "Sid", "Brian", "Steven", "Charly", "Fito", "Lucas", "Michael", "Claudia", "Adrian", "Luis" };
			string[] apellidos = { "Young", "Scott", "Carballo", "Jett", "Cerati", "Casablancas", "Vicious", "May", "Morrisey", "Garcia", "Paez", "Prodan", "Jackson", "Puyo", "Dargelos", "Spinetta" };
			string[] nac = { "Argentina", "Paraguay", "Brasil" };

			while (true)
			{
				int nom = random.Next(0, nombres.Length);
				int ape = random.Next(0, apellidos.Length);
				int naci = random.Next(0, nac.Length);
				int temp = random.Next(0, 30);

				Persona p = new Persona(nombres[nom], apellidos[ape], nac[naci]);

				lock (personas)
				{
					personas.Add(p);
				}
				Thread.Sleep(temp * 1000);
			}

		}

		public static void fallecidos(List<Persona> personas, Random random)
		{

			while (true)
			{
				int chau = random.Next(0, personas.Count);
				lock (personas)
				{
					personas.Remove(personas[chau]);
				}
				Thread.Sleep(60000);
			}

		}

		public static void thanos(List<Persona> personas, Random random)
		{
			string[] pais = { "Argentina", "Paraguay", "Brasil" };
			while (true)
			{
				int cero = random.Next(0, pais.Length);
				lock (personas)
				{
					for (int i = 0; i < personas.Count; i++)
					{
						if (personas[i].nacionalidad == pais[cero])
						{
							personas.Remove(personas[i]);
						}
					}
				}
				Thread.Sleep(120000);
			}
		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Persona> personas = new List<Persona>();
			Random random = new Random();

			Console.CursorVisible = false;

			Console.SetCursorPosition(1, 1);
			Console.WriteLine("Argentina: 0");
			Console.SetCursorPosition(40, 1);
			Console.WriteLine("Paraguay: 0");
			Console.SetCursorPosition(80, 1);
			Console.WriteLine("Brasil: 0");

			Thread natosThread = new Thread(() => Persona.natos(personas, random));
			natosThread.Start();

			Thread fallecidosThread = new Thread(() => Persona.fallecidos(personas, random));
			fallecidosThread.Start();

			Thread thanosThread = new Thread(() => Persona.thanos(personas, random));
			thanosThread.Start();

			while (true)
			{

				Thread.Sleep(10000);
				Console.Clear();
				int arg = 0;
				int par = 0;
				int bra = 0;

				lock (personas)
				{
					var alfaArg = personas.Where(p => p.nacionalidad == "Argentina").OrderBy(p => p.apellido).ToList();
					var alfaPar = personas.Where(p => p.nacionalidad == "Paraguay").OrderBy(p => p.apellido).ToList();
					var alfaBra = personas.Where(p => p.nacionalidad == "Brasil").OrderBy(p => p.apellido).ToList();

					if (alfaArg.Count == 0)
					{
						Console.SetCursorPosition(1, 1);
						Console.WriteLine("Argentina: " + 0);
					}
					else
					{
						for (int i = 0; i < alfaArg.Count; i++)
						{
							arg++;
							Console.SetCursorPosition(1, 1);
							Console.WriteLine("Argentina: " + arg);
							Console.SetCursorPosition(1, 2 + arg);
							Console.WriteLine(alfaArg[i].apellido + " " + alfaArg[i].nombre);
						}
					}
					if (alfaPar.Count == 0)
					{
						Console.SetCursorPosition(40, 1);
						Console.WriteLine("Paraguay: " + 0);
					}
					else
					{
						for (int i = 0; i < alfaPar.Count; i++)
						{
							par++;
							Console.SetCursorPosition(40, 1);
							Console.WriteLine("Paraguay: " + par);
							Console.SetCursorPosition(40, 2 + par);
							Console.WriteLine(alfaPar[i].apellido + " " + alfaPar[i].nombre);
						}
					}

					if (alfaBra.Count == 0)
					{
						Console.SetCursorPosition(80, 1);
						Console.WriteLine("Brasil: " + 0);
					}
					else
					{
						for (int i = 0; i < alfaBra.Count; i++)
						{
							bra++;
							Console.SetCursorPosition(80, 1);
							Console.WriteLine("Brasil: " + bra);
							Console.SetCursorPosition(80, 2 + bra);
							Console.WriteLine(alfaBra[i].apellido + " " + alfaBra[i].nombre);
						}
					}

				}

				int canta = arg;
				int cantp = par;
				int cantb = bra;
				Thread.Sleep(5000);
				Console.Clear();
				Console.SetCursorPosition(1, 1);
				Console.WriteLine("Argentina: " + canta);
				Console.SetCursorPosition(40, 1);
				Console.WriteLine("Paraguay: " + cantp);
				Console.SetCursorPosition(80, 1);
				Console.WriteLine("Brasil: " + cantb);

			}

		}
	}
}