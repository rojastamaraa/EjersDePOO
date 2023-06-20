using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb9
{
	class Cine
	{
		public Pelicula pelicula;
		public int entrada;

		public Cine(Pelicula p, Random r)
		{
			pelicula = p;
			entrada = r.Next(1000,3000);
		}

		public List<Espectador> aptosPelicula(List<Espectador> e)
		{
			List<Espectador> ep = new List<Espectador>();
			for (int i = 0; i < e.Count; i++)
			{
				if (e[i].edad >= pelicula.edadMin && e[i].dinero >= entrada)
				{
					ep.Add(e[i]);
				}
			}
			return ep;
		}

	}

	class Sala
	{
		public Espectador[,] asientos;

		public Sala()
		{
			asientos = new Espectador[8, 9];
		}

	}

	class Pelicula
	{
		public string titulo;
		public string duracion;
		public int edadMin;
		public string director;

		public Pelicula(Random r)
		{
			infoPelicula(r);
		}

		public void infoPelicula(Random r)
		{
			string[] nombresPeliculas = new string[]
			{
				"El padrino", "Titanic", "Pulp Fiction", "El señor de los anillos", "La vida es bella",
				"La lista de Schindler", "Forrest Gump", "El caballero oscuro", "El resplandor", "Gladiador",
				"Cadena perpetua", "El gran Lebowski", "Interestelar", "El sexto sentido", "El club de la pelea",
				"Matrix", "El rey león", "Memento", "Blade Runner", "El silencio de los corderos"
			};
			string[] directores = new string[]
			{
				"Francis Ford Coppola", "James Cameron", "Quentin Tarantino", "Peter Jackson", "Roberto Benigni",
				"Steven Spielberg", "Robert Zemeckis", "Christopher Nolan", "Stanley Kubrick", "Ridley Scott",
				"Frank Darabont", "Joel Coen y Ethan Coen", "Christopher Nolan", "M. Night Shyamalan", "David Fincher",
				"The Wachowski Brothers", "Roger Allers y Rob Minkoff", "Christopher Nolan", "Ridley Scott", "Jonathan Demme"
			};
			while (true)
			{
				titulo = nombresPeliculas[r.Next(0, nombresPeliculas.Length)];
				duracion = r.Next(1, 3) + ":" + r.Next(0, 60);
				edadMin = r.Next(5, 18);
				director = directores[r.Next(0, directores.Length)];
				break;
			}

		}
	}

	class Espectador
	{
		public string nombre;
		public int edad;
		public double dinero;

		public Espectador(Random r)
		{
			infoEspectador(r);
		}

		public void infoEspectador(Random r)
		{
			string[] nombres = { "Angus", "Bon", "Celeste", "Joan", "Gustavo", "Julian", "Sid", "Brian", "Steven", "Charly", "Fito", "Lucas", "Michael", "Claudia", "Adrian", "Luis", "Fabiana", "John", "Ozzy", "Grover", "Indio", "Ciro", "Johnny", "Axl" };
			while (true)
			{
				nombre = nombres[r.Next(0, nombres.Length)];
				edad = r.Next(5, 99);
				dinero = r.Next(1000, 3000);
				break;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Random r = new Random();
			Pelicula pelicula = new Pelicula(r);
			Cine cine = new Cine(pelicula, r);
			Sala sala = new Sala();
			List<Espectador> e = new List<Espectador>();
			List<Espectador> e2 = new List<Espectador>();

			for (int i = 0; i < sala.asientos.Length; i++)
			{
				e.Add(new Espectador(r));
				e2 = cine.aptosPelicula(e);
			}

			Console.SetCursorPosition(45, 1);
			Console.WriteLine(pelicula.titulo);
			Console.SetCursorPosition(45, 2);
			Console.WriteLine("Duracion: " + pelicula.duracion);
			Console.SetCursorPosition(45, 3);
			Console.WriteLine("Edad Minima: " + pelicula.edadMin);
			Console.SetCursorPosition(45, 4);
			Console.WriteLine("Entrada: " + cine.entrada);

			//Console.SetCursorPosition(45, 5);
			//Console.WriteLine(e.Count);
			//Console.SetCursorPosition(45, 6);
			//Console.WriteLine(e2.Count);

			//for (int i = 0; i < e2.Count; i++)
			//{
			//	Console.WriteLine("Nombre: " + e2[i].nombre + " Edad: " + e2[i].edad + " Dinero: " + e2[i].dinero);
			//}

			int especSentados = 0;
			for (int i = 0; i < e2.Count; i++)
			{
				while (especSentados < e2.Count)
				{
					int f = r.Next(0, 8);
					int c = r.Next(0, 9);
					if (sala.asientos[f, c] == null)
					{
						sala.asientos[f, c] = e2[i];
						especSentados++;
					}
				}
			}

			string[,] a = new string[8, 9]
			{
				{"8A", "8B", "8C", "8D", "8E", "8F", "8G", "8H", "8I"},
				{"7A", "7B", "7C", "7D", "7E", "7F", "7G", "7H", "7I"},
				{"6A", "6B", "6C", "6D", "6E", "6F", "6G", "6H", "6I"},
				{"5A", "5B", "5C", "5D", "5E", "5F", "5G", "5H", "5I"},
				{"4A", "4B", "4C", "4D", "4E", "4F", "4G", "4H", "4I"},
				{"3A", "3B", "3C", "3D", "3E", "3F", "3G", "3H", "3I"},
				{"2A", "2B", "2C", "2D", "2E", "2F", "2G", "2H", "2I"},
				{"1A", "1B", "1C", "1D", "1E", "1F", "1G", "1H", "1I"}
			};

			Console.SetCursorPosition(45, 10);
			for (int i = 0; i < 8; i++)
			{
				Console.SetCursorPosition(45, 10 + i);
				for (int i2 = 0; i2 < 9; i2++)
				{
					if (i2 == 8)
					{
						if (sala.asientos[i, i2] != null)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine(a[i, i2]);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine(a[i, i2]);
						}
					}
					else
					{
						if (sala.asientos[i, i2] != null)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write(a[i, i2] + " ");
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.Green;
							Console.Write(a[i, i2] + " ");
						}
					}
				}
			}

			Console.Read();
		}
	}
}