using El_juego;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Animacion
{
	public Texture2D textura;
	public float temporizador, tiempo;
	public int ancho, alto, Y, cantFrames, frameActual;
	public Animacion(Texture2D textura, int ancho, int alto, int Y, int cantFrames)
	{
		this.textura = textura;
		this.ancho = ancho;
		this.alto = alto;
		this.Y = Y;
		this.cantFrames = cantFrames;
	}

	public void Update(GameTime gameTime, float tiempo)
	{
		temporizador += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
		if (temporizador > tiempo)
		{
			if (frameActual < cantFrames - 1)
			{
				frameActual++;
				temporizador = 0;
			}
			else 
			{
				frameActual = 0;
				temporizador = 0;
			}
		}
	}

	public void Draw(SpriteBatch spriteBatch, Vector2 pos, Color color, SpriteEffects spriteEffect, float escala)
	{
		Rectangle rectangle = new Rectangle((frameActual*ancho), Y*alto, ancho, alto);
		spriteBatch.Draw(textura, pos, rectangle, color, 0f, Vector2.Zero, escala, spriteEffect, 0f);
	}
}

