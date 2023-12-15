using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace El_juego
{
	public class Casa
	{
		public Elemento techo, paredes, suelo, puerta, mueble, cama;
		public List<Rectangle> paredesList;
		public Rectangle puertaRect, pisoD, pisoF, pisoT, pisoT2;
		public bool puertaAbierta, huesped;

		public Casa(Elemento suelo, Elemento paredes, Elemento puerta, Elemento techo, Elemento mueble, Elemento cama)
		{
			//this.techo = techo;
			this.paredes = paredes;
			this.suelo = suelo;
			this.puerta = puerta;
			this.techo = techo;
			this.mueble = mueble;
			this.cama = cama;


			paredesList = new List<Rectangle>
			{
				new Rectangle(528, 192+ 52 -48, 120, 48),
				new Rectangle(696, 192 + 52 -48, 120, 48),
				new Rectangle(528, 52, 15, 144),
				new Rectangle(801, 52, 15, 144),
				new Rectangle(528, 52, 288, 48),
				new Rectangle(528 + 16, 82, mueble.ancho, mueble.alto),
				new Rectangle(758, 82, cama.ancho, cama.alto)
			};

			puertaRect = new Rectangle(648, 144 + 52, 48, 48);
			pisoD = new Rectangle(648, 144 + 52, 48, 48);
			pisoF = new Rectangle(648, 192 + 52, 48, 48);
			pisoT = new Rectangle(528 + 16 + mueble.ancho, 30 + 52, 30, 30);
			pisoT2 = new Rectangle(528 + 16, 52 + 30 + mueble.alto, 30, 30);
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 6; j++)
				{
					Vector2 pos = new Vector2(528 + suelo.ancho*j, 52 +  suelo.alto + suelo.alto*i);
					spriteBatch.Draw(suelo.tex, pos, new Rectangle(48, 96, suelo.ancho, suelo.alto), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				}
			}

			spriteBatch.Draw(paredes.tex, new Vector2(528, 52), new Rectangle(0, 0, 288, 192), Color.White);

			spriteBatch.Draw(mueble.tex, new Vector2(528 + 16, 82), new Rectangle(0, 0, mueble.ancho, mueble.alto), Color.White);
			spriteBatch.Draw(cama.tex, new Vector2(758, 82), new Rectangle(0, 0, cama.ancho, cama.alto), Color.White);

			if (puertaAbierta == false)
			{
				spriteBatch.Draw(puerta.tex, new Vector2(648, 196), new Rectangle(144, 48, puerta.ancho, puerta.alto), Color.White);
			}
			else
			{
				spriteBatch.Draw(puerta.tex, new Vector2(648, 196), new Rectangle(144, 96, puerta.ancho, puerta.alto), Color.White);
			}

			if (huesped == false)
			{
				spriteBatch.Draw(techo.tex, new Vector2(528, 26), new Rectangle(0, 0, techo.ancho, techo.alto), Color.White);
			}
		}
	}
}
