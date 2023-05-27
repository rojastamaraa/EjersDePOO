using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM
{

	class Usuario
	{
		string name;
		int DNI;

		public Usuario(string name, int DNI)
		{
			this.name = name;
			this.DNI = DNI;
		}

		public static string Nuevousu(List<Usuario> usu, string name, int DNI)
		{
			usu.Add(new Usuario(name, DNI));
			return "Usuario " + name + " agregado exitosamente";
		}

	} 

	class Program
	{
		static void Main(string[] args)
		{

			List<Usuario> usu = new List<Usuario>();

			string[] menu =
			{
				"1. Nuevo usuario",
				"2. Modificar usuario",
				"3. Eliminar usuario",
				"4. Salir"
			};

			Console.WriteLine("Seleccione una opcion ingresando el numero");

			for (int i = 0; i < 4; i++)
			{
				Console.SetCursorPosition(3, i+1);
				Console.WriteLine(menu[i]);
			}

			while(true)
			{
				Console.CursorVisible = false;
				Console.ForegroundColor = ConsoleColor.Black;
				int opcion = int.Parse(Console.ReadLine());
				if (opcion <= 4)
				{
					Console.ForegroundColor = ConsoleColor.White;
					switch (opcion)
					{
						case 1:
							Console.Write("Ingrese nombre del usuario: ");
							string name = Console.ReadLine();
							Console.Write("Ingrese DNI del usuario: ");
							int DNI = int.Parse(Console.ReadLine());
							Console.Write(Usuario.Nuevousu(usu, name, DNI));
							break;
						case 2:
							break;
						case 3:
							break;
						case 4:
							break;
					}
				}
				else
				{
					Console.Write("No existe esa opcion");
				}

			}

			Console.ReadLine();

		}
	}  

}

//Realizar un menu con las siguientes opciones
//1. Nuevo usuario
//2. Modificar usuario
//3. Eliminar usuario
//4. Listar

//El objeto Usuario tiene que tener Nombre, DNI
//Para modificar se puede buscar por nombre o por DNI
//Reutilizar funciones