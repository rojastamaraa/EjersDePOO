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
		public Elemento pasto;
		static Random r = new Random();
		int[,] r2 = new int[62, 100];
		public Elemento tierra;
		public List<Rectangle> tierraList = new List<Rectangle>();

		public Map(Elemento pasto, Elemento tierra)
		{
			altura = 1000;
			ancho = 1600;
			this.pasto = pasto;
			this.tierra = tierra;

			for (int i = 0; i < 62; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					r2[i, j] = r.Next(0, 5);
				}
			}

			int parcelas = 192;
			for (int t = 0; t < 3; t++)
			{
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						Vector2 pos = new Vector2(parcelas + 31 * j, 320 + 31 * i);
						tierraList.Add(new Rectangle((int)pos.X, (int)pos.Y, tierra.ancho, tierra.alto));
					}

				}
				if (t == 0) { parcelas = parcelas * 3; }
				else { parcelas = parcelas + 192 * 2; }
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			//Pasto
			int Y = altura / 32;
			int X = ancho / 32;
			for (int i = 0; i < Y; i++)
			{
				for (int j = 0; j < X; j++)
				{
					pasto.rect = new Rectangle(r2[i, j] * pasto.ancho, 0, pasto.ancho, pasto.alto);
					Vector2 pos = new Vector2(31 * j, 31 * i);
					spriteBatch.Draw(pasto.tex, pos, pasto.rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				}
			}

			//Tierra
			int parcelas = 192;
			for (int t = 0; t < 3; t++){ 
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 6; j++)
					{
						Vector2 pos = new Vector2(parcelas + 31 * j, 320 + 31 * i);
						spriteBatch.Draw(tierra.tex, pos, tierra.rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					}
				}
				if (t == 0) { parcelas = parcelas * 3; }
				else { parcelas = parcelas + 192*2; }
			}
		}
	}
}
