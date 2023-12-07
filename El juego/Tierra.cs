using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_juego
{
	public class Tierra
	{
		public Vector2 pos;
		public bool tieneCultivos;
		public int etapa, fueRegado;
		public float temporizador;

		public Tierra(Vector2 pos)
		{

			etapa = -1;
			this.pos = pos;
		}

		public void Update(GameTime gameTime)
		{
			if (fueRegado == 2)
			{
				temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				if (temporizador > 2000)
				{
					fueRegado = 1;
					etapa++;
					temporizador = 0;
				}
				
			}
		}
	}
}
