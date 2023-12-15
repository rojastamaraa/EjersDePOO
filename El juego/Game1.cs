using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;

namespace El_juego
{

	public class Camara
	{
		public Matrix Transform { get; private set; }

		public void Follow(Vector2 pos, int ancho, int alto)
		{
			var posicion = Matrix.CreateTranslation(
				-pos.X - ancho / 2,
				-pos.Y - alto / 2,
				0);

			Transform = posicion;
		}
	}
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		//TPersonaje
		public Tbh tbh;
		public Animacion tbhAni, tbhWin;
		public Texture2D tbhTexture, tbhWinT;
		private Vector2 tbhPos = new Vector2(650, 300);

		//Elementos
		public Elemento pasto, valla, vallaLateral, vallaLateralFin;
		public Texture2D sueloTexture, calabaza, maiz, tomate, vallatext, vallatextLateral, vallatextLateralFin;
		public Elemento techo, paredes, suelo, puerta, mueble, cama;
		public Texture2D techoText, paredesText, casaText, muebleText, camaText, aguaT;
		public Elemento fondo, boton, pozo, arbol;
		public Texture2D fondoT, botonT, madera, llavesYss, pozoT, balsa, arbolT;

		//Mapa
		public Map mapa;

		//Tienda
		public Tienda tienda;

		//Enemigo
		public Enemigo enemigo;
		public Animacion enemigoAni;
		public Texture2D enemigoT;

		Camara camara = new Camara();

		public Texture2D inventario;
		SpriteFont test;
		public Texture2D muerto, ganasteT, inicioT;
		public bool teclaPresionada, perdiste, escape, ganaste, inicio, juegoTerminado;
		public int indice;
		public int eXcape = 0;
		public float temporizador;

		Song sonidoFondo;
		SoundEffect enemigoGolpe, enemigoo, regando, plantando, fuente, splash, yipee, harmonica, blop;
		SoundEffectInstance enemigooInstance, enemigoGolpein, fuenteIn, splashIn;
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
			muebleText = Content.Load<Texture2D>("img/mesitadeluz");
			camaText = Content.Load<Texture2D>("img/cama");
			aguaT = Content.Load<Texture2D>("img/agua");
			fondoT = Content.Load<Texture2D>("img/menu");
			botonT = Content.Load<Texture2D>("img/botones");
			llavesYss = Content.Load<Texture2D>("img/llaves");
			madera = Content.Load<Texture2D>("img/madera");
			pozoT = Content.Load<Texture2D>("img/pozo");
			balsa = Content.Load<Texture2D>("img/balsa");
			arbolT = Content.Load<Texture2D>("img/arbol");
			inventario = Content.Load<Texture2D>("img/inventario");
			muerto = Content.Load<Texture2D>("img/muerto");
			ganasteT = Content.Load<Texture2D>("img/escapaste");
			tbhWinT = Content.Load<Texture2D>("img/tbhWin");
			inicioT = Content.Load<Texture2D>("img/inicio");
			tbhWin = new Animacion(tbhWinT, 64, 64, 0, 5);
			pasto = new Elemento(sueloTexture, 16, 16);
			valla = new Elemento(vallatext, 32, 19);
			vallaLateral = new Elemento(vallatextLateral, 7, 42);
			vallaLateralFin = new Elemento(vallatextLateralFin, 7, 39);
			suelo = new Elemento(casaText, 48, 48);	
			paredes = new Elemento(paredesText, 288, 192);
			puerta = new Elemento(casaText, 48, 48);
			techo = new Elemento(techoText, 288, 186);
			mueble = new Elemento(muebleText, 42, 48);
			cama = new Elemento(camaText, 42, 66);
			fondo = new Elemento(fondoT, 128, 144);
			boton = new Elemento(botonT, 48, 48);
			pozo = new Elemento(pozoT, 64, 64);
			arbol = new Elemento(arbolT, 50, 50);
			//Mapa
			mapa = new Map(pasto, valla, vallaLateral, vallaLateralFin, suelo, paredes, puerta, techo, mueble, cama, aguaT, pozo, arbol, madera);

			//Tienda
			tienda = new Tienda(fondo, boton, madera, llavesYss, test);

			//Enemigo
			enemigoT = Content.Load<Texture2D>("img/enemigo");
			enemigoAni = new Animacion(enemigoT, 48, 48, 0, 4);
			enemigo = new Enemigo(enemigoAni);

			//Sonido

			sonidoFondo = Content.Load<Song>("cigarras");
			enemigoo = Content.Load<SoundEffect>("enemigo");
			enemigooInstance = enemigoo.CreateInstance();
			enemigoGolpe = Content.Load<SoundEffect>("enemigoGolpe");
			enemigoGolpein = enemigoGolpe.CreateInstance();
			regando = Content.Load<SoundEffect>("regando");
			plantando = Content.Load<SoundEffect>("plantando");
			fuente = Content.Load<SoundEffect>("fuente");
			fuenteIn = fuente.CreateInstance();
			splash = Content.Load<SoundEffect>("splash");
			splashIn = splash.CreateInstance();
			yipee = Content.Load<SoundEffect>("yipee");
			harmonica = Content.Load<SoundEffect>("harmonica");
			blop = Content.Load<SoundEffect>("blop");
			MediaPlayer.Play(sonidoFondo);
			MediaPlayer.IsRepeating = true;
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			KeyboardState key = Keyboard.GetState();
			if (!inicio)
			{
				if (key.IsKeyDown(Keys.Left))
				{
					indice = 0;
				}
				if (key.IsKeyDown(Keys.Right))
				{
					indice = 1;
				}
				if (key.IsKeyDown(Keys.Space))
				{
					if (indice == 0)
					{
						inicio = true;
					}
					if (indice == 1)
					{
						Exit();
					}
				}
			}

