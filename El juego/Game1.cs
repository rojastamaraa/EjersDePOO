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

		//Elementos
		public Elemento pasto, valla, vallaLateral, vallaLateralFin;
		public Texture2D sueloTexture, calabaza, maiz, tomate, vallatext, vallatextLateral, vallatextLateralFin;

		//Mapa
		public Map mapa;

		SpriteFont test;
		public Texture2D testpoint;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.IsFullScreen = false;
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
			calabaza = Content.Load<Texture2D>("img/calabaza");
			maiz = Content.Load<Texture2D>("img/maiz");
			tomate= Content.Load<Texture2D>("img/tomate");
			vallatext = Content.Load<Texture2D>("img/valla");
			vallatextLateral = Content.Load<Texture2D>("img/vallaC");
			vallatextLateralFin = Content.Load<Texture2D>("img/vallaF");
			pasto = new Elemento(sueloTexture, 16, 16, 0, 0);
			valla = new Elemento(vallatext, 32, 19, 0, 0);
			vallaLateral = new Elemento(vallatextLateral, 7, 42, 0, 0);
			vallaLateralFin = new Elemento(vallatextLateralFin, 7, 39, 0, 0);

			//Mapa
			mapa = new Map(pasto, valla, vallaLateral, vallaLateralFin);

			//Testeo
			testpoint = Content.Load<Texture2D>("img/point");

		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();

			tbh.Update(gameTime, mapa, key);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			mapa.Draw(_spriteBatch, sueloTexture, calabaza, maiz, tomate);
			tbh.Draw(_spriteBatch);
			//_spriteBatch.Draw(testpoint, new Vector2((int)tbh.pos.X+6, (int)tbh.pos.Y+32), new Rectangle(0, 0, 35, 15), Color.White);
			_spriteBatch.DrawString(test, tbh.testeo, new Vector2(tbh.pos.X - 10, tbh.pos.Y - 10), Color.White);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}

