using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Listas_ejer1
{

	class Persona
	{
		public string nombre;
		public string apellido;

		public Persona (string nombre, string apellido)
		{
			this.nombre = nombre;
			this.apellido = apellido;
		}

		public static void natos(List<Persona> personas, Random random)
		{
			string[] nombres = { "Angus", "Bon", "Celeste", "Joan", "Gustavo", "Julian", "Sid", "Brian", "Steven", "Charly", "Fito", "Lucas", "Michael", "Claudia", "Adrian", "Luis" };
			string[] apellidos = { "Young", "Scott", "Carballo", "Jett", "Cerati", "Casablancas", "Vicious", "May", "Morrisey", "Garcia", "Paez", "Prodan", "Jackson", "Puyo", "Dargelos", "Spinetta" };

			while(true)
			{
				int nom = random.Next(0, nombres.Length);
				int ape = random.Next(0, apellidos.Length);
				Persona nuevo = new Persona(nombres[nom], apellidos[ape]);

				lock (personas)
				{
					personas.Add(nuevo);
				}

				Thread.Sleep(1000);
			}

		}

		public static void fallecidos(List<Persona> personas, Random random)
		{
			while(true)
			{
				int chau = random.Next(0, personas.Count);

				lock (personas)
				{
					personas.Remove(personas[chau]);
				}

				Thread.Sleep(2000);
			}

		}

	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Persona> personas = new List<Persona>();

			Random random = new Random();

			Console.WriteLine("Poblacion Argentina: " + personas.Count);

			Thread natosThread = new Thread(() => Persona.natos(personas, random));
			natosThread.Start();

			Thread fallecidosThread = new Thread(() => Persona.fallecidos(personas, random));
			fallecidosThread.Start();

			while (true)
			{
				Thread.Sleep(10000);
				lock (personas)
				{
					Console.Clear();
					Console.WriteLine("Poblacion Argentina: " + personas.Count);
					for (int i = 0; i < personas.Count; i++)
					{
						Console.WriteLine(personas[i].nombre + " " + personas[i].apellido);
					}
				}
				int cant = personas.Count;
				Thread.Sleep(5000);
				Console.Clear();
				Console.WriteLine("Poblacion Argentina: " + cant);
			}
		}
	}
}