using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjOb2
{
	class Persona
	{
		private string nombre = "";
		private int edad = 0;
		private int DNI;
		private char sexo = sexoDefecto;
		private double peso = 61;
		private double altura = 1.90;

		private const char sexoDefecto = 'H';

		public Persona()
		{
			while (true)
			{
				Thread.Sleep(100);
				DNI = generarDNI();
				break;
			}
		}
		public Persona(string nombre, int edad, char sexo)
		{
			this.nombre = nombre;
			this.edad = edad;
			comprobarSexo(sexo);
			while (true)
			{
				Thread.Sleep(200);
				DNI = generarDNI();
				break;
			}
		}
		public Persona(string nombre, int edad, char sexo, double peso, double altura)
		{
			this.nombre = nombre;
			this.edad = edad;
			while (true)
			{
				Thread.Sleep(300);
				DNI = generarDNI();
				break;
			}
			comprobarSexo(sexo);
			this.peso = peso;
			this.altura = altura;
		}

		public int calcularIMC()
		{
			double pesso = peso / (altura * altura);
			if (pesso < 20)
			{
				return -1;
			}
			else if (pesso >= 20 && pesso <= 25)
			{
				return 0;
			}
			return 1;
		}

		public bool esMayor()
		{
			if (edad >= 18)
			{
				return true;
			}
			return false;
		}

		private void comprobarSexo(char sexo)
		{
			if (sexo == 'H' || sexo == 'M')
			{
				this.sexo = sexo;
			}
			else
			{
				this.sexo = sexoDefecto;
			}
		}

		private int generarDNI()
		{
			Random r = new Random();
			int dni = r.Next(10000000, 99999999);
			return dni;
		}


		public string getNombre()
		{
			return nombre;
		}

		public int getEdad()
		{
			return edad;
		}

		public char getSexo()
		{
			return sexo;
		}

		public double getPeso()
		{
			return peso;
		}

		public double getAltura()
		{
			return altura;
		}

		public int getDNI()
		{
			return DNI;
		}


		public void setNombre(string nombre)
		{
			this.nombre = nombre;
		}

		public void setEdad(int edad)
		{
			this.edad = edad;
		}

		public void setSexo(char sexo)
		{
			this.sexo = sexo;
		}

		public void setPeso(double peso)
		{
			this.peso = peso;
		}

		public void setAltura(double altura)
		{
			this.altura = altura;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<Persona> personas = new List<Persona>();

			Console.WriteLine("Ingrese el nombre");
			string n = Console.ReadLine();
			Console.WriteLine("Ingrese la edad");
			int e = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el sexo (H o M)");
			char s = char.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el peso en kgs");
			double p = double.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese la altura en cm");
			double a = double.Parse(Console.ReadLine());

			personas.Add(new Persona(n, e, s, p, a / 100));

			Console.WriteLine("Ingrese el nombre");
			string n2 = Console.ReadLine();
			Console.WriteLine("Ingrese la edad");
			int e2 = int.Parse(Console.ReadLine());
			Console.WriteLine("Ingrese el sexo (H o M)");
			char s2 = char.Parse(Console.ReadLine());
			personas.Add(new Persona(n2, e2, s2));
			personas.Add(new Persona());

			personas[2].setNombre("David");
			personas[2].setEdad(69);
			personas[2].setSexo('H');
			personas[2].setPeso(80);
			personas[2].setAltura(1.78);

			for (int i = 0; i < personas.Count; i++)
			{
				double r = personas[i].calcularIMC();
				if (r == -1)
				{
					Console.WriteLine("La persona " + i + " tiene bajo peso");
				}
				else if (r == 0)
				{
					Console.WriteLine("La persona " + i + " esta en su peso ideal");
				}
				else
				{
					Console.WriteLine("La persona " + i + " tiene sobre peso");
				}
			}


			for (int i = 0; i < personas.Count; i++)
			{
				if (personas[i].esMayor() == true)
				{
					Console.WriteLine(personas[i].getNombre() + " es mayor de edad");
				}
				else
				{
					Console.WriteLine(personas[i].getNombre() + " es menor de edad");

				}
			}

			for (int i = 0; i < personas.Count; i++)
			{
				Console.WriteLine("Nombre: " + personas[i].getNombre() + " Edad: " + personas[i].getEdad() + " DNI: " + personas[i].getDNI() + " Sexo: " + personas[i].getSexo() + " Peso: " + personas[i].getPeso() + "kgs Altura: " + personas[i].getAltura());
			}

			Console.ReadKey();
		}
	}
}