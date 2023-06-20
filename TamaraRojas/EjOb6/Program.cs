using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EjOb6
{
	class Libro
	{
		private long isbn;
		private string titulo;
		private string autor;
		private int nroPaginas;

		public Libro(long isbn, string titulo, string autor, int nroPaginas)
		{
			this.isbn = isbn;
			this.titulo = titulo;
			this.autor = autor;
			this.nroPaginas = nroPaginas;
		}

		public long Isbn
		{
			get { return isbn; }
			set { isbn = value; }
		}

		public string Titulo
		{
			get { return titulo; }
			set { titulo = value; }
		}

		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}

		public int NroPaginas
		{
			get { return nroPaginas; }
			set { nroPaginas = value; }
		}

		public string mostrar()
		{
			return "El libro " + titulo + " con ISBN " + Isbn + " creado por el autor " + autor + " tiene " + nroPaginas + " paginas";
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{

			Libro l1 = new Libro(9789563004502, "Los ojos del perro siberiano", "Antonio Santa AnA", 136);
			Libro l2 = new Libro(9789802715503, "Wigetta: Un viaje magico", "Willyrex", 2);

			Console.WriteLine(l1.mostrar());
			Console.WriteLine(l2.mostrar());

			if (l2.NroPaginas > l1.NroPaginas)
			{
				Console.WriteLine(l2.Titulo + "tiene mas paginas que " + l1.Titulo);
			}
			else
			{
				Console.WriteLine(l1.Titulo + " tiene mas paginas que " + l2.Titulo);
			}

			Console.ReadKey();
		}
	}
}