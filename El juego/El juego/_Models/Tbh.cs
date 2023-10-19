using El_juego._Managers;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace El_juego._Models
{
    public class Tbh
    {
        private Vector2 _position = new(100, 100);
        private readonly float _speed = 200f;
        private readonly AnimationManager _anims = new();

        public Tbh()
        {
            var tbhTexture = Globals.Content.Load<Texture2D>("img/tbhwalk");
            _anims.AddAnimation(new Vector2(0, 1), new(tbhTexture, 8, 8, 0.1f, 1));
            _anims.AddAnimation(new Vector2(-1, 0), new(tbhTexture, 8, 8, 0.1f, 2));
            _anims.AddAnimation(new Vector2(1, 0), new(tbhTexture, 8, 8, 0.1f, 3));
            _anims.AddAnimation(new Vector2(0, -1), new(tbhTexture, 8, 8, 0.1f, 4));
            _anims.AddAnimation(new Vector2(-1, 1), new(tbhTexture, 8, 8, 0.1f, 5));
            _anims.AddAnimation(new Vector2(-1, -1), new(tbhTexture, 8, 8, 0.1f, 6));
            _anims.AddAnimation(new Vector2(1, 1), new(tbhTexture, 8, 8, 0.1f, 7));
            _anims.AddAnimation(new Vector2(1, -1), new(tbhTexture, 8, 8, 0.1f, 8));
        }

        public void Update()
        {
            if (InputManager.Moving)
            {
                _position += Vector2.Normalize(InputManager.Direction) * _speed * Globals.TotalSeconds;
            }

            _anims.Update(InputManager.Direction);
        }

        public void Draw()
        {
            _anims.Draw(_position);
        }
    }
}
