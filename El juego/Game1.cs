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

		//Elementos
		public Elemento pasto;
		public Texture2D sueloTexture;
		public Elemento tierra;

		//Mapa
		public Map mapa;
		//float temp, temp2;
  //      bool parpadeo = false;
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

			if (new Rectangle(0, 1, tierra.ancho, tierra.alto).Intersects(tbh.rect))
			{
				tbh.pos = new Vector2(100, 100);
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

			_spriteBatch.End();
			base.Draw(gameTime);
		}
		public bool colision(Rectangle tbh, Rectangle obj)
		{
			return tbh.Intersects(obj);
		}
	}
}

