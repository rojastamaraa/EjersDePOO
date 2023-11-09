using El_juego;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Animacion
{
	public Texture2D textura;
	public Vector2 pos;
	public SpriteEffects spriteEffect;
	public float temporizador, tiempo;
	public int ancho, alto, Y, cantFrames, frameActual;
	public Animacion(Texture2D textura, Vector2 pos, SpriteEffects spriteEffect, float tiempo, int ancho, int alto, int Y, int cantFrames)
	{
		this.textura = textura;
		this.pos = pos;
		this.spriteEffect = spriteEffect;
		this.tiempo = tiempo;
		this.ancho = ancho;
		this.alto = alto;
		this.Y = Y;
		this.cantFrames = cantFrames;
	}

	public void Update(GameTime gameTime)
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

	public void Draw(SpriteBatch spriteBatch)
	{
		Rectangle rectangle = new Rectangle((frameActual*ancho), Y*alto, ancho, alto);
		spriteBatch.Draw(textura, pos, rectangle, Color.White, 0f, Vector2.Zero, 0.1f, spriteEffect, 0f);
	}
}

