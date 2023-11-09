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
		public Animacion tbh;
		public Texture2D tbhTexture;
		public Texture2D backgroundLv1;
		private Vector2 tbhPos = new Vector2(100, 100);
		public int indiceTbh;
		private SpriteEffects spriteEffect;
		float temp;
		bool cambioRealizado = false;

		int p = 1;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			tbhTexture = Content.Load<Texture2D>("img/tbhwalk");
			backgroundLv1 = Content.Load<Texture2D>("img/Background");
			spriteEffect = SpriteEffects.None;
			tbh = new Animacion(tbhTexture, tbhPos, spriteEffect, 300, 609, 609, indiceTbh, 6);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();
			if (key.GetPressedKeys().Length == 0 && p == 1)
			{
				indiceTbh = 3;

				p = 2;
				tbh.Update(gameTime);
			}
			else
			{
				temp+= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
				if (temp > 5000)
				{
					p = 1;
				}
			}
			
			if (key.IsKeyDown(Keys.Down))
			{
				indiceTbh = 0;
				tbh.Update(gameTime);
				tbh.pos.Y += 1;
			}
			if (key.IsKeyDown(Keys.Up))
			{
				indiceTbh = 1;
				tbh.Update(gameTime);
				tbh.pos.Y -= 1;
			}
			if (key.IsKeyDown(Keys.Left))
			{
				spriteEffect = SpriteEffects.None;
				indiceTbh = 2;
				tbh.Update(gameTime);
				tbh.pos.X -= 1;
			}
			if (key.IsKeyDown(Keys.Right))
			{
				spriteEffect = SpriteEffects.FlipHorizontally;
				indiceTbh = 2;
				tbh.Update(gameTime);
				tbh.pos.X += 1;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			_spriteBatch.Draw(backgroundLv1, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
			tbh.spriteEffect= spriteEffect;
			tbh.Y = indiceTbh;
			tbh.Draw(_spriteBatch);

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
