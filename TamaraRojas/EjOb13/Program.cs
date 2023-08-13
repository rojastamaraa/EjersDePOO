using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb13
{
	class Empleado
	{
		private string nombre;
		private int edad;
		private double salario;
		private double pplus = PLUS;

		const double PLUS = 300;

		public Empleado(string nombre, int edad, double salario)
		{
			this.nombre = nombre;
			this.edad = edad;
			this.salario = salario;
		}

		public string Nombre
		{
			get{ return nombre; }
			set{ nombre = value; }
		}

		public int Edad
		{
			get { return edad; }
			set { edad = value; }
		}

		public double Salario
		{
			get { return salario; }
			set { salario = value; }
		}

		public double Pplus
		{
			get { return pplus; }
		}

		public virtual void plus()
		{

		}
	}

	class Repartidor: Empleado
	{
		private string zona;

		public Repartidor(string nombre, int edad, double salario, string zona):base(nombre, edad, salario)
		{
			this.zona = zona;
		}

		public string Zona
		{
			get { return zona; }
			set { zona = value; }
		}
		
		public override void plus()
		{
			if (Edad < 25 && zona == "zona 3")
			{
				Salario = Salario + Pplus;
			}
		}
	}

	class Comercial : Empleado
	{
		private double comision;

		public Comercial(string nombre, int edad, double salario, double comision) : base(nombre, edad, salario)
		{
			this.comision = comision;
		}

		public double Comision
		{
			get { return comision; }
			set { comision = value; }
		}
		
		public override void plus()
		{
			if (Edad > 30 && comision > 200)
			{
				Salario = Salario + Pplus;
			}
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			Comercial c = new Comercial("Comercial1", 32, 100, 201);
			Comercial c2 = new Comercial("Comercial2", 22, 100, 201);
			Repartidor r = new Repartidor("Repartidor", 22, 100, "zona 7");
			Repartidor r2 = new Repartidor("Repartidor2", 22, 100, "zona 3");

			Console.WriteLine(c.Nombre + " " + c.Edad + " " + c.Salario + " " + c.Comision);
			Console.WriteLine(c2.Nombre + " " + c2.Edad + " " + c2.Salario + " " + c2.Comision);
			Console.WriteLine(r.Nombre + " " + r.Edad + " " + r.Salario + " " + r.Zona);
			Console.WriteLine(r2.Nombre + " " + r2.Edad + " " + r2.Salario + " " + r2.Zona);

			Console.WriteLine("PLUS");

			c.plus();
			c2.plus();
			r.plus();
			r2.plus();

			Console.WriteLine(c.Nombre + " " + c.Edad + " " + c.Salario + " " + c.Comision);
			Console.WriteLine(c2.Nombre + " " + c2.Edad + " " + c2.Salario + " " + c2.Comision);
			Console.WriteLine(r.Nombre + " " + r.Edad + " " + r.Salario + " " + r.Zona);
			Console.WriteLine(r2.Nombre + " " + r2.Edad + " " + r2.Salario + " " + r2.Zona);

			Console.Read();
		}
	}
}
