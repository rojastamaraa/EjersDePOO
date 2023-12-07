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
		//public Elemento tierra;
		public Tierra tierra;
		public Texture2D cebolla;
		public Texture2D maiz;
		public Texture2D tomate;
		public Huerta huerta;

		//Mapa
		public Map mapa;

		SpriteFont test;

		//Personaje acciones
		public float temporizador;

		public Texture2D point;

		string indice;

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
			point = Content.Load<Texture2D>("img/point");
			//Elementos
			sueloTexture = Content.Load<Texture2D>("img/suelo");
			cebolla = Content.Load<Texture2D>("img/calabaza");
			maiz = Content.Load<Texture2D>("img/maiz");
			tomate= Content.Load<Texture2D>("img/tomate");
			huerta = new Huerta("cebolla", new Vector2(192, 320));
			
			pasto = new Elemento(sueloTexture, 16, 16, 0, 0);
			//tierra = new Elemento(sueloTexture, 16, 16, 0, 1);

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

			//for (int i = 0; i < 4; i++)
			//{
			//	for (int j = 0; j < 6; j++)
			//	{
			//		if (tbh.rect.Intersects(huerta.tierraList[i,j]))
			//		{
			//			indice = i + "," + j;
			//			tbh.testeo = "Sobre la tierra " + indice;
			//			if (huerta.tierra[i,j].etapa == -1 && key.IsKeyDown(Keys.F))
			//			{
			//				huerta.tierra[i,j].etapa = 0;
			//				huerta.tierra[i,j].fueRegado = 1;
			//				tbh.testeo = "1ra etapa";
			//			}

			//			if (huerta.tierra[i,j].etapa < 3 && huerta.tierra[i, j].etapa != -1)
			//			{
			//				tbh.testeo = "Etapa" + huerta.tierra[i, j].etapa;
			//				if (huerta.tierra[i, j].fueRegado == 1)
			//				{
			//					if (key.IsKeyDown(Keys.Space))
			//					{
			//						huerta.tierra[i, j].fueRegado = 2;
			//					}
			//				}

			//			}
			//			if (huerta.tierra[i, j].etapa == 3)
			//			{
			//				tbh.testeo = "Etapa" + huerta.tierra[i, j].etapa;
			//				if (key.IsKeyDown(Keys.Space))
			//				{
			//					huerta.tierra[i, j].etapa = -1;
			//					huerta.tierra[i, j].fueRegado = 0;
			//				}
			//			}
			//		}
			//	}
			//}

			//for (int i = 0; i < 4; i++)
			//{
			//	for (int j = 0; j < 6; j++)
			//	{
			//		huerta.tierra[i, j].Update(gameTime);
			//	}
			//}
			
			tbh.Update(gameTime, mapa, key);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			_spriteBatch.Begin();
			mapa.Draw(_spriteBatch, sueloTexture, cebolla, maiz, tomate);
			tbh.Draw(_spriteBatch);
			//_spriteBatch.Draw(point, new Vector2(tbh.pos.X+49/2, tbh.pos.Y+45), new Rectangle(0,0,1,1), Color.White);
			_spriteBatch.DrawString(test, tbh.testeo, new Vector2(tbh.pos.X - 10, tbh.pos.Y - 10), Color.White);
			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}

