using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace El_juego
{
	public class Enemigo
	{

		public Rectangle rect;
		public Animacion texture;
		public Vector2 posAnterior;
		public Vector2 pos;
		public SpriteEffects effects;
		Color color = new Color(255, 255, 255, 150);
		Random r = new Random();
		public float speed = 3f;
		public float temporizador, tiempo;
		public bool arriba, abajo, derecha, izquierda, colisiono, tiempoC, cerca;
		public Enemigo(Animacion texture)
		{
			tiempo = 120000;
			pos = new Vector2(-1000, 600);
			this.texture = texture;
		}

		public void Update(GameTime gameTime, Vector2 tbhPos)
		{
			rect = new Rectangle((int)pos.X + 4, (int)pos.Y + 30, 44, 18);
			posAnterior = pos;
			Vector2 direccion = Vector2.Normalize(tbhPos - pos);

			if (colisiono == true)
			{
				if (derecha)
				{
					pos.X -= 3f;
					effects = SpriteEffects.None;
					if (pos.X < -1000)
					{
						colisiono=false;
						temporizador = 0;
						tiempoC = true;
						derecha = false;
						izquierda = true;
					}
				}
				if (izquierda)
				{
					pos.X += 3;
					effects = SpriteEffects.FlipHorizontally;
					if (pos.X > 2000)
					{
						colisiono = false;
						tiempoC = true;
						temporizador = 0;
						derecha = true;
						izquierda = false;
					}
				}
			}
			else if (!colisiono)
			{
				temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

				if (tiempoC == true)
				{
					tiempo = 1000 * r.Next(10, 250);
					tiempoC = false;
				}
				
				if (temporizador > tiempo)
				{
					pos += direccion * speed;
					if (pos.X > posAnterior.X)
					{
						effects = SpriteEffects.FlipHorizontally;
						derecha = true;
						izquierda = false;
					}
					if (pos.X < posAnterior.X)
					{
						effects = SpriteEffects.None;
						izquierda = true;
						derecha = false;
					}

					if (pos.Y > posAnterior.Y)
					{
						abajo = true;
						arriba = false;
					}
					else
					{
						arriba = true;
						abajo = false;
					}
				}

				if (pos.Y > 944)
				{
					pos.Y = 944;
				}
			}
			if (pos.X > -700 || (pos.X > 500 && pos.X < 1800))
			{
				cerca = true;
			}
			else
			{
				cerca = false;
			}

			texture.Update(gameTime, 200);
			
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			texture.Draw(spriteBatch, pos, color, effects, 1f);
		}

	}
}
