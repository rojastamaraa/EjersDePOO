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
		private Vector2 tbhPos = new Vector2(100, 100);
		public int indiceTbh;
		private SpriteEffects spriteEffect;

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
			tbhTexture = Content.Load<Texture2D>("img/tbhwalk");
			spriteEffect = SpriteEffects.None;
			tbh = new Animacion(tbhTexture, tbhPos, spriteEffect, 200, 609, 609, 0, indiceTbh, 4);

		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();
			if (key.GetPressedKeys().Length == 0)
			{
				tbh.frameActual = 0;
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

			tbh.spriteEffect= spriteEffect;
			tbh.Y = indiceTbh;
			tbh.Draw(_spriteBatch);

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
