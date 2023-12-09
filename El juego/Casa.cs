using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace El_juego
{
	public class Casa
	{
		public Elemento techo, paredes, suelo, puerta;
		public List<Rectangle> paredesList;
		public Rectangle puertaRect, pisoD, pisoF;
		public bool puertaAbierta, huesped;

		public Casa(/*Elemento techo,*/ Elemento suelo, Elemento paredes, Elemento puerta, Elemento techo)
		{
			//this.techo = techo;
			this.paredes = paredes;
			this.suelo = suelo;
			this.puerta = puerta;
			this.techo = techo;


			paredesList = new List<Rectangle>
			{
				new Rectangle(528, 192-48, 120, 48),
				new Rectangle(696, 192-48, 120, 48),
				new Rectangle(528, 0, 15, 144),
				new Rectangle(801, 0, 15, 144),
				new Rectangle(528, 0, 288, 48)
			};

			puertaRect = new Rectangle(648, 144, 48, 48);
			pisoD = new Rectangle(648, 144, 48, 48);
			pisoF = new Rectangle(648, 192, 48, 48);
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					Vector2 pos = new Vector2(528 + suelo.ancho*j, suelo.alto + suelo.alto*i);
					spriteBatch.Draw(suelo.tex, pos, new Rectangle(48, 96, suelo.ancho, suelo.alto), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				}
			}

			spriteBatch.Draw(paredes.tex, new Vector2(528, 0), new Rectangle(0, 0, 288, 192), Color.White);

			if (puertaAbierta == false)
			{
				spriteBatch.Draw(puerta.tex, new Vector2(648, 144), new Rectangle(144, 48, puerta.ancho, puerta.alto), Color.White);
			}
			else
			{
				spriteBatch.Draw(puerta.tex, new Vector2(648, 144), new Rectangle(144, 96, puerta.ancho, puerta.alto), Color.White);
			}

			if (huesped == false)
			{
				spriteBatch.Draw(techo.tex, new Vector2(528, 0), new Rectangle(0, 26, techo.ancho, techo.alto), Color.White);
			}
		}
	}
}