			if (inicio)
			{
				if (!juegoTerminado)
				{
					Vector2 playerPosition = new Vector2(tbh.pos.X - 776, tbh.pos.Y - 552);

					if (playerPosition.X < -400)
					{ playerPosition.X = -400; }
					if (playerPosition.X > 145)
					{ playerPosition.X = 145; }
					if (playerPosition.Y < -300)
					{ playerPosition.Y = -300; }
					if (playerPosition.Y > 413)
					{ playerPosition.Y = 413; }

					camara.Follow(playerPosition, 800, 600);

					tbh.testeo = tbh.pos.X + ";" + tbh.pos.Y;

					if (tbh.enMenu)
					{
						tienda.Update(gameTime, key);
						if (key.IsKeyDown(Keys.Space) && !teclaPresionada)
						{
							teclaPresionada = true;
							if (tienda.indice == 0 && tbh.monedas >= tienda.llaveCalabaza.precio && tienda.llaveC == 1)
							{
								tbh.monedas -= tienda.llaveCalabaza.precio;
								tbh.monedasString = "" + tbh.monedas;
								tienda.llaveC -= 1;
								tbh.llaveC = true;
							}
							if (tienda.indice == 1 && tbh.monedas >= tienda.llaveMaiz.precio && tienda.llaveM == 1)
							{
								tbh.monedas -= tienda.llaveMaiz.precio;
								tbh.monedasString = "" + tbh.monedas;
								tienda.llaveM -= 1;
								tbh.llaveM = true;
							}
							if (tienda.indice == 2 && tbh.monedas >= tienda.semillaCalabaza.precio && tienda.semillaC > 0 && tienda.semillaC < 11)
							{
								tbh.monedas -= tienda.semillaCalabaza.precio;
								tbh.monedasString = "" + tbh.monedas;
								tienda.semillaC -= 1;
								tbh.semicalabaza.cant += 1;
							}
							if (tienda.indice == 3 && tbh.monedas >= tienda.semillaMaiz.precio && tienda.semillaM > 0 && tienda.semillaM < 11)
							{
								tbh.monedas -= tienda.semillaMaiz.precio;
								tbh.monedasString = "" + tbh.monedas;
								tienda.semillaM -= 1;
								tbh.semimaiz.cant += 1;
							}
							if (tienda.indice == 4 && tbh.monedas >= tienda.madera.precio && tienda.maderaCant > 0 && tienda.maderaCant < 6)
							{
								tbh.monedas -= tienda.madera.precio;
								tbh.monedasString = "" + tbh.monedas;
								tienda.maderaCant -= 1;
								tbh.madera += 1;
							}
						}

						if (key.IsKeyUp(Keys.Space))
						{
							teclaPresionada = false;
						}
					}

					if (key.IsKeyDown(Keys.Right) || key.IsKeyDown(Keys.Left))
					{
						tbh.enMenu = false;
					}

					if (!tbh.enMenu)
					{
						tbh.Update(gameTime, mapa, key, regando, plantando, fuenteIn, blop);
					}

					if (tbh.sobrePuente && key.IsKeyDown(Keys.F) && tbh.madera == 5)
					{
						tbh.balsa = true;
						tbh.madera = 0;
						escape = true;
					}

					if (escape)
					{
						temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
						if (temporizador > 300)
						{
							if(splashIn.State != SoundState.Playing)
							{
								splashIn.Play();
							}
							eXcape += 1;
							tbh.pos = new Vector2(650 + eXcape, 1075);
							if (eXcape > 650)
							{
								juegoTerminado = true;
								ganaste = true;
								yipee.Play();
							}
						}
					}

					for (int i = 0; i < mapa.casa.paredesList.Count; i++)
					{
						if (enemigo.rect.Intersects(mapa.casa.paredesList[i]) || enemigo.rect.Intersects(mapa.casa.puertaRect))
						{
							if (enemigoGolpein.State != SoundState.Playing)
							{
								enemigoGolpein.Play();
							}
							enemigo.colisiono = true;
						}
					}

					if (enemigo.cerca && enemigooInstance.State != SoundState.Playing)
					{
						enemigooInstance.Play();
					}
					else if(!enemigo.cerca)
					{
						enemigooInstance.Stop();
					}
					if (tbh.rect.Intersects(enemigo.rect))
					{
						enemigo.colisiono = true;
						perdiste = true;
						juegoTerminado = true;
						enemigooInstance.Stop();
						harmonica.Play();
					}

					enemigo.Update(gameTime, tbh.pos);
					mapa.Update(gameTime);
				}
				else if (juegoTerminado)
				{
					tbhWin.Update(gameTime, 150);
					if (key.IsKeyDown(Keys.Left))
					{
						indice = 0;
					}
					if (key.IsKeyDown(Keys.Right))
					{
						indice = 1;
					}

					if (key.IsKeyDown(Keys.Space))
					{
						if (indice == 0)
						{
							enemigooInstance.Stop();
							perdiste = false;
							ganaste = false;
							juegoTerminado = false;
							eXcape = 0;
							escape = false;
							enemigo.pos = new Vector2(-1000, 600);
							enemigo.tiempo = 120000;
							tbh.pos = new Vector2(650, 300);
							tbh.semitomate.cant = 5;
							tbh.semicalabaza.cant = 0;
							tbh.semimaiz.cant = 0;
							tbh.llaveC = false;
							tbh.llaveM = false;
							tbh.balsa = false;
							tbh.agua = 0;
							tbh.aguaString = "0%";
							tbh.monedas = 0;
							tbh.monedasString = "0";
							tbh.madera = 0;
							mapa.huertaCalabaza.desbloqueado = false;
							mapa.huertaCalabaza.desbloqueado = false;
							tienda.llaveC = 1;
							tienda.llaveM = 1;
							tienda.semillaC = 10;
							tienda.semillaM = 10;
							tienda.maderaCant = 5;
							for (int i = 0; i < 4; i++)
							{
								for (int j = 0; j < 6; j++)
								{
									mapa.huertaCalabaza.tierra[i, j].fueRegado = 0;
									mapa.huertaMaiz.tierra[i, j].fueRegado = 0;
									mapa.huertaTomate.tierra[i, j].fueRegado = 0;
									mapa.huertaCalabaza.tierra[i, j].etapa = -1;
									mapa.huertaMaiz.tierra[i, j].etapa = -1;
									mapa.huertaTomate.tierra[i, j].etapa = -1;
								}
							}
						}
						if (indice == 1)
						{
							Exit();
						}
					}
				}
			}

