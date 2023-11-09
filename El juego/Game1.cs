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
		float temp, temp2;
        bool parpadeo = false;
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
			tbh = new Animacion(tbhTexture, tbhPos, spriteEffect, 150, 609, 609, indiceTbh, 4);
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

                //if (key.GetPressedKeys().Length == 0)
                //{

                //             temp += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //             if (temp > 2000)
                //	{
                //                 temp2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                //                 if (temp2 < 1800)
                //                 {
                //                     indiceTbh = 3;
                //                     tbh.Update(gameTime);
                //                 }
                //                 else
                //                 {
                //                     parpadeo = true;
                //                     temp = 0;
                //                     temp2 = 0;
                //                 }
                //             }
                //             else if (parpadeo == true)
                //             {
                //                 indiceTbh = 0;
                //                 tbh.frameActual = 0;
                //                 parpadeo = false;
                //             }
                //	else if (parpadeo == false)
                //	{
                //                 tbh.frameActual = 0;
                //             }
                //         }


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
