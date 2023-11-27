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
		public Animacion ani;
		public Vector2 pos;

		public Tbh(Animacion ani, Vector2 pos)
		{
			this.ani = ani;
			this.pos = pos;
		}

		public void Update(GameTime gameTime, int vel) 
		{
			ani.Update(gameTime, vel);
		}
		public void Draw(SpriteBatch spriteBatch, int indiceTbh, SpriteEffects spriteEffects)
		{
			ani.Y = indiceTbh;
			ani.Draw(spriteBatch, pos, spriteEffects);
		}
	}
}
