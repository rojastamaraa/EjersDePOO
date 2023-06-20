using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjOb3
{
	class Password
	{
		private int longitud = 8;
		private string contrasenia;

		public Password() { }
		public Password(int longitud)
		{
			this.longitud = longitud;
			contrasenia = generarPassword();
		}

		public string generarPassword()
		{
			string[] letrasnums = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
			string[] pass = new string[longitud];

			Random r = new Random();
			while (true)
			{
				for (int i = 0; i < longitud; i++)
				{
					pass[i] = letrasnums[r.Next(0, 62)];
				}

				string contrasenya = string.Join("", pass);
				Thread.Sleep(100);
				return contrasenya;
			}
		}

		public bool esFuerte()
		{
			int mayus = 0;
			int minus = 0;
			int nums = 0;
			for (int i = 0; i < contrasenia.Length; i++)
			{
				if (char.IsUpper(contrasenia[i]))
				{
					mayus++;
				}
				else if (char.IsLower(contrasenia[i]))
				{
					minus++;
				}
				else
				{
					nums++;
				}
			}

			if (mayus > 2 && minus > 1 && nums > 5)
			{
				return true;
			}
			return false;
		}

		public int Longitud
		{
			set { longitud = value; }
			get { return longitud; }
		}

		public string Contrasenia
		{
			get { return contrasenia; }
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Ingrese la cantidad de contraseñas que desea generar: ");
			int cant = int.Parse(Console.ReadLine());
			Password[] pass = new Password[cant];

			Console.Write("Ingrese la longitud de las contraseñas: ");
			int longi = int.Parse(Console.ReadLine());

			bool[] fon = new bool[cant];
			for (int i = 0; i < pass.Length; i++)
			{
				pass[i] = new Password(longi);
				fon[i] = pass[i].esFuerte();
				Console.WriteLine(pass[i].Contrasenia + " " + fon[i]);
			}

			Console.ReadKey();
		}
	}
}