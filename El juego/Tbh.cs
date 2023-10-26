using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace El_juego
{
	public class Tbh
	{
		private Texture2D tbh;
		private Vector2 tbhPos;
		private SpriteEffects spriteEffect;
		Rectangle[] sourceRectangles;
		int c = 0;
		int pix = 0;

		public Tbh()
		{
			
			tbhPos = new Vector2(50, 50);
			spriteEffect = SpriteEffects.None;
			sourceRectangles = new Rectangle[12];
			sourceRectangles[0] = new Rectangle(0, 0, 609, 609);
			sourceRectangles[1] = new Rectangle(609, 0, 609, 609);
			sourceRectangles[2] = new Rectangle(1218, 0, 609, 609);
			sourceRectangles[3] = new Rectangle(1827, 0, 609, 609);

			sourceRectangles[4] = new Rectangle(0, 609, 609, 609);
			sourceRectangles[5] = new Rectangle(609, 609, 609, 609);
			sourceRectangles[6] = new Rectangle(1218, 609, 609, 609);
			sourceRectangles[7] = new Rectangle(1827, 609, 609, 609);

			sourceRectangles[8] = new Rectangle(0, 1218, 609, 609);
			sourceRectangles[9] = new Rectangle(609, 1218, 609, 609);
			sourceRectangles[10] = new Rectangle(1218, 1218, 609, 609);
			sourceRectangles[11] = new Rectangle(1827, 1218, 609, 609);

		}
	}
}
