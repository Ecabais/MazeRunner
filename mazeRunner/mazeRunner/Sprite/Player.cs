using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace mazeRunner.Sprite
{
    class Player : Sprites
    {
        public bool HasDied = false;

        public Player(Texture2D texture) 
            : base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprites> sprite)
        {
            Move();

            foreach (var sprites in sprite)
            {
                if (sprites is Player)
                    continue;
                if (sprites.Rectangle.Intersects(this.Rectangle))
                {
                    this.HasDied = true;
                }
            }

            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);
            velocity = Vector2.Zero;
            Position.Y = MathHelper.Clamp(Position.Y, 0, Game1.ScreenHeight - Rectangle.Height);
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(input.Left))
                Position.X -= Speed;

            if (Keyboard.GetState().IsKeyDown(input.Right))
                Position.X += Speed;

            if (Keyboard.GetState().IsKeyDown(input.Up))
                Position.Y -= Speed;

            if (Keyboard.GetState().IsKeyDown(input.Down))
                Position.Y += Speed;
        }


       

    }
}
