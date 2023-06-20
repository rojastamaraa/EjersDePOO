using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb7
{
	class Raices
	{
		public double a;
		public double b;
		public double c;

		public Raices(double a, double b, double c)
		{
			this.a = a;
			this.b = b;
			this.c = c;
		}


		public string obtenerRaices()
		{
			if (tieneRaices() == true)
			{
				double d = getDiscriminante();
				double x1 = (-b + Math.Sqrt(d)) / (2 * a);
				double x2 = (-b - Math.Sqrt(d)) / (2 * a);
				return "Valor 1: " + x1 + " Valor 2: " + x2;
			}
			return null;
		}

		public string obtenerRaiz()
		{
			if (tieneRaiz() == true)
			{
				double d = getDiscriminante();
				double x1 = (-b + Math.Sqrt(d)) / (2 * a);
				double x2 = (-b - Math.Sqrt(d)) / (2 * a);
				if (x1 == x2)
				{
					return "Valor 1: " + x1;
				}
				else
				{
					return null;
				}
			}
			return null;
		}

		public double getDiscriminante()
		{
			double discriminante = (b*b) - (4*a*c);
			return discriminante;
		}

		public bool tieneRaices()
		{
			double d = getDiscriminante();
			if(d > 0)
			{
				return true;
			}
			return false;
		}

		public bool tieneRaiz()
		{
			double d = getDiscriminante();
			if (d == 0)
			{
				return true;
			}
			return false;
		}

		public string calcular()
		{
			if (tieneRaices() == true)
			{
				if (obtenerRaices() != null)
				{
					return obtenerRaices();
				}
			}
			else if(tieneRaiz() == true)
			{
				if (obtenerRaiz() != null)
				{
					return obtenerRaiz();
				}
			}
			return null;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			Raices raiz = new Raices(1, 4, 4);

			string r = raiz.calcular();

			if(r == null)
			{
				Console.WriteLine("La ecuacion no posee raices");
			}
			else
			{
				Console.WriteLine(r);
			}

			Console.ReadKey();
		}
	}
}
