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

		public static bool buscar(List<Persona> list, int dni)
		{
			int individuo = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].dni == dni)
				{
					individuo = i;
					return true;
				}
			}
			return false;
		}
		public static Persona buscarr(List<Persona> list, int dni)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].dni == dni)
				{
				return list[i];
				}
			}
			return null;
		}
		public static Persona eliminar (List<Persona> list, int dni)
			{
			Persona elimi = Persona.buscarr(list, dni);
			if(elimi != null)
			{
				list.Remove(elimi);
				return list[0];
			}
				return null;
			} 

	internal class Program
	{

		static void Main(string[] args)
		{
			List<Persona> list = new List<Persona>();

			list.Add(new Persona("Spinetta", 73, 8321839));
			list.Add(new Persona("Pity", 50, 12345678));
			list.Add(new Persona("Tamara", 17, 47029906));

			int dni;
			Console.Write("Ingrese un DNI para buscar: ");
			dni = int.Parse(Console.ReadLine());
			bool encontro = Persona.buscar(list, dni);
			
			Persona pers = Persona.buscarr(list, dni);
				if(pers!=null)
				{
					Console.Write(pers.name);
				}
				else 
				{
					Console.Write("No se encontro");
				}
			
				int dnii;
				Console.Write("Ingrese un DNI para eliminar: ");
				dnii = int.Parse(Console.ReadLine());
				Persona chu = Persona.eliminar(list, dnii);
				if(chu == null)
				{
					Console.Write ("No existe");
				}
				else 
				{
					Console.Write("Eliminado");
				}


			Console.ReadKey();

	}
}}}
