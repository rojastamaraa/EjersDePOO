using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb16
{
	class Contacto
	{
		public string nombre;
		public int telefono;

		public Contacto(string nombre, int telefono)
		{
			this.nombre = nombre;
			this.telefono = telefono;
		}
	}

	class Agenda
	{
		public List<Contacto> contactos;

		public Agenda(List<Contacto> c)
		{
			contactos = c;
		}

		public string aniadirContacto(Contacto c, int cant)
		{
			if (contactos.Count < cant)
			{
				if (existeContacto(c.nombre) == true)
				{
					return "Ya existe otro contacto con ese nombre";
				}
				else
				{
					contactos.Add(c);
					return "Contacto agregado exitosamente";
				}
			}
			return agendaLlena(cant);
		}

		public bool existeContacto(string c)
		{
			for (int i = 0; i < contactos.Count; i++)
			{
				if (contactos[i].nombre == c)
				{
					return true;
				}
			}
			return false;
		}

		public string listarContactos()
		{
			string lista = "";
			for (int i = 0; i < contactos.Count; i++)
			{
				 lista = lista + "Nombre: " + contactos[i].nombre + "\n" + "                                                            ";
			}
			return lista;
		}

		public string buscarContacto(string n)
		{
			for (int i = 0; i < contactos.Count; i++)
			{
				if (contactos[i].nombre == n)
				{
					return "Telefono: " + contactos[i].telefono;
				}
			}
			return "No existe un contacto con ese nombre";
		}

		public string eliminarContacto(string nombre)
		{
			for (int i = 0; i < contactos.Count; i++)
			{
				if (contactos[i].nombre == nombre)
				{
					contactos.Remove(contactos[i]);
					return "Contacto eiminado";
				}
			}
			return "No se elimino porque no existe";
		}

		public string agendaLlena(int cant)
		{
			if (cant > contactos.Count)
			{
				return "Todavia queda espacio";
			}
			return "Agenda Llena";
		}

		public string huecosLibres(int cant)
		{
			int libres = cant  - contactos.Count;
			if (libres > 0)
			{
				return "Quedan " + libres + " huecos libres";
			}
			return "No hay espacio para mas contactos";
		}
	}

	class Program
	{
		static void menuu(string[] menu, int pos)
		{
			for (int i = 0; i < menu.Length; i++)
			{
				if (i == pos)
				{
					Console.ForegroundColor = ConsoleColor.Green;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.SetCursorPosition(5, i + 1);
				Console.Write(menu[i]);
			}
		}

		static void Main(string[] args)
		{

			Console.Write("Cantidad maxima de contactos: ");
			int cant = int.Parse(Console.ReadLine());

			List<Contacto> c = new List<Contacto>();
			Agenda agenda = new Agenda(c);

			string[] menu =
			{
				"	 Añadir contacto    ",
				"	 Existe contacto    ",
				"   Listar contactos    ",
				"    Buscar contactos   ",
				"	Eliminar contacto   ",
				"	  Agenda llena      ",
				"     Huecos libres     "
			};

			int pos = 0;
			Console.CursorVisible = false;
			menuu(menu, pos);

			while (true)
			{
				//COMIENZO MENU
				ConsoleKeyInfo tecla = Console.ReadKey(true);
				if (tecla.Key == ConsoleKey.Enter)
				{
					Console.Clear();
				}
				if (tecla.Key == ConsoleKey.DownArrow && pos < 6)
				{
					Console.SetCursorPosition(5, pos + 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(menu[pos]);
					pos++;
					Console.SetCursorPosition(5, pos + 1);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(menu[pos]);
				}
				if (tecla.Key == ConsoleKey.UpArrow && pos > 0)
				{
					Console.SetCursorPosition(5, pos + 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(menu[pos]);
					pos = pos - 1;
					Console.SetCursorPosition(5, pos + 1);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(menu[pos]);
				}
				//FIN MENU

				if (tecla.Key == ConsoleKey.Enter && pos == 0)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Ingrese nombre: ");
					string nombre = Console.ReadLine();
					Console.Clear();
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Ingrese telefono: ");
					int telefono = int.Parse(Console.ReadLine());
					Contacto contacto = new Contacto(nombre, telefono);
					Console.Clear();
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(agenda.aniadirContacto(contacto, cant));
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 1)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Ingrese nombre: ");
					string nombre = Console.ReadLine();
					bool i = agenda.existeContacto(nombre);
					Console.Clear();
					menuu(menu, pos);
					if (i == true)
					{
						Console.SetCursorPosition(60, 1);
						Console.WriteLine("Existe");
					}
					else
					{
						Console.SetCursorPosition(60, 1);
						Console.WriteLine("No existe");
					}
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 2)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.Write(agenda.listarContactos());
					menuu(menu, pos);
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 3)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Ingrese nombre: ");
					string nombre = Console.ReadLine();
					Console.Clear();
					Console.SetCursorPosition(60, 1);
					Console.WriteLine(agenda.buscarContacto(nombre));
					menuu(menu, pos);
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 4)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write("Ingrese nombre: ");
					string nombre = Console.ReadLine();
					Console.Clear();
					Console.SetCursorPosition(60, 1);
					Console.WriteLine(agenda.eliminarContacto(nombre));
					menuu(menu, pos);
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 5)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(agenda.agendaLlena(cant));
					menuu(menu, pos);
				}
				if (tecla.Key == ConsoleKey.Enter && pos == 6)
				{
					menuu(menu, pos);
					Console.SetCursorPosition(60, 1);
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(agenda.huecosLibres(cant));
					menuu(menu, pos);
				}
			}

		}
	}
}
