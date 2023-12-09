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

		public Huerta huertaCalabaza, huertaMaiz, huertaTomate;

		public Casa casa;
		public Elemento suelo, paredes, puerta;

		public Map(
					Elemento pasto, Elemento valla, Elemento vallaLateral, Elemento vallaLateralFin, 
					Elemento suelo, Elemento paredes, Elemento puerta, Elemento techo
				  )
		{
			altura = 1000;
			ancho = 1600;
			this.pasto = pasto;
			this.valla = valla;
			this.vallaLateral = vallaLateral;
			this.vallaLateralFin = vallaLateralFin;
			this.suelo = suelo;
			this.paredes = paredes;
			this.puerta = puerta;

			for (int i = 0; i < 62; i++)
			{
				for (int j = 0; j < 100; j++)
				{
					r2[i, j] = r.Next(0, 5);
				}
			}
			
			huertaCalabaza = new Huerta("calabaza", new Vector2(192, 432), valla, vallaLateral, vallaLateralFin);
			huertaTomate = new Huerta("tomate", new Vector2(576, 432), valla, vallaLateral, vallaLateralFin);
			huertaMaiz = new Huerta("maiz", new Vector2(960, 432), valla, vallaLateral, vallaLateralFin);
			
			casa = new Casa(suelo, paredes, puerta, techo);
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
					Vector2 pos = new Vector2(32 * j, 32 * i);
					spriteBatch.Draw(pasto.tex, pos, rect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				}
			}
			 
			//Huertas
			huertaCalabaza.Draw(spriteBatch, tierraText, cebolla);
			huertaTomate.Draw(spriteBatch, tierraText, tomate);
			huertaMaiz.Draw(spriteBatch, tierraText, maiz);
			casa.Draw(spriteBatch);
		}
	}
}
