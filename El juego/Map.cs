using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace El_juego
{
	public class Map
	{
		public Elemento pasto;
		static Random r = new Random();
		int[,] r2 = new int[62, 100];
		public Map(Elemento pasto)
		{
			this.pasto = pasto;

			for (int i = 0; i < 62; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					r2[i, j] = r.Next(0,3);
				}
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			int Y = 62;
			int X = 1600 / 16;
			for (int i = 0; i < Y; i++)
			{
				for (int j = 0; j < X; j++)
				{
					Rectangle rec = new Rectangle(r2[i,j]*pasto.ancho, pasto.Y, pasto.ancho, pasto.alto);
					Vector2 pos = new Vector2(pasto.ancho* j, pasto.alto* i);
					spriteBatch.Draw(pasto.tex, pos, rec, Color.White);
				}
			}
		}
	}
}