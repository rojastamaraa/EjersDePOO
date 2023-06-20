using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EjOb8
{
	class Individuo
	{
		public Random r = new Random();
		public string nombre;
		public int edad;
		public char sexo;
		public bool asistencia;

		public Individuo()
		{
			datosPersonales();
		}

		public virtual void datosPersonales()
		{
			string[] nombres = { "Angus", "Bon", "Celeste", "Joan", "Gustavo", "Julian", "Sid", "Brian", "Steven", "Charly", "Fito", "Lucas", "Michael", "Claudia", "Adrian", "Luis", "Fabiana", "John", "Ozzy", "Grover", "Indio", "Ciro", "Johnny", "Axl" };
			//string[] apellidos = { "Young", "Scott", "Carballo", "Jett", "Cerati", "Casablancas", "Vicious", "May", "Morrisey", "Garcia", "Paez", "Prodan", "Jackson", "Puyo", "Dargelos", "Spinetta", "Cantilo", "Frusciante", "Osbourne", "Washington", "Solari", "Martinez", "Lydon", "Rose" };
			char[] sex = {'F', 'M'};
			while (true)
			{
				nombre = nombres[r.Next(0, nombres.Length)];
				sexo = sex[r.Next(0, sex.Length)];
				break;
			}
		}
	}
	class Estudiante: Individuo
	{
		public int calificacion;

		public Estudiante(): base()
		{
			datosPersonales();
		}

		public override void datosPersonales()
		{
			base.datosPersonales();
			while (true)
			{
				int n = r.Next(0, 100);
				if (n > 50)
				{
					asistencia = true;
				}
				else
				{
					asistencia = false;
				}

				calificacion = r.Next(1,10);
				edad = r.Next(13, 18);
				Thread.Sleep(10);
				break;
			}
		}
	}
	class Profesor: Individuo
	{
		public string materia;

		public Profesor() : base()
		{
			datosPersonales();
		}

		public override void datosPersonales()
		{
			base.datosPersonales();
			while (true)
			{
				double n = r.Next(0, 100);
				if (n > 20)
				{
					asistencia = true;
				}
				else
				{
					asistencia = false;
				}

				string[] materias = { "Matematicas", "Filosofia", "Fisica" };
				materia = materias[r.Next(0, materias.Length)];
				edad = r.Next(20, 65);
				Thread.Sleep(10);
				break;
			}
		}

	}
	class Aula
	{
		public Random r2 = new Random();
		public int identificador;
		public int maxEstudiantes = 35;
		public string asignatura;
		public Profesor profesor;
		public List<Estudiante> estudiantes = new List<Estudiante>();

		public Aula(int identificador, List<Profesor> p)
		{
			this.identificador = identificador;
			info(p);
		}

		 public void info(List<Profesor> p)
		{
			string[] materias = {"Matematicas", "Filosofia", "Fisica"};
			List<Estudiante> e = new List<Estudiante>();
			for (int i = 0; i < maxEstudiantes; i++)
			{
				e.Add(new Estudiante());
			}

			for (int i = 0; i < maxEstudiantes; i++)
			{
				if (e[i].asistencia == true)
				{
					estudiantes.Add(e[i]);
				}
			}
			profesor = p[0];
			while (true)
			{
				asignatura = materias[r2.Next(0, 3)];
				Thread.Sleep(10);
				break;
			}
		}

		public string darClase()
		{

			if (profesor.asistencia == true && profesor.materia == asignatura && estudiantes.Count > 17)
			{
				return "Se puede dar clase";
			}
			else
			{
				return "No se puede dar clase";
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Profesor> p = new List<Profesor>();
			List<Aula> a = new List<Aula>();

			p.Add(new Profesor());

			a.Add(new Aula(1, p));

			Console.WriteLine(a[0].darClase());

			//Console.WriteLine(a[0].asignatura + " " + a[0].profesor.materia + " " + a[0].profesor.asistencia + " " + a[0].estudiantes.Count());

			int alumnasAprobadas = 0;
			int alumnosAprobados = 0;

			for (int i = 0; i < a[0].estudiantes.Count; i++)
			{
				if (a[0].estudiantes[i].sexo == 'F' && a[0].estudiantes[i].calificacion >= 6)
				{
					alumnasAprobadas++;
				}

				if (a[0].estudiantes[i].sexo == 'M' && a[0].estudiantes[i].calificacion >= 6)
				{
					alumnosAprobados++;
				}
			}

			Console.WriteLine("Alumnas aprobadas: " + alumnasAprobadas);
			Console.WriteLine("Alumnos aprobados: " + alumnosAprobados);

			//for (int i = 0; i < a[0].estudiantes.Count; i++)
			//{
			//	Console.WriteLine("Nombre: " + a[0].estudiantes[i].nombre + " Edad: " + a[0].estudiantes[i].edad + " Sexo: " + a[0].estudiantes[i].sexo + " Calificacion: " + a[0].estudiantes[i].calificacion + " Asistencia: " + a[0].estudiantes[i].asistencia);
			//}

			Console.Read();
		}
	}
}

