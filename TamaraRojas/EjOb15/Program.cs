using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjOb15
{
	class Almacen
	{
		public List<Bebida> bebidas;
		public Bebida[,] estanteria;

		public Almacen(List<Bebida> b)
		{
			bebidas = b;
			int be = 0;
			int estacosa = 0;
			estanteria = new Bebida[4, 5];
			for (int i = 0; i < 5; i++)
			{
				while (estacosa <= 3)
				{
					estanteria[estacosa, i] = b[be];
					++be;
					++estacosa;
				}
				estacosa = 0;
			}
		}

		public double precioTotal()
		{
			double pe = 0;
			for (int i = 0; i < bebidas.Count; i++)
			{
				pe = pe + bebidas[i].precio;
			}
			return pe;
		}

		public double precioTotalMarca(string marca)
		{
			double pe = 0;
			for (int i = 0; i < bebidas.Count; i++)
			{
				bool igual = string.Equals(bebidas[i].marca, marca, StringComparison.OrdinalIgnoreCase);
				if (igual == true)
				{
					pe = pe + bebidas[i].precio;
				}
			}
			return pe;
		}

		public double precioTotalEstanteria(int col)
		{
			double pe = 0;
			for (int i = 0; i < 4; i++)
			{
				pe = pe + estanteria[i, col].precio;
			}
			return pe;
		}
		
		public bool agregarBebidaAleatoria(int[] litros, string[] marcasAgua, string[] marcas, string[] origenes, bool[] promo, Random r)
		{
			int tipo = r.Next(0, 2);
			int MyO = r.Next(0, 3);
			int be = 0;

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (estanteria[i, j] != null)
					{
						++be;
					}
				}
			}

			if (be < 20 )
			{
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						if (estanteria[i, j] == null)
						{
							switch (i)
							{
								case 0:
									if (tipo == 0)
									{
										estanteria[i, j] = new Agua(j, litros[r.Next(0, 6)], r.Next(100, 501), marcasAgua[MyO], origenes[MyO]);
										return true;
									}
									else
									{
										estanteria[i, j] = new BebidaAzucarada(j, litros[r.Next(0, 6)], r.Next(100, 501), marcas[MyO], r.Next(10, 91), promo[r.Next(0, 2)]);
										return true;
									}
								case 1:
									if (tipo == 0)
									{
										estanteria[i, j] = new Agua(j + 5, litros[r.Next(0, 6)], r.Next(100, 501), marcasAgua[MyO], origenes[MyO]);
										return true;
									}
									else
									{
										estanteria[i, j] = new BebidaAzucarada(j + 5, litros[r.Next(0, 6)], r.Next(100, 501), marcas[MyO], r.Next(10, 91), promo[r.Next(0, 2)]);
										return true;
									}
								case 2:
									if (tipo == 0)
									{
										estanteria[i, j] = new Agua(j + 10, litros[r.Next(0, 6)], r.Next(100, 501), marcasAgua[MyO], origenes[MyO]);
										return true;
									}
									else
									{
										estanteria[i, j] = new BebidaAzucarada(j + 10, litros[r.Next(0, 6)], r.Next(100, 501), marcas[MyO], r.Next(10, 91), promo[r.Next(0, 2)]);
										return true;
									}
								case 3:
									if (tipo == 0)
									{
										estanteria[i, j] = new Agua(j + 15, litros[r.Next(0, 6)], r.Next(100, 501), marcasAgua[MyO], origenes[MyO]);
										return true;
									}
									else
									{
										estanteria[i, j] = new BebidaAzucarada(j + 15, litros[r.Next(0, 6)], r.Next(100, 501), marcas[MyO], r.Next(10, 91), promo[r.Next(0, 2)]);
										return true;
									}
							}
						}
					}
				}
			}
			return false;
		}

		public  void eliminarBebida(int ID)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (estanteria[i, j] != null)
					{
						if (estanteria[i, j].id == ID)
						{
							estanteria[i, j] = null;
						}
					}
				}
			}
		}

		public string mostrarInfo(int ID)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (estanteria[i, j] != null)
					{
						if (estanteria[i, j].id == ID)
						{
							return "Litros: " + estanteria[i, j].litros + "\n" + "Marca: " + estanteria[i, j].marca + "\n" + "Precio: " + estanteria[i, j].precio;
						}
					}
				}
			}
			return "No existe una bebida con ese ID";
		}
	}


	class Bebida
	{
		public int id;
		public double litros;
		public double precio;
		public string marca;

		public Bebida(int id, double litros, double precio, string marca)
		{
			this.id = id;
			this.litros = litros;
			this.precio = precio;
			this.marca = marca;
		}
	}

	class Agua: Bebida
	{
		public string origen;

		public Agua(int id, double litros, double precio, string marca, string origen):base(id, litros, precio, marca)
		{
			this.origen = origen;
		}
	}

	class BebidaAzucarada: Bebida
	{
		public double porcentajeAzucar;
		public bool promocion;

		public BebidaAzucarada(int id, double litros, double precio, string marca, double porcentajeAzucar, bool promocion) : base(id, litros, precio, marca)
		{
			this.porcentajeAzucar = porcentajeAzucar;
			this.promocion = promocion;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{

			Random r = new Random();
			List<Bebida> bebidas = new List<Bebida>();
			int[] litros = { 100, 250, 500, 1000, 1500, 2000};
			string[] marcasAgua = { "Villavicencio", "Bon Aqua", "Glaciar"};
			string[] marcas = { "Manaos", "Fanta", "Sprite"};
			string[] origenes = { "Manantial", "Sierra de Cordoba", "Subterraneo"};
			bool[] promo = { true, false};

			for (int i = 0; i < 20; i++)
			{
				int tipo = r.Next(0, 2);
				int MyO = r.Next(0, 3);


				if (tipo == 0)
				{
					bebidas.Add(new Agua(i + 1, litros[r.Next(0, 6)], r.Next(100, 501), marcasAgua[MyO], origenes[MyO]));
				}
				else
				{
					bebidas.Add(new BebidaAzucarada(i + 1, litros[r.Next(0, 6)], r.Next(100, 501), marcas[MyO], r.Next(10, 91), promo[r.Next(0, 2)]));
				}
			}

			Almacen a = new Almacen(bebidas);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (j == 4)
					{
						Console.WriteLine(a.estanteria[i, j].id + " " + a.estanteria[i, j].marca + " " + a.estanteria[i, j].precio);
					}
					else
					{
						Console.WriteLine(a.estanteria[i, j].id + " " + a.estanteria[i, j].marca + " " + a.estanteria[i, j].precio);
					}
				}
			}

			Console.WriteLine("Precio total: " + a.precioTotal());
			Console.WriteLine("Precio total marca: " + a.precioTotalMarca("viLlaviCeNcio"));
			Console.WriteLine("Precio total estanteria: " + a.precioTotalEstanteria(0));

			if (a.agregarBebidaAleatoria(litros, marcasAgua, marcas, origenes, promo, r) == true)
			{
				Console.WriteLine("Bebida agregada");
			}
			else
			{
				Console.WriteLine("No hay espacio en las estanterias para una nueva bebida");
			}

			a.eliminarBebida(12);
			a.eliminarBebida(3);
			a.eliminarBebida(9);

			if (a.agregarBebidaAleatoria(litros, marcasAgua, marcas, origenes, promo, r) == true)
			{
				Console.WriteLine("Bebida agregada");
			}
			else
			{
				Console.WriteLine("No hay espacio en las estanterias para una nueva bebida");
			}

			Console.WriteLine(a.mostrarInfo(12));
			Console.WriteLine(a.mostrarInfo(17));

			Console.Read();

		}
	}
}
