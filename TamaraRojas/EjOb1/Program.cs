using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb1
{
	//Crea una clase llamada Cuenta que tendrá los siguientes atributos: titular y cantidad(puede tener decimales).
	//El titular será obligatorio y la cantidad es opcional.Crea dos constructores que cumplan lo anterior.
	//Tendrá dos métodos especiales: 
	//ingresar(double cantidad) : se ingresa una cantidad a la cuenta, si la cantidad introducida es negativa, no se hará nada.
	// retirar(double cantidad): se retira una cantidad a la cuenta, si restando la cantidad actual a la que nos pasan es negativa, la cantidad de la cuenta pasa a ser 0.
	class Cuenta
	{
		public string titular;
		public double cantidad;

		public Cuenta(string titular)
		{
			this.titular = titular;
		}

		public Cuenta(string titular, double cantidad)
		{
			this.titular = titular;
			this.cantidad = cantidad;
		}

		public double ingresar(double cantidad)
		{
			if (cantidad < 0)
			{
				return 0;
			}
			this.cantidad = this.cantidad + cantidad;
			return 1;
		}

		public double retirar(double cantidad)
		{
			double cant = this.cantidad - cantidad;
			if (cant < 0)
			{
				this.cantidad = cant;
				return 0;
			}
			this.cantidad = cant;
			return 1;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Cuenta> c = new List<Cuenta>();

			c.Add(new Cuenta("Tamara"));

			double r = c[0].ingresar(500);
			if (r == 0)
			{
				Console.WriteLine("Debe ingresar un valor valido");
			}
			else
			{
				Console.WriteLine(c[0].cantidad);
			}

			double r2 = c[0].retirar(700);
			if (r2 == 0)
			{
				Console.WriteLine("Saldo actual: " + c[0].cantidad);
			}
			else
			{
				Console.WriteLine("Saldo actual :" + c[0].cantidad);
			}

			Console.ReadKey();

		}
	}
}