using Microsoft.Xna.Framework;
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
	public class Tbh
	{
		public Animacion ani;
		public Vector2 pos;
		public Rectangle rect;
		private SpriteEffects spriteEffect;
		public string testeo = "";
		public Tbh(Animacion ani, Vector2 pos)
		{
			this.ani = ani;
			this.pos = pos;
		}

		public void Update(GameTime gameTime, Map mapa, KeyboardState key)
		{
			//Movimiento
			if (key.IsKeyDown(Keys.Down))
			{ pos.Y += 1; ani.Y = 0; ani.Update(gameTime, 150); }
			if (key.IsKeyDown(Keys.Up))
			{ pos.Y -= 1; ani.Y = 1; ani.Update(gameTime, 150); }
			if (key.IsKeyDown(Keys.Left))
			{ pos.X -= 1; ani.Y = 2; spriteEffect = SpriteEffects.None; ani.Update(gameTime, 150); }
			if (key.IsKeyDown(Keys.Right))
			{ pos.X += 1; ani.Y = 2; spriteEffect = SpriteEffects.FlipHorizontally; ani.Update(gameTime, 150); }
			if (key.GetPressedKeys().Length == 0) { ani.frameActual = 0; }

			testeo = "fuera";

			//Colisiones
			rect = new Rectangle((int)pos.X + 49 / 2, (int)pos.Y + 45, 1, 1);

			huertaColision(gameTime, mapa.huertaCalabaza.tierra, mapa.huertaCalabaza.tierraList, key);
			huertaColision(gameTime, mapa.huertaTomate.tierra, mapa.huertaTomate.tierraList, key);
			huertaColision(gameTime, mapa.huertaMaiz.tierra, mapa.huertaMaiz.tierraList, key);

			rect = new Rectangle((int)pos.X + 6, (int)pos.Y + 32, 35, 15);

			vallasColision(gameTime, mapa.huertaCalabaza.vallaList, key);
			vallasColision(gameTime, mapa.huertaTomate.vallaList, key);
			vallasColision(gameTime, mapa.huertaMaiz.vallaList, key);

			if (key.IsKeyDown(Keys.A))
			{
				mapa.huertaCalabaza.desbloqueado = true;
			}			
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			ani.Draw(spriteBatch, pos, spriteEffect);
		}
		public void huertaColision(GameTime gameTime, Tierra[,] tierra, Rectangle[,] tierraList, KeyboardState key)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (rect.Intersects(tierraList[i, j]))
					{
						testeo = "Tierra: " + i + "," + j;
						if (tierra[i, j].etapa == -1 && key.IsKeyDown(Keys.F))
						{
							tierra[i, j].etapa = 0;
							tierra[i, j].fueRegado = 1;
						}

						if (tierra[i, j].etapa < 3 && tierra[i, j].etapa != -1)
						{
							if (tierra[i, j].fueRegado == 1)
							{
								if (key.IsKeyDown(Keys.Space))
								{
									tierra[i, j].fueRegado = 2;
								}
							}
						}
						if (tierra[i, j].etapa == 3)
						{
							if (key.IsKeyDown(Keys.Space))
							{
								tierra[i, j].etapa = -1;
								tierra[i, j].fueRegado = 0;
							}
						}
					}
				}
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					tierra[i, j].Update(gameTime);
				}
			}
		}

		public void vallasColision(GameTime gameTime, Rectangle[,] vallaList, KeyboardState key)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					if (rect.Intersects(vallaList[i, j]))
					{
						if (key.IsKeyDown(Keys.Up))
						{pos = new Vector2(pos.X, pos.Y + 1);}
						if (key.IsKeyDown(Keys.Down))
						{pos = new Vector2(pos.X, pos.Y - 1);}
						if (key.IsKeyDown(Keys.Right))
						{pos = new Vector2(pos.X - 1, pos.Y);}
						if (key.IsKeyDown(Keys.Left))
						{pos = new Vector2(pos.X + 1, pos.Y);}
					}
				}
			}
		}
	}
}
