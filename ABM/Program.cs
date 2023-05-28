using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM
{

	class Usuario
	{
		public string name;
		public int DNI;

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
		public static Usuario buscar(List<Usuario> usu, int DNI)
		{
			for (int i = 0; i < usu.Count; i++)
			{
				if (DNI == usu[i].DNI)
				{
					return usu[i];
				}
			}
			return null;
		}
		public static Usuario buscar(List<Usuario> usu, string name)
		{
			for(int i = 0; i < usu.Count; i++)
			{
				if(name == usu[i].name)
				{
					return usu[i];
				}
			}
			return null;
		}



		public static string modificar (Usuario usuu, string name)
		{
			return usuu.name = name;
		}
		public static int modificar (Usuario usuu, int dni)
		{
			return usuu.DNI = dni;
		}

		public static string eliminar (List<Usuario> usu, Usuario uusuu)
		{
			usu.Remove(uusuu);
			return "Usuario eliminado";
		}

	class Program
	{
		static void Main(string[] args)
		{

			List<Usuario> usu = new List<Usuario>();
			usu.Add(new Usuario("Tamara", 47029906));
		
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

				bool menn = true;

			while(menn)
			{
				Console.CursorVisible = false;
				Console.ForegroundColor = ConsoleColor.Black;
				int opcion = int.Parse(Console.ReadLine());
				if (opcion < 5)
				{
					Console.ForegroundColor = ConsoleColor.White;
					switch (opcion)
					{
						case 1:
							Console.Write("Ingrese nombre del usuario: ");
							string name = Console.ReadLine();
							Console.Write("Ingrese DNI del usuario: ");
							int DNI = int.Parse(Console.ReadLine());
							Console.WriteLine(Usuario.Nuevousu(usu, name, DNI));
							Console.WriteLine("Seleccione otra opcion");
							break;
						case 2:
							Console.WriteLine("Selecione A para buscar por nombre y B para buscar por DNI: ");
							string nod = Console.ReadLine();
							if (nod == "A")
							{
								Console.Write("Ingrese nombre: ");
								string namee = Console.ReadLine();
								Usuario usuu = Usuario.buscar(usu, namee);
								if(usuu != null)
								{
									Console.WriteLine("Se encontro al usuario: " + namee);
									Console.WriteLine("A para modificar nombre y B para modificar DNI");
									string nnodd = Console.ReadLine();
									if (nnodd == "A")
									{
										Console.Write("Ingrese nuevo nombre: ");
										string nname = Console.ReadLine();
										Console.Write("Usuario renombrado como: " + Usuario.modificar(usuu, nname));
									}
									else if (nnodd == "B")
									{
										Console.Write("Ingrese nuevo DNI: ");
										int ddni = int.Parse(Console.ReadLine());
										Console.WriteLine("Nuevo DNI: " + Usuario.modificar(usuu, ddni));
									}
								}
								else
								{
									Console.WriteLine("No se encontro"); 
								}

							}
							else if (nod == "B")
							{
								Console.Write("Ingrese DNI: ");
								int ddnnii = int.Parse(Console.ReadLine());
								Usuario usuu = Usuario.buscar(usu, ddnnii);
								if(usuu != null)
								{
									Console.WriteLine("Se encontro al usuario con DNI: " + ddnnii);
									Console.WriteLine("A para modificar nombre y B para modificar DNI");
									string nnodd = Console.ReadLine();
									if (nnodd == "A")
									{
										Console.Write("Ingrese nuevo nombre: ");
										string nname = Console.ReadLine();
										Console.WriteLine("Usuario renombrado como: " + Usuario.modificar(usuu, nname));
									}
									else if (nnodd == "B")
									{
										Console.Write("Ingrese nuevo DNI: ");
										int ddni = int.Parse(Console.ReadLine());
										Console.WriteLine("Nuevo DNI: " + Usuario.modificar(usuu, ddni));
									}
								}
								else
								{
									Console.WriteLine("No se encontro");
								}
							}

							Console.WriteLine("Seleccione otra opcion");

							break;
						case 3:
							Console.Write("Selecione A para eliminar por nombre y B para eliminar por DNI: ");
							string nood = Console.ReadLine();
							if(nood == "A")
							{
								Console.Write("Ingrese nombre: ");
								string nnname = Console.ReadLine();
								Usuario uusuu = buscar(usu, nnname);
								if (uusuu != null)
								{
									Console.WriteLine(eliminar(usu, uusuu));
								}
								else
								{
									Console.WriteLine("No se encontro");
								}
								}
							else if (nood == "B")
							{
								Console.Write("Ingrese DNI: ");
								int dnni = int.Parse(Console.ReadLine());
								Usuario uusuu = buscar(usu, dnni);
								if(uusuu != null)
								{
									Console.WriteLine(eliminar(usu, uusuu));
								}
								else
								{
									Console.WriteLine("No se encontro");
								}
							}

							Console.WriteLine("Seleccione otra opcion");

								break;
						case 4:
								menn = false;
							break;
					}
				}
				else 
				{
						Console.ForegroundColor = ConsoleColor.White;
						Console.Write("No existe esa opcion");
				}

			}

		}
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