using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace El_juego
{
	public class Huerta
	{
		public Texture2D Texture, madera;
		public Rectangle[,] tierraList, vallaList;
		public Rectangle[] alrededor;
		public Tierra[,] tierra;
		public Elemento valla, vallaLateral, vallaLateralFin;
		public Vector2 pos;
		public string tipo;
		public bool desbloqueado;
		public Huerta(string tipo, Vector2 pos, Elemento valla, Elemento vallaLateral, Elemento vallaLateralFin, Texture2D madera)
		{
			this.tipo = tipo;
			this.pos = pos;
			this.valla = valla;
			this.vallaLateral = vallaLateral;
			this.vallaLateralFin = vallaLateralFin;
			this.madera = madera;
			tierraList = new Rectangle[4, 6];
			vallaList = new Rectangle[4, 6];
			tierra = new Tierra[4, 6];
			alrededor = new Rectangle[4];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					tierraList[i,j]= new Rectangle((int)pos.X + 32 * j, (int)pos.Y + 32 * i, 32, 32);
					tierra[i, j] = new Tierra(new Vector2((int)pos.X + 32 * j, (int)pos.Y + 32 * i));
				}
			}

			alrededor[0] = new Rectangle((int)pos.X - 32, (int)pos.Y + 32, 32, 32);
			alrededor[1] = new Rectangle((int)pos.X - 32, (int)pos.Y + 64, 32, 32);
			alrededor[2] = new Rectangle((int)pos.X + 192, (int)pos.Y + 32, 32, 32);
			alrededor[3] = new Rectangle((int)pos.X + 192, (int)pos.Y + 64, 32, 32);
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D tierraText, Texture2D cultivo)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					spriteBatch.Draw(tierraText, tierra[i,j].pos, new Rectangle(tierra[i,j].fueRegado * 16, 16, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					spriteBatch.Draw(cultivo, new Vector2(((int)pos.X + 4) + 31 * j, ((int)pos.Y) + 32 * i), new Rectangle(tierra[i, j].etapa * 16, 0,16, 16), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
				}
			}

			//Vallas
			if (tipo == "tomate")
			{
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						if (i == 0)
						{
							Vector2 poss = new Vector2(pos.X + valla.ancho * j, (pos.Y - valla.alto) + valla.alto * i * 2.6f);
							vallaList[i, j] = new Rectangle((int)pos.X + valla.ancho * j, (int)((pos.Y - valla.alto) + valla.alto * i * 2.6f), valla.ancho, valla.alto);
							spriteBatch.Draw(valla.tex, poss, new Rectangle(0, 0, valla.ancho, valla.alto), Color.White);
						}
						if (i < 3)
						{
							if (j == 0 || j == 5)
							{
								Vector2 poss = new Vector2((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f, (pos.Y - valla.alto - 3) + vallaLateral.alto * i);
								vallaList[i, j] = new Rectangle((int)((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f), (int)((pos.Y - valla.alto - 3) + vallaLateral.alto * i), vallaLateral.ancho, vallaLateral.alto);
								spriteBatch.Draw(vallaLateral.tex, poss, new Rectangle(0, 0, vallaLateral.ancho, vallaLateral.alto), Color.White);
							}
						}
					}
				}
			}
			else
			{
				if (desbloqueado == false)
				{
					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < 6; j++)
						{
							if (i == 0 || i == 3)
							{
								Vector2 poss = new Vector2(pos.X + valla.ancho * j, (pos.Y - valla.alto) + valla.alto * i * 2.6f);
								vallaList[i, j] = new Rectangle((int)pos.X + valla.ancho * j, (int)((pos.Y - valla.alto) + valla.alto * i * 2.6f), valla.ancho, valla.alto);
								spriteBatch.Draw(valla.tex, poss, new Rectangle(0, 0, valla.ancho, valla.alto), Color.White);
							}
							if (i < 4)
							{
								if (j == 0 || j == 5)
								{
									Vector2 poss = new Vector2((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f, (pos.Y - valla.alto - 3) + vallaLateral.alto * i);
									vallaList[i, j] = new Rectangle((int)((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f), (int)((pos.Y - valla.alto - 3) + vallaLateral.alto * i), vallaLateral.ancho, vallaLateral.alto);
									spriteBatch.Draw(vallaLateral.tex, poss, new Rectangle(0, 0, vallaLateral.ancho, vallaLateral.alto), Color.White);
								}
							}
						}
					}
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < 6; j++)
						{
							if (i == 0 || i == 3)
							{
								Vector2 poss = new Vector2(pos.X + valla.ancho * j, (pos.Y - valla.alto) + valla.alto * i * 2.6f);
								vallaList[i, j] = new Rectangle((int)pos.X + valla.ancho * j, (int)((pos.Y - valla.alto) + valla.alto * i * 2.6f), valla.ancho, valla.alto);
								spriteBatch.Draw(valla.tex, poss, new Rectangle(0, 0, valla.ancho, valla.alto), Color.White);
							}
							if (i < 1 || i > 2)
							{
								if (j == 0 || j == 5)
								{
									Vector2 poss = new Vector2((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f, (pos.Y - valla.alto - 3) + vallaLateral.alto * i);
									vallaList[i, j] = new Rectangle((int)((pos.X - vallaLateral.ancho) + vallaLateral.ancho * j * 5.7f), (int)((pos.Y - valla.alto - 3) + vallaLateral.alto * i), vallaLateral.ancho, vallaLateral.alto);
									spriteBatch.Draw(vallaLateral.tex, poss, new Rectangle(0, 0, vallaLateral.ancho, vallaLateral.alto), Color.White);
								}
							}
							if (i == 1 || i == 2)
							{
								if (j == 0 || j == 5)
								{
									vallaList[i, j] = new Rectangle();
								}
							}
						}
					}
				}
			}

			//Alrededor

			if (tipo != "tomate")
			{
				//alrededor[0] = new Rectangle((int)pos.X - 32, (int)pos.Y + 32, 32, 32);
				//alrededor[1] = new Rectangle((int)pos.X - 32, (int)pos.Y + 64, 32, 32);
				//alrededor[2] = new Rectangle((int)pos.X + 192, (int)pos.Y + 32, 32, 32);
				//alrededor[3] = new Rectangle((int)pos.X + 192, (int)pos.Y + 64, 32, 32);
				spriteBatch.Draw(madera, new Vector2((int)pos.X - 40, (int)pos.Y + 32), new Rectangle(64, 32, 32, 32), Color.White);
				spriteBatch.Draw(madera, new Vector2((int)pos.X - 40, (int)pos.Y + 64), new Rectangle(64, 32, 32, 32), Color.White);
				spriteBatch.Draw(madera, new Vector2((int)pos.X + 200, (int)pos.Y + 32), new Rectangle(64, 32, 32, 32), Color.White);
				spriteBatch.Draw(madera, new Vector2((int)pos.X + 200, (int)pos.Y + 64), new Rectangle(64, 32, 32, 32), Color.White);
			}
		}
	}
}
