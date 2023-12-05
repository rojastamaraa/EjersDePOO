using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;

namespace El_juego
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		//TPersonaje
		public Tbh tbh;
		public Animacion tbhAni;
		public Texture2D tbhTexture;
		private Vector2 tbhPos = new Vector2(100, 100);
		public int indiceTbh;
		public int vel = 150;
		private SpriteEffects spriteEffect;
		public Rectangle tbhRect;

		//Elementos
		public Elemento pasto;
		public Texture2D sueloTexture;
		public Elemento tierra;

		//Mapa
		public Map mapa;
		//float temp, temp2;
		//      bool parpadeo = false;

		//Fuentes
		SpriteFont test;

		string testeo = ""; 
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1700;
            _graphics.PreferredBackBufferHeight = 1100;
            _graphics.IsFullScreen = false;
        }

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			tbhTexture = Content.Load<Texture2D>("img/tbhWalk");
			spriteEffect = SpriteEffects.None;
			tbhAni = new Animacion(tbhTexture, 609, 609, indiceTbh, 4);
			tbh = new Tbh(tbhAni, tbhPos);

			//Elementos
			sueloTexture = Content.Load<Texture2D>("img/suelo");
			pasto = new Elemento(sueloTexture, 16, 16, 0, 0);
			tierra = new Elemento(sueloTexture, 16, 16, 0, 1);

			//Mapa
			mapa = new Map(pasto, tierra);
			test = Content.Load<SpriteFont>("arial");
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

			testeo = "123123132";

			tbhRect = new Rectangle((int)tbh.pos.X, (int)tbh.pos.Y, 49, 49);

            foreach (var tierra in mapa.tierraList)
            {
				Rectangle tierraRect = new Rectangle((int)tierra.X,(int)tierra.Y, (int)tierra.Width, (int)tierra.Height);

				if (colision(tbhRect, tierraRect))
				{

					testeo = "";
					break;
				}

			}
			
			//Movimiento
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
			mapa.Draw(_spriteBatch);
			tbh.Draw(_spriteBatch, indiceTbh, spriteEffect);
			_spriteBatch.DrawString(test, testeo, new Vector2(tbh.pos.X - 10, tbh.pos.Y - 10), Color.White);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
		public bool colision(Rectangle tbh, Rectangle obj)
		{
			return tbh.Intersects(obj);
		}
	}
}

