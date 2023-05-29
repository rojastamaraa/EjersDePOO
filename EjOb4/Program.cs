using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb4
{
	class Electrodomestico
	{
		private double preciobase = 100;
		private string color = "blanco";
		private char consumo = 'F';
		private double peso = 5;

		public Electrodomestico() { }

		public Electrodomestico(double preciobase, double peso)
		{
			this.preciobase = preciobase;
			this.peso = peso;
		}

		public Electrodomestico(double preciobase, string color, char consumo, double peso)
		{
			this.preciobase = preciobase;
			this.color = color;
			this.consumo = consumo;
			this.peso = peso;
		}

		public double Preciobase
		{
			get
			{
				return this.preciobase;
			}
		}

		public string Color
		{
			get
			{
				return this.color;
			}
		}

		public char Consumo
		{
			get
			{
				return this.consumo;
			}
		}

		public double Peso
		{
			get
			{
				return this.peso;
			}
		}

		private void comprobarConsumoEner(char letra)
		{
			const string letrasposi = "ABCDEF";
			if(letrasposi.Contains(letra))
			{
				this.consumo = letra;
			}
			else
			{
				this.consumo = 'F';
			}
		}

		private void comprobarColor(string color)
		{
			const string coloresposi = "BLANCONEGROROJOSAZULGRIS";
			if (coloresposi.Contains(color))
			{
				this.color = color;
			}
			else
			{
				this.color = "BLANCO";
			}
		}

		public void precio_final()
		{
			double precio = preciobase; 
			switch(this.consumo)
			{
				case 'A':
					preciobase += 100;
					break;
				case 'B':
					preciobase += 80;
					break;
				case 'C':
					preciobase += 60;
					break;
				case 'D':
					preciobase += 50;
					break;
				case 'E':
					preciobase += 30;
					break;
				case 'F':
					preciobase += 10;
					break;
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
}
//Crearemos una superclase llamada Electrodoméstico con las siguientes características:
//Sus atributos son precio base, color, consumo energético(letras entre A y F) y peso.Indica que se podrán heredar.
//Por defecto, el color será blanco, el consumo energético será F, el precioBase es de 100 € y el peso de 5 kg.Usa constantes para ello.
//Los colores disponibles son blanco, negro, rojo, azul y gris.No importa si el nombre está en mayúsculas o en minúsculas.
//Los constructores que se implementarán serán
//Un constructor por defecto.
//Un constructor con el precio y peso.El resto por defecto.
//Un constructor con todos los atributos.
//Los métodos que implementara serán:
//Métodos get de todos los atributos.
//comprobarConsumoEnergetico(char letra): comprueba que la letra es correcta, sino es correcta usará la letra por defecto. Se invocará al crear el objeto y no será visible.
//comprobarColor(String color): comprueba que el color es correcto, sino lo es usa el color por defecto. Se invocará al crear el objeto y no será visible.
//precioFinal(): según el consumo energético, aumentará su precio, y según su tamaño, también.Esta es la lista de precios:
