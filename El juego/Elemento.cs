using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_juego
{
	public class Elemento
	{
		public Texture2D tex;
		public int ancho, alto, Y, X;		
		public Elemento(Texture2D text, int ancho, int alto, int Y, int X)
		{
			this.tex = text;
			this.ancho = ancho;
			this.alto = alto;
			this.Y = Y;
			this.X = X;
		}
	}
}