			tbhWin.Update(gameTime, 200);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			if (inicio && !juegoTerminado)
			{
				_spriteBatch.Begin(transformMatrix: camara.Transform);
				mapa.Draw(_spriteBatch, sueloTexture, calabaza, maiz, tomate, madera);
				float posY;
				float posX;
				float posYI = 0;
				if (tbh.pos.Y < 255)
				{ posY = 0; posYI = 530; }
				else if (tbh.pos.Y > 966)
				{ posY = 966 - 255; posYI = 966 + 270; }
				else
				{ posY = tbh.pos.Y - 255; posYI = tbh.pos.Y + 270; }

				if (tbh.pos.X > 920)
				{ posX = 920; }
				else if (tbh.pos.X < 380)
				{ posX = 375; }
				else
				{ posX = tbh.pos.X; }
				Vector2 posicion = new Vector2(posX + 333, posY);
				_spriteBatch.Draw(botonT, posicion, new Rectangle(288, 0, 48, 48), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				_spriteBatch.DrawString(test, tbh.aguaString, new Vector2(posicion.X + 44, posY + 16), Color.Brown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
				_spriteBatch.DrawString(test, tbh.monedasString, new Vector2(posicion.X + 44, posY + 62), Color.Brown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

				_spriteBatch.Draw(inventario, new Vector2(posX - 136, posYI), new Rectangle(0, 0, 160, 32), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				if (tbh.semitomate.cant > 0)
				{
					_spriteBatch.Draw(tomate, new Vector2(posX + 136, posYI + 16), new Rectangle(64, 0, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					_spriteBatch.DrawString(test, tbh.semitomate.cant + "", new Vector2(posX + 160, posYI + 32), Color.Black, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
				}
				if (tbh.semimaiz.cant > 0)
				{
					_spriteBatch.Draw(maiz, new Vector2(posX + 72, posYI + 16), new Rectangle(64, 0, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					_spriteBatch.DrawString(test, tbh.semimaiz.cant + "", new Vector2(posX + 96, posYI + 32), Color.Black, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
				}
				if (tbh.semicalabaza.cant > 0)
				{
					_spriteBatch.Draw(calabaza, new Vector2(posX + 8, posYI + 16), new Rectangle(64, 0, 16, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
					_spriteBatch.DrawString(test, tbh.semicalabaza.cant + "", new Vector2(posX + 32, posYI + 32), Color.Black, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
				}
				int ll = 0;
				if (tbh.llaveM == true && tbh.llaveC == true) { ll = 2; }
				else if (tbh.llaveM == true || tbh.llaveC == true) { ll = 1; }
				if (ll > 0)
				{
					_spriteBatch.Draw(llavesYss, new Vector2(posX - 56, posYI + 16), new Rectangle(16, 0, 16, 16), Color.White, 0f, Vector2.Zero, 1.75f, SpriteEffects.None, 0f);
					_spriteBatch.DrawString(test, "" + ll, new Vector2(posX - 32, posYI + 32), Color.Black, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
				}
				if (tbh.madera > 0)
				{
					_spriteBatch.Draw(madera, new Vector2(posX - 120, posYI + 16), new Rectangle(32, 32, 32, 32), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
					_spriteBatch.DrawString(test, tbh.madera + "", new Vector2(posX - 96, posYI + 32), Color.Black, 0f, Vector2.Zero, 0.75f, SpriteEffects.None, 0f);
				}
				if (!escape)
				{
					tbh.Draw(_spriteBatch);
				}
				enemigo.Draw(_spriteBatch);
				if (tbh.balsa == true)
				{
					_spriteBatch.Draw(balsa, new Vector2(640 + eXcape, 1100), new Rectangle(0, 0, 32, 16), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.FlipHorizontally, 0f);
				}
				if (escape)
				{
					tbhWin.Draw(_spriteBatch, new Vector2(650 + eXcape + 10, 1075), Color.White, SpriteEffects.FlipHorizontally, 0.75f);
				}
				if (tbh.enMenu == true)
				{
					tienda.Draw(_spriteBatch);
				}
			}
			else if(juegoTerminado)
			{
			_spriteBatch.Begin();
			}
			if (!inicio)
			{
				_spriteBatch.Begin();
				_spriteBatch.Draw(inicioT, new Vector2(0, 0), new Rectangle(0, 0, 400, 300), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
			}

			if (perdiste)
			{
				_spriteBatch.Draw(muerto, new Vector2(0, 0), new Rectangle(0, 0, 400, 300), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
			}
			if (ganaste)
			{
				_spriteBatch.Draw(ganasteT, new Vector2(0, 0), new Rectangle(0, 0, 400, 300), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
				tbhWin.Draw(_spriteBatch, new Vector2(304, 100), Color.White, SpriteEffects.None, 3f);
			}
			if (juegoTerminado || !inicio)
			{
				_spriteBatch.Draw(botonT, new Vector2(256, 500), new Rectangle(0, 48, 96, 32), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
				_spriteBatch.Draw(botonT, new Vector2(408, 500), new Rectangle(192, 48, 96, 32), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
				if (indice == 0)
				{
					_spriteBatch.Draw(botonT, new Vector2(256, 500), new Rectangle(96, 48, 96, 32), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
				}
				if (indice == 1)
				{
					_spriteBatch.Draw(botonT, new Vector2(408, 500), new Rectangle(288, 48, 96, 32), Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);
				}
			}

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}