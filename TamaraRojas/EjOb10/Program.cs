using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb10
{
//Vamos a hacer una baraja de cartas españolas orientado a objetos.
//Una carta tiene un número entre 1 y 12 (el 8 y el 9 no los incluimos) y un palo(espadas, bastos, oros y copas)
//La baraja estará compuesta por un conjunto de cartas, 40 exactamente.
//Las operaciones que podrá realizar la baraja son:
//barajar() : cambia de posición todas las cartas aleatoriamente
// siguienteCarta(): devuelve la siguiente carta que está en la baraja, cuando no haya más o se haya llegado al final,
//		se indica al usuario que no hay más cartas.
// cartasDisponibles(): indica el número de cartas que aún puede repartir
// darCartas(): dado un número de cartas que nos pidan, le devolveremos ese número de cartas(piensa que puedes devolver). En caso de que haya menos cartas que las pedidas, 
//		no devolveremos nada pero debemos indicarlo al usuario.
//cartasMonton(): mostramos aquellas cartas que ya han salido, si no ha salido ninguna indicárselo al usuario
//mostrarBaraja() : muestra todas las cartas hasta el final.Es decir, si se saca una carta y luego se llama al método, este no mostrará esa primera carta.
	class Baraja
	{
		public List<Carta> baraja;
		public static Random r = new Random();

		public Baraja()
		{
			baraja = new List<Carta>();
			cartas();
		}

		private void cartas()
		{
			int[] valores = { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12};
			string[] palo = { "espada", "basto", "oro", "copas"};

			for (int i = 0; i < palo.Length; i++)
			{
				for (int j = 0; j < valores.Length; j++)
				{
					Carta c = new Carta(valores[j], palo[i]);
					baraja.Add(c);
				}
			}
		}

		public void barajar()
		{
			for (int i = 0; i < baraja.Count; i++)
			{
				int indice = r.Next(0, baraja.Count);
				Carta cc = baraja[indice];
				baraja.Insert(i, cc);
				baraja.Remove(cc);

			}
		}
	}

	class Carta
	{
		public int valor;
		public string palo;

		public Carta(int valor, string palo)
		{
			this.valor = valor;
			this.palo = palo;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Baraja b = new Baraja();
			for (int i = 0; i < b.baraja.Count; i++)
			{
				Console.WriteLine("Palo: " + b.baraja[i].palo + " Valor: " + b.baraja[i].valor);
			}

			Console.WriteLine("BARAJADO");


			b.barajar();
			b.barajar();
			for (int i = 0; i < b.baraja.Count; i++)
			{
				Console.WriteLine("Palo: " + b.baraja[i].palo + " Valor: " + b.baraja[i].valor);
			}

			Console.Read();
		}
	}
}
