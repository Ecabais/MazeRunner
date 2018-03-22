using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Maze
{
    class Circles : Sprites
    {
        bool HasDied = false;
        Player player;


        public Circles(Texture2D texture) 
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprites> sprite)
        {
            Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Position.Y < 0 || Position.Y > Game1.ScreenHeight - _texture.Height)
                velocity.Y *= -1;

            else if (Position.X < 0 || Position.X > Game1.ScreenWidth - _texture.Width)
                velocity.X *= -1;

           


        }

       
    }
}
