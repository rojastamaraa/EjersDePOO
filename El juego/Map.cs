using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace El_juego
{
	public class Map
	{
		public int altura, ancho;
		public Elemento pasto, valla, vallaLateral, vallaLateralFin;
		static Random r = new Random();
		int[,] r2 = new int[62, 100];
		int[,] r3 = new int[62, 100];

		public Huerta huertaCalabaza, huertaMaiz, huertaTomate;

		public Casa casa;
		public Elemento suelo, paredes, puerta, pozo, arbol;

		public Animacion agua, agua2, pozoA;

		public Rectangle[] pozoAlrededor;

		public Rectangle puente, pozoRect;

		public Map(
					Elemento pasto, Elemento valla, Elemento vallaLateral, Elemento vallaLateralFin, 
					Elemento suelo, Elemento paredes, Elemento puerta, Elemento techo, Elemento mueble, Elemento cama,
					Texture2D aguaT, Elemento pozo, Elemento arbol, Texture2D madera
				  )
		{
			altura = 992;
			ancho = 1344;
			this.pasto = pasto;
			this.valla = valla;
			this.vallaLateral = vallaLateral;
			this.vallaLateralFin = vallaLateralFin;
			this.suelo = suelo;
			this.paredes = paredes;
			this.puerta = puerta;
			this.pozo = pozo;
			this.arbol = arbol;
			agua = new Animacion(aguaT, 16, 16, 0, 4);
			agua2 = new Animacion(aguaT, 16, 16, 1, 4);
			pozoA = new Animacion(pozo.tex, 64, 64, 0, 2);

			for (int i = 0; i < altura/32; i++)
			{
				for (int j = 0; j < ancho/32; j++)
				{
					r2[i, j] = r.Next(0, 5);
					r3[i,j]=r.Next(0, 2);
				}
			}
			
			huertaCalabaza = new Huerta("calabaza", new Vector2(192, 432 + 52), valla, vallaLateral, vallaLateralFin, madera);
			huertaTomate = new Huerta("tomate", new Vector2(576, 432 + 52), valla, vallaLateral, vallaLateralFin, madera);
			huertaMaiz = new Huerta("maiz", new Vector2(960, 432 + 52), valla, vallaLateral, vallaLateralFin, madera);
			
			casa = new Casa(suelo, paredes, puerta, techo, mueble, cama);
			pozoRect = new Rectangle(640, 800, pozo.ancho, pozo.alto);
			pozoAlrededor = new Rectangle[4];
			pozoAlrededor[0] = new Rectangle(608, 768, 128, 32);
			pozoAlrededor[1] = new Rectangle(608, 864, 128, 32);
			pozoAlrededor[2] = new Rectangle(608, 768, 32, 128);
			pozoAlrededor[3] = new Rectangle(704, 768, 32, 128);
			puente = new Rectangle(645, 985, 48, 144);
		}

		public void Update(GameTime gameTime)
		{
			agua.Update(gameTime, 500);
			agua2.Update(gameTime, 500);
			pozoA.Update(gameTime, 400);
		}
		public void Draw(SpriteBatch spriteBatch, Texture2D tierraText, Texture2D cebolla, Texture2D maiz, Texture2D tomate, Texture2D madera)
		{
			//Pasto
			int Y = altura / 32;
			int X = ancho / 32;
			for (int i = 0; i < Y; i++)
			{
				for (int j = 0; j < X; j++)
				{
					Rectangle rect = new Rectangle(r2[i, j] * pasto.ancho, 0, pasto.ancho, pasto.alto);
					Vector2 pos = new Vector2(32 * j, 32 * i);
					spriteBatch.Draw(pasto.tex, pos, rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				}
			}

			//Agua
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < X; j++)
				{
					if (i == 0)
					{
						agua2.Draw(spriteBatch, new Vector2(32 * j, 992 + 32 * i), Color.White, SpriteEffects.None, 2f);
					}
					else
					{
						agua.Draw(spriteBatch, new Vector2(32 * j, 992 + 32 * i), Color.White, SpriteEffects.None, 2f);
					}
				}
			}

			for (int i = 0; i < Y; i++)
			{
				for (int j = 0; j < X; j++)
				{
					if (i == 0)
					{
						if (j < 25)
						{
							Rectangle rect = new Rectangle(0, 0, arbol.ancho, arbol.alto);
							Vector2 pos = new Vector2(j * arbol.ancho, arbol.alto * i);
							spriteBatch.Draw(arbol.tex, pos, rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
						}
					}
					if (i == 0)
					{
						if (j < 36)
						{
							spriteBatch.Draw(valla.tex, new Vector2(100 + valla.ancho * j, 90), new Rectangle(0, 0, valla.ancho, valla.alto), Color.White);
						}
					}

					if (i < 12)
					{
						if (j == 0 || j == 25)
						{
							Rectangle rect = new Rectangle(0, 0, arbol.ancho, arbol.alto);
							Vector2 pos = new Vector2(j * arbol.ancho, 80 * i);
							spriteBatch.Draw(arbol.tex, pos, rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
						}
					}
					if (i < 21)
					{
						if (j == 0 || j == 36)
						{
							spriteBatch.Draw(vallaLateral.tex, new Vector2(94 + valla.ancho * j, 90 + vallaLateral.alto * i), new Rectangle(0, 0, vallaLateral.ancho, vallaLateral.alto), Color.White);
						}
					}
				}
			}

			pozoA.Draw(spriteBatch, new Vector2(640, 800), Color.White, SpriteEffects.None, 1f);

			spriteBatch.Draw(madera, new Vector2(645, 970), new Rectangle(0, 0, 32, 96), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);

			//Huertas
			huertaCalabaza.Draw(spriteBatch, tierraText, cebolla);
			huertaTomate.Draw(spriteBatch, tierraText, tomate);
			huertaMaiz.Draw(spriteBatch, tierraText, maiz);
			casa.Draw(spriteBatch);
		}
	}
}
