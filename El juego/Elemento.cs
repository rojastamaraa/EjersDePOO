using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_juego
{
	public class Elemento
	{
		public Texture2D tex;
		public int ancho, alto;	
		public Elemento(Texture2D text, int ancho, int alto)
		{
			this.tex = text;
			this.ancho = ancho;
			this.alto = alto;
		}
	}
}
