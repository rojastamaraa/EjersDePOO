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
		public Texture2D Texture;
		public Rectangle[,] tierraList;
		public Tierra[,] tierra;
		public Vector2 pos;
		public string tipo;
		public int ancho, alto;
		public float escala;
		public Huerta(string tipo, Vector2 pos)
		{
			this.tipo = tipo;
			this.pos = pos;
			tierraList = new Rectangle[4, 6];
			tierra = new Tierra[4, 6];
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					tierraList[i,j]= new Rectangle((int)pos.X + 31 * j, (int)pos.Y + 31 * i, 32, 32);
					tierra[i, j] = new Tierra(new Vector2((int)pos.X + 31 * j, (int)pos.Y + 31 * i));
				}
			}

			ancho = 16;
			alto = 16;
		}

		public void Draw(SpriteBatch spriteBatch, Texture2D tierraText, Texture2D cultivo)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					spriteBatch.Draw(tierraText, tierra[i,j].pos, new Rectangle(tierra[i,j].fueRegado * 16, 16, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					spriteBatch.Draw(cultivo, new Vector2((int)pos.X + 31 * j, ((int)pos.Y - 5) + 31 * i), new Rectangle(tierra[i, j].etapa * ancho, 0,ancho, alto), Color.White, 0f, Vector2.Zero, 1.9f, SpriteEffects.None, 0f);
				}
			}
		}
	}
}
