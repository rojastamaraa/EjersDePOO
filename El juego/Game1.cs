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
		private Vector2 tbhPos = new Vector2(650, 300);

		//Elementos
		public Elemento pasto, valla, vallaLateral, vallaLateralFin;
		public Texture2D sueloTexture, calabaza, maiz, tomate, vallatext, vallatextLateral, vallatextLateralFin;
		public Elemento techo, paredes, suelo, puerta;
		public Texture2D techoText, paredesText, casaText;
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
			casaText = Content.Load<Texture2D>("img/casa");
			paredesText = Content.Load<Texture2D>("img/casaParedes");
			techoText = Content.Load<Texture2D>("img/techo");
			pasto = new Elemento(sueloTexture, 16, 16);
			valla = new Elemento(vallatext, 32, 19);
			vallaLateral = new Elemento(vallatextLateral, 7, 42);
			vallaLateralFin = new Elemento(vallatextLateralFin, 7, 39);
			suelo = new Elemento(casaText, 48, 48);	
			paredes = new Elemento(paredesText, 288, 192);
			puerta = new Elemento(casaText, 48, 48);
			techo = new Elemento(techoText, 288, 160);

			//Mapa
			mapa = new Map(pasto, valla, vallaLateral, vallaLateralFin, suelo, paredes, puerta, techo);

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
			//_spriteBatch.Draw(testpoint, new Vector2((int)tbh.pos.X+15, (int)tbh.pos.Y+42), new Rectangle(0, 0, 20, 5), Color.White);
			_spriteBatch.DrawString(test, tbh.testeo, new Vector2(tbh.pos.X - 10, tbh.pos.Y - 10), Color.White);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}

