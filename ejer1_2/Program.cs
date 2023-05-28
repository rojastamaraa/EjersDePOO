using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer1_2
{
	class Program
	{

		public static void antes10(List<int> numeros)
		{
			for (int i = 0; i < numeros.Count(); i++)
			{
				if (numeros[i] == 10)
				{
					numeros.Insert(i, 0);
					i++;

				}

			}
		}

		public static void despues10(List<int> numeros)
		{
			for (int i = 0; i < numeros.Count(); i++)
			{
				if (numeros[i] == 10)
				{
					numeros.Insert(i + 1, 0);
					i++;
				}
			}
		}

		public static void antesydespues10(List<int> numeros)
		{
			for (int i = 0; i < numeros.Count(); i++)
			{
				if (numeros[i] == 10)
				{
					numeros.Insert(i, 0);
					numeros.Insert(i + 2, 0);
					i = i + 2;
				}
			}
		}

		public static void eliminar1(List<int> numeros)
		{
			numeros.RemoveAt(0);
			numeros.RemoveAt(numeros.Count() - 1);
		}

		public static void eliminar2(List<int> numeros)
		{
			numeros.RemoveAt(1);
			numeros.RemoveAt(numeros.Count() - 2);
		}

		public static void mostar(List<int> numeros)
		{
			for (int i = 0; i < numeros.Count(); i++)
			{
				Console.WriteLine(numeros[i]);
			}
		}

		static void Main(string[] args)
		{

			List<int> numeros = new List<int> { 34234, 234, 3, 10, 243243, 130, 23423, 10, 13234, 234, 234, 10, 123 };

			//METODO PARA PONER 0 ANTES

			antes10(numeros);
			despues10(numeros);
			antesydespues10(numeros);

			eliminar1(numeros);
			eliminar2(numeros);

			mostar(numeros);

			Console.ReadKey();
		}
	}
}
