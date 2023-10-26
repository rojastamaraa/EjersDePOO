using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;

namespace El_juego
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D tbh;
		private Vector2 tbhPos = new Vector2(100, 100);
		private SpriteEffects spriteEffect;
		Rectangle[] sourceRectangles;
		int c = 0;
		int pix = 0;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			tbh = Content.Load<Texture2D>("img/tbhwalk"); 
			spriteEffect = SpriteEffects.None;
			// TODO: use this.Content to load your game content here

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

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here
			
			KeyboardState key = Keyboard.GetState();

			if (key.GetPressedKeys().Length == 0)
			{
				if (c <= 3)
				{
					c = 0;
				}
				else if (c > 3 && c <=7)
				{
					c = 4;
				}
				else
				{
					c = 8;
				}
			}

			if (key.IsKeyDown(Keys.Down))
			{
				tbhPos.Y += 2;
				pix += 1;
				if (c > 3)
				{
					c = 0;
				}
				if (c < 3 && pix > 5)
				{
					c = c + 1;
					pix = 0;
				}
				else if (c == 3 && pix > 5)
				{
					c = 0;
					pix = 0;
				}
			}
			if (key.IsKeyDown(Keys.Up))
			{
				tbhPos.Y -= 2;
				pix += 1;
				if (c > 7 || c < 4)
				{
					c = 4;
				}
				if (c < 7 && pix > 5)
				{
					c = c + 1;
					pix = 0;
				}
				else if (c == 7 && pix > 5)
				{
					c = 4;
					pix = 0;
				}

			}
			if (key.IsKeyDown(Keys.Left))
			{
				spriteEffect = SpriteEffects.None;
				tbhPos.X -= 2;
				pix += 1;
				if (c < 8)
				{
					c = 8;
				}
				if (c < 11 && pix > 5)
				{
					c = c + 1;
					pix = 0;
				}
				else if (c == 11 && pix > 5)
				{
					c = 8;
					pix = 0;
				}

			}
			if (key.IsKeyDown(Keys.Right))
			{
				spriteEffect = SpriteEffects.FlipHorizontally;
				tbhPos.X += 2;
				pix += 1;
				if (c < 8)
				{
					c = 8;
				}
				if (c < 11 && pix > 5)
				{
					c = c + 1;
					pix = 0;
				}
				else if (c == 11 && pix > 5)
				{
					c = 8;
					pix = 0;
				}

			}


			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			_spriteBatch.Begin();

			_spriteBatch.Draw(tbh, tbhPos, sourceRectangles[c], Color.White, 0f, Vector2.Zero, 0.1f, spriteEffect, 0f);

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}