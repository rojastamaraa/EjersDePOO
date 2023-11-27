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
		public Tbh tbh;
		public Animacion tbhAni;
		public Texture2D tbhTexture;
		private Vector2 tbhPos = new Vector2(100, 100);
		public int indiceTbh;
		public int vel = 150;
		public Texture2D backgroundLv1;
		private SpriteEffects spriteEffect;
		//float temp, temp2;
  //      bool parpadeo = false;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.IsFullScreen = false;
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
			tbhAni = new Animacion(tbhTexture, 609, 609, indiceTbh, 4);
			tbh = new Tbh(tbhAni, tbhPos);
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();
            if (key.GetPressedKeys().Length == 0)
			{
				tbh.ani.frameActual = 0;
			}

            if (key.IsKeyDown(Keys.Down))
			{
				if (key.IsKeyDown(Keys.LeftShift))
				{
					tbh.pos.Y += 2;
					vel = 80;
				}
				else
				{
					tbh.pos.Y += 1;
					vel = 150;
				}
				indiceTbh = 0;
				tbh.Update(gameTime, vel);
			}
			if (key.IsKeyDown(Keys.Up))
			{
				if (key.IsKeyDown(Keys.LeftShift))
				{
					tbh.pos.Y -= 2;
					vel = 80;
				}
				else
				{
					tbh.pos.Y -= 1;
					vel = 150;
				}
				indiceTbh = 1;
				tbh.Update(gameTime, vel);
			}
			if (key.IsKeyDown(Keys.Left))
			{
				if (key.IsKeyDown(Keys.LeftShift))
				{
					tbh.pos.X -= 2;
					vel = 80;
				}
				else
				{
					tbh.pos.X -= 1;
					vel = 150;
				}
				spriteEffect = SpriteEffects.None;
				indiceTbh = 2;
				tbh.Update(gameTime, vel);
			}
			if (key.IsKeyDown(Keys.Right))
			{
				if (key.IsKeyDown(Keys.LeftShift))
				{
					tbh.pos.X += 2;
					vel = 80;
				}
				else
				{
					tbh.pos.X += 1;
					vel = 150;
				}
				spriteEffect = SpriteEffects.FlipHorizontally;
				indiceTbh = 2;
				tbh.Update(gameTime, vel);
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			_spriteBatch.Draw(backgroundLv1, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
			tbh.Draw(_spriteBatch, indiceTbh, spriteEffect);

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
