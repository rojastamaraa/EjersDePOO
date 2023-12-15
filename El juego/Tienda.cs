using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace El_juego
{
	public class Item: Elemento
	{
		public int precio;

		public Item(Texture2D text, int ancho, int alto, int precio):base(text, ancho, alto)
		{
			this.precio = precio;
		}
	}
	public class Tienda
	{
		SpriteFont test;
		public Elemento fondo, boton; 
		public Item madera, llaveCalabaza, llaveMaiz, semillaCalabaza, semillaMaiz;
		public bool teclaPresionada;
		public int indice, llaveC, llaveM, semillaC, semillaM, maderaCant;

		public Tienda(Elemento fondo, Elemento boton, Texture2D maderat,Texture2D llaveYsst, SpriteFont test)
		{
			this.fondo = fondo;
			this.boton = boton;
			this.test = test;
			llaveC = 1;
			llaveM = 1;
			semillaC = 10;
			semillaM = 10;
			maderaCant = 5;
			madera = new Item(maderat, 16, 16, 1000);
			llaveCalabaza = new Item(llaveYsst, 16, 16, 600);
			llaveMaiz = new Item(llaveYsst, 16, 16, 300);
			semillaCalabaza = new Item(llaveYsst, 16, 16, 200);
			semillaMaiz = new Item(llaveYsst, 16, 16, 100);
		}

		public void Update(GameTime gameTime, KeyboardState key)
		{
			if (key.IsKeyDown(Keys.Down) && !teclaPresionada)
			{
				teclaPresionada = true;

				if (indice < 4)
				{
					indice++;
				}
				else
				{
					indice = 0;
				}
			}
			else if (key.IsKeyDown(Keys.Up) && !teclaPresionada)
			{
				teclaPresionada = true;

				if (indice > 0)
				{
					indice--;
				}
				else
				{
					indice = 4;
				}
			}

			if (key.IsKeyUp(Keys.Down) && key.IsKeyUp(Keys.Up))
			{
				teclaPresionada = false;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(fondo.tex, new Vector2(440, 100), new Rectangle(128, 0, fondo.ancho, fondo.alto), Color.White, 0f, Vector2.Zero, 2.1f, SpriteEffects.None, 0f);

			for (int i = 0; i < 5; i++)
			{
				spriteBatch.Draw(boton.tex, new Vector2(472, 125 + boton.alto * i), new Rectangle(0, 0, boton.ancho, boton.alto), Color.White);
			}
			for (int i = 0; i < 5; i++)
			{
				if (indice == i)
				{
					spriteBatch.Draw(boton.tex, new Vector2(472, 125 + boton.alto*i), new Rectangle(48, 0, boton.ancho, boton.alto), Color.White);
				}
			}
			int X = 488;
			spriteBatch.Draw(llaveCalabaza.tex, new Vector2(X, 125+16), new Rectangle(0, 0, 16, 16), Color.White);
			spriteBatch.DrawString(test,  "Huerta de Cbz $600" + " " +llaveC + "/1", new Vector2(X + 24, 125 + 16), Color.Brown, 0f, Vector2.Zero, 0.90f, SpriteEffects.None, 0f);
			spriteBatch.Draw(llaveMaiz.tex, new Vector2(X, 125 + 16*4), new Rectangle(16, 0, 16, 16), Color.White);
			spriteBatch.DrawString(test, "Huerta de maiz $300" + " " + llaveM + "/1", new Vector2(X + 24, 125 + 16 * 4), Color.Brown, 0f, Vector2.Zero, 0.90f, SpriteEffects.None, 0f);
			spriteBatch.Draw(semillaCalabaza.tex, new Vector2(X, 125 + 16*7), new Rectangle(0, 16, 16, 16), Color.White);
			spriteBatch.DrawString(test, "Sems. de Cza. $200" + " " + semillaC + "/10", new Vector2(X + 24, 125 + 16 * 7), Color.Brown, 0f, Vector2.Zero, 0.90f, SpriteEffects.None, 0f);
			spriteBatch.Draw(semillaMaiz.tex, new Vector2(X, 125 + 16*10), new Rectangle(16, 16, 16, 16), Color.White);
			spriteBatch.DrawString(test, "Sems. de maiz $100" + " " + semillaM + "/10", new Vector2(X + 24, 125 + 16 * 10), Color.Brown, 0f, Vector2.Zero, 0.90f, SpriteEffects.None, 0f);
			spriteBatch.Draw(madera.tex, new Vector2(X, 125 + 16 * 13), new Rectangle(32, 32, 32, 32), Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
			spriteBatch.DrawString(test, "Madera $1000" + " " + maderaCant + "/5", new Vector2(X + 24, 125 + 16 * 13), Color.Brown, 0f, Vector2.Zero, 0.90f, SpriteEffects.None, 0f);
		}
	}
}
