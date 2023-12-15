using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace El_juego
{
	public class Semilla 
	{
		public string nombre;
		public int cant, ganancia, devuelve;
		public Semilla(string nombre, int cant, int ganancia) 
		{
			this.nombre = nombre;
			this.cant = cant;
			this.ganancia = ganancia;
			devuelve = 2;
		}
	}
	public class Tbh
	{
		public Animacion ani;
		public Vector2 pos;
		public Rectangle rect;
		private SpriteEffects spriteEffect;
		public Semilla semicalabaza;
		public Semilla semitomate;
		public Semilla semimaiz;
		public string testeo = " ";
		public string monedasString = "0";
		public string aguaString = "0%";
		public int monedas;
		public bool enMenu, llaveC, llaveM, balsa, sobrePuente, regando, plantando, fuente;
		public int madera;
		public float agua;

		public Tbh(Animacion ani, Vector2 pos)
		{
			this.ani = ani;
			this.pos = pos;
			semicalabaza = new Semilla("calabaza", 0, 12);
			semitomate = new Semilla("tomate", 5, 3);
			semimaiz = new Semilla("maiz", 0, 6);
		}

		public void Update(GameTime gameTime, Map mapa, KeyboardState key, SoundEffect regandoIn, SoundEffect plantandoIn, SoundEffectInstance fuenteIn, SoundEffect blop)
		{
			//Movimiento
			if (!sobrePuente)
			{
				if (key.IsKeyDown(Keys.Down) && pos.Y < 944)
				{ pos.Y += 1.5f; ani.Y = 0; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Up) && pos.Y > 65)
				{ pos.Y -= 1.5f; ani.Y = 1; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Left) && pos.X > 96)
				{ pos.X -= 1.5f; ani.Y = 2; spriteEffect = SpriteEffects.None; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Right) && pos.X < 1200)
				{ pos.X += 1.5f; ani.Y = 2; spriteEffect = SpriteEffects.FlipHorizontally; ani.Update(gameTime, 150); }
				if (key.GetPressedKeys().Length == 0) { ani.frameActual = 0; }
			}
			else
			{
				if (key.IsKeyDown(Keys.Down) && pos.Y < 1040)
				{ pos.Y += 1.5f; ani.Y = 0; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Up))
				{ pos.Y -= 1.5f; ani.Y = 1; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Left) && pos.X > 635)
				{ pos.X -= 1.5f; ani.Y = 2; spriteEffect = SpriteEffects.None; ani.Update(gameTime, 150); }
				if (key.IsKeyDown(Keys.Right) && pos.X < 655)
				{ pos.X += 1.5f; ani.Y = 2; spriteEffect = SpriteEffects.FlipHorizontally; ani.Update(gameTime, 150); }
				if (key.GetPressedKeys().Length == 0) { ani.frameActual = 0; }
			}

			//testeo = pos.X + ";" + pos.Y;

			//Colisiones
			rect = new Rectangle((int)pos.X + 49 / 2, (int)pos.Y + 45, 1, 1);

			huertaColision(gameTime, mapa.huertaCalabaza.tierra, mapa.huertaCalabaza.tierraList, semicalabaza, key, regandoIn, plantandoIn, blop);
			huertaColision(gameTime, mapa.huertaTomate.tierra, mapa.huertaTomate.tierraList, semitomate, key, regandoIn, plantandoIn, blop);
			huertaColision(gameTime, mapa.huertaMaiz.tierra, mapa.huertaMaiz.tierraList, semimaiz, key, regandoIn, plantandoIn, blop);

			for (int i = 0; i < mapa.pozoAlrededor.Length; i++)
			{
				if (rect.Intersects(mapa.pozoAlrededor[i]))
				{
					if (key.IsKeyDown(Keys.F))
					{
						if (agua < 100)
						{
							if (fuenteIn.State != SoundState.Playing)
							{
								fuenteIn.Play();
							}
							agua += 0.2f;
							aguaString = (int)agua + "%";
						}
					}
				}
			}

			rect = new Rectangle((int)pos.X + 6, (int)pos.Y + 42, 35, 5);

			objetoColision(gameTime, mapa.huertaCalabaza.vallaList, key);
			objetoColision(gameTime, mapa.huertaTomate.vallaList, key);
			objetoColision(gameTime, mapa.huertaMaiz.vallaList, key);
			objetoColision(gameTime, mapa.casa.paredesList, key);

			for (int i = 0; i < mapa.huertaCalabaza.alrededor.Length; i++)
			{
				if (rect.Intersects(mapa.huertaCalabaza.alrededor[i]))
				{
					if (key.IsKeyDown(Keys.F) && llaveC == true)
					{
						mapa.huertaCalabaza.desbloqueado = true; 
						llaveC = false;
					}
				}
			}

			for (int i = 0; i < mapa.huertaMaiz.alrededor.Length; i++)
			{
				if (rect.Intersects(mapa.huertaMaiz.alrededor[i]))
				{
					if (key.IsKeyDown(Keys.F) && llaveM == true)
					{
						mapa.huertaMaiz.desbloqueado = true;
						llaveM = false;
					}
				}
			}

			if (rect.Intersects(mapa.casa.puertaRect))
			{
				mapa.casa.puertaAbierta = true;
			}
			else
			{
				mapa.casa.puertaAbierta = false;
			}

			if (rect.Intersects(mapa.casa.pisoD))
			{
				mapa.casa.huesped = true;
			}

			if (rect.Intersects(mapa.casa.pisoF))
			{
				mapa.casa.huesped = false;
			}

			if (rect.Intersects(mapa.casa.pisoT) || rect.Intersects(mapa.casa.pisoT2))
			{
				if (key.IsKeyDown(Keys.F) && !enMenu)
				{
					enMenu = true;
				}
			}

			if (rect.Intersects(mapa.pozoRect))
			{
				if (key.IsKeyDown(Keys.Up))
				{ pos = new Vector2(pos.X, pos.Y + 1); }
				if (key.IsKeyDown(Keys.Down))
				{ pos = new Vector2(pos.X, pos.Y - 1); }
				if (key.IsKeyDown(Keys.Right))
				{ pos = new Vector2(pos.X - 1, pos.Y); }
				if (key.IsKeyDown(Keys.Left))
				{ pos = new Vector2(pos.X + 1, pos.Y); }
			}

			if (rect.Intersects(mapa.puente))
			{
				sobrePuente = true;
			}
			else
			{
				sobrePuente = false;
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			ani.Draw(spriteBatch, pos, Color.White, spriteEffect, 1f);
		}
		public void huertaColision(GameTime gameTime, Tierra[,] tierra, Rectangle[,] tierraList, Semilla semilla, KeyboardState key, SoundEffect regando, SoundEffect plantando, SoundEffect blop)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (rect.Intersects(tierraList[i, j]))
					{
						if (tierra[i, j].etapa == -1 && key.IsKeyDown(Keys.F) && semilla.cant > 0)
						{
							plantando.Play();
							tierra[i, j].etapa = 0;
							tierra[i, j].fueRegado = 1;
							semilla.cant -= 1;
						}

						if (tierra[i, j].etapa < 3 && tierra[i, j].etapa != -1)
						{
							if (tierra[i, j].fueRegado == 1)
							{
								if (key.IsKeyDown(Keys.Space) && agua > 5)
								{
									regando.Play();
									tierra[i, j].fueRegado = 2;
									agua -= 5;
									aguaString = (int)agua + "%";
								}
							}
						}
						if (tierra[i, j].etapa == 3)
						{
							if (key.IsKeyDown(Keys.Space))
							{
								plantando.Play();
								tierra[i, j].etapa = -1;
								tierra[i, j].fueRegado = 0;
								monedas += semilla.ganancia;
								monedasString = "" + monedas;
								if (semilla.cant<=24)
								{
									semilla.cant += semilla.devuelve;
								}
							}
						}
					}
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					tierra[i, j].Update(gameTime, blop);
				}
			}
		}

		public void objetoColision(GameTime gameTime, Rectangle[,] objeto, KeyboardState key)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (rect.Intersects(objeto[i, j]))
					{
						if (key.IsKeyDown(Keys.Up))
						{pos = new Vector2(pos.X, pos.Y + 1.5f);}
						if (key.IsKeyDown(Keys.Down))
						{pos = new Vector2(pos.X, pos.Y - 1.5f);}
						if (key.IsKeyDown(Keys.Right))
						{pos = new Vector2(pos.X - 1.5f, pos.Y);}
						if (key.IsKeyDown(Keys.Left))
						{pos = new Vector2(pos.X + 1.5f, pos.Y);}
					}
				}
			}
		}
		public void objetoColision(GameTime gameTime, List<Rectangle> objeto, KeyboardState key)
		{
			foreach (var pared in objeto)
			{
				if (rect.Intersects(pared))
				{
					if (key.IsKeyDown(Keys.Up))
					{ pos = new Vector2(pos.X, pos.Y + 1.5f); }
					if (key.IsKeyDown(Keys.Down))
					{ pos = new Vector2(pos.X, pos.Y - 1.5f); }
					if (key.IsKeyDown(Keys.Right))
					{ pos = new Vector2(pos.X - 1.5f, pos.Y); }
					if (key.IsKeyDown(Keys.Left))
					{ pos = new Vector2(pos.X + 1.5f, pos.Y); }
				}
			}
		}
	}
}
