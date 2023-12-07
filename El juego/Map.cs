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

		//Huertas
		public Huerta huertaCepibolla;
		public Huerta huertaMaiz;
		public Huerta huertaTomate;

		public Map(Elemento pasto)
		{
			altura = 1000;
			ancho = 1600;
			this.pasto = pasto;

			for (int i = 0; i < 62; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					r2[i, j] = r.Next(0, 5);
				}
			}

			huertaCepibolla = new Huerta("calabaza", new Vector2(192, 320));
			huertaMaiz = new Huerta("maiz", new Vector2(576, 320));
			huertaTomate = new Huerta("tomate", new Vector2(960, 320));
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D tierraText, Texture2D cebolla, Texture2D maiz, Texture2D tomate)
		{
			//Pasto
			int Y = altura / 32;
			int X = ancho / 32;
			for (int i = 0; i < Y; i++)
			{
				for (int j = 0; j < X; j++)
				{
					Rectangle rect = new Rectangle(r2[i, j] * pasto.ancho, 0, pasto.ancho, pasto.alto);
					Vector2 pos = new Vector2(31 * j, 31 * i);
					spriteBatch.Draw(pasto.tex, pos, rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				}
			}
			 
			//Huertas
			huertaCepibolla.Draw(spriteBatch, tierraText, cebolla);
			huertaMaiz.Draw(spriteBatch, tierraText, maiz);
			huertaTomate.Draw(spriteBatch, tierraText, tomate);

		}
	}
}
