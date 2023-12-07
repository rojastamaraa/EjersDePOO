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
		private Vector2 tbhPos = new Vector2(300, 300);

		//Elementos
		public Texture2D sueloTexture;
		public Elemento pasto;
		public Texture2D calabaza;
		public Texture2D maiz;
		public Texture2D tomate;

		//Mapa
		public Map mapa;

		SpriteFont test;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1700;
            _graphics.PreferredBackBufferHeight = 1100;
            _graphics.IsFullScreen = true;
        }

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			//Pj
			test = Content.Load<SpriteFont>("arial");
			tbhTexture = Content.Load<Texture2D>("img/tbhWalk");
			tbhAni = new Animacion(tbhTexture, 194/4, 194/4, 0, 4);
			tbh = new Tbh(tbhAni, tbhPos);

			//Elementos
			sueloTexture = Content.Load<Texture2D>("img/suelo");
			cebolla = Content.Load<Texture2D>("img/calabaza");
			maiz = Content.Load<Texture2D>("img/maiz");
			tomate= Content.Load<Texture2D>("img/tomate");
			pasto = new Elemento(sueloTexture, 16, 16, 0, 0);

			//Mapa
			mapa = new Map(pasto);

		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();

			tbh.testeo = "fuera";
			tbh.rect = new Rectangle((int)tbh.pos.X+49/2, (int)tbh.pos.Y+45, 1, 1);

			tbh.Update(gameTime, mapa, key);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			mapa.Draw(_spriteBatch, sueloTexture, calabaza, maiz, tomate);
			tbh.Draw(_spriteBatch);
			_spriteBatch.DrawString(test, tbh.testeo, new Vector2(tbh.pos.X - 10, tbh.pos.Y - 10), Color.White);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}

