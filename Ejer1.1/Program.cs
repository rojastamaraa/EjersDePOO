using System;
using System.Collections.Generic;

namespace ejer1._1
{
	class Persona
	{
		public string name;
		public int age;
		public int dni;

		//Constructor por defaul - Mismo nombre que la clase
		public Persona()
		{
		}

		//Segundo constructor - Mismo nombre que la clase
		public Persona(string name, int age, int dni)
		{
			this.name = name;
			this.age = age;
			this.dni = dni;
		}
		//Mas de un constructor = sobrecarga de constructores

		//Metodo para mostrar los datos del objeto
		public string mostrarindividuo()
		{
			return name + ", " + age + ", " + dni;
		}
	}
	internal class Program
	{
		public static bool buscar(List<Persona> list, int dni)
		{
			int individuo = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].dni == dni)
				{
					bool encontro = true;
					individuo = i;
					return encontro;
				}
			}
		}
		static void Main(string[] args)
		{
			List<Persona> list = new List<Persona>();
			Persona persona1;


			list.Add(new Persona("Spinetta", 73, 8321839));
			list.Add(new Persona("Pity", 50, 12345678));
			list.Add(new Persona("Tamara", 17, 47029906));


			bool encontro = false;
			int dni;
			int individuo = 0;
			Console.Write("Ingrese un DNI para buscar: ");
			dni = int.Parse(Console.ReadLine());
			buscar(list, dni, encontro, individuo);

			if (!encontro)
			{
				Console.WriteLine("No se encontro");
			}
			else
			{
				Console.WriteLine("Se encontro");
				Console.WriteLine($"{list[individuo].mostrarindividuo()}");
			}



			Console.ReadKey();

		}
	}
}

Agregar al ejercicio de personas 3 métodos
1. Método buscar por DNI y que devuelva verdadero o falso
2. Método buscar por DNI y que devuelva un objeto Persona en caso de que lo haya encontrado y en caso contrario que devuelva null.
3. Método eliminar que reciba como parámetro un DNI

Con estos métodos quiero ver cómo los trabajan y cuánto aprovechan el código para reutilizar y no repetir.