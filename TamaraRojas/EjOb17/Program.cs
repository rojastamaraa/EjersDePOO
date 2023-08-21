using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb17
{
	public enum PalosBarEspañola
	{
		OROS,
		COPAS,
		ESPADAS,
		BASTOS
	}

	public enum PalosBarFrancesa
	{
		DIAMANTES,
		PICAS,
		CORAZONES,
		TREBOLES
	}

	abstract class Baraja
	{
		public int cartasTotal;
		public int cartasPorPalo;

		public Baraja() { }

		public Baraja(bool siOno)
		{
			if (siOno == true)
			{
				cartasTotal = 48;
				cartasPorPalo = 12;
			}
			else
			{
				cartasTotal = 40;
				cartasPorPalo = 10;
			}
		}

		abstract public void crearBaraja();
	}

	class Carta<T>
	{
		public T palo;
		public int num;
		public string rolnc;

		public Carta(T palo, int num, string rolnc)
		{
			this.palo = palo;
			this.num = num;
			this.rolnc = rolnc;
		}
	}

	class BarajaEspañola : Baraja
	{
		public bool siOno;
		public List<Carta<PalosBarEspañola>> baraja;

		public BarajaEspañola(bool siOno) : base(siOno)
		{
			this.siOno = siOno;
			baraja = new List<Carta<PalosBarEspañola>>();
			crearBaraja();
		}

		public override void crearBaraja()
		{
			int[] numm = { 1,2,3,4,5,6,7,10,11,12};
			if (siOno == false)
			{
				for (int i = 0; i < cartasPorPalo; i++)
				{
					if (i == 0)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, numm[i], "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, numm[i], "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, numm[i], "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, numm[i], "As"));
					}
					else if (i == 7)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, numm[i], "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, numm[i], "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, numm[i], "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, numm[i], "Sota"));
					}
					else if (i == 8)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, numm[i], "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, numm[i], "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, numm[i], "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, numm[i], "Caballo"));
					}
					else if (i == 9)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, numm[i], "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, numm[i], "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, numm[i], "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, numm[i], "Rey"));
					}
					else
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, numm[i], ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, numm[i], ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, numm[i], ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, numm[i], ""));
					}
				}
			}
			else
			{
				for (int i = 1; i <= cartasPorPalo; i++)
				{
					if (i == 1)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, i, "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, i, "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, i, "As"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, i, "As"));
					}
					else if (i == 10)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, i, "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, i, "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, i, "Sota"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, i, "Sota"));
					}
					else if (i == 12)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, i, "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, i, "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, i, "Caballo"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, i, "Caballo"));
					}
					else if (i == 13)
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS,i, "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, i, "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, i, "Rey"));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, i, "Rey"));
					}
					else
					{
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.BASTOS, i, ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.COPAS, i, ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.ESPADAS, i, ""));
						baraja.Add(new Carta<PalosBarEspañola>(PalosBarEspañola.OROS, i, ""));
					}
				}
			}
			
		}
	}

	class BarajaFrancesa : Baraja
	{
		public List<Carta<PalosBarFrancesa>> baraja;

		public BarajaFrancesa() : base()
		{
			baraja = new List<Carta<PalosBarFrancesa>>();
			crearBaraja();
		}

		public override void crearBaraja()
		{
			for (int i = 1; i <= 13; i++)
			{
				if (i == 1)
				{
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.CORAZONES, i, "As"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.DIAMANTES, i, "As"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.PICAS, i, "As"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.TREBOLES, i, "As"));
				}
				else if (i == 11)
				{
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.CORAZONES, i, "Jota"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.DIAMANTES, i, "Jota"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.PICAS, i, "Jota"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.TREBOLES, i, "Jota"));
				}
				else if (i == 12)
				{
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.CORAZONES, i, "Reina"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.DIAMANTES, i, "Reina"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.PICAS, i, "Reina"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.TREBOLES, i, "Reina"));
				}
				else if (i == 13)
				{
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.CORAZONES, i, "Rey"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.DIAMANTES, i, "Rey"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.PICAS, i, "Rey"));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.TREBOLES, i, "Rey"));
				}
				else
				{
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.CORAZONES, i, ""));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.DIAMANTES, i, ""));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.PICAS, i, ""));
					baraja.Add(new Carta<PalosBarFrancesa>(PalosBarFrancesa.TREBOLES, i, ""));
				}
			}
		}

		public bool CartaRoja(Carta<PalosBarFrancesa> carta)
		{
			return carta.palo == PalosBarFrancesa.CORAZONES || carta.palo == PalosBarFrancesa.DIAMANTES;
		}
		
		public bool CartaNegra(Carta<PalosBarFrancesa> carta)
		{
			return carta.palo == PalosBarFrancesa.TREBOLES || carta.palo == PalosBarFrancesa.PICAS;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			BarajaEspañola b = new BarajaEspañola(true);
			BarajaFrancesa b2 = new BarajaFrancesa();

			for (int i = 0; i < b.baraja.Count; i++)
			{
				Console.WriteLine(b.baraja[i].palo + " num: " + b.baraja[i].num + " rol: " + b.baraja[i].rolnc);
			}

			Console.WriteLine("BARAJA FRANCESA");

			for (int i = 0; i < b2.baraja.Count; i++)
			{
				Console.WriteLine(b2.baraja[i].palo + " num: " + b2.baraja[i].num + " rol: " + b2.baraja[i].rolnc);
			}

			Console.ReadKey();
		}
	}
}
