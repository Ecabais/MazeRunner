﻿using mazeRunner.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace mazeRunner.Sprite
{
    class Sprites
    {
        protected Texture2D _texture;
        public Vector2 velocity;
        public Vector2 Position;
        public Input input;

        public float Speed = 5f;
        

        public Sprites(Texture2D texture)
        {
            _texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprites> sprite)
        {
           
        }

        

        public virtual void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(_texture, Position, Color.White);

        }

    }
}
