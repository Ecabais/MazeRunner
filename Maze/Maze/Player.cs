using Maze;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Player
    {
        private Texture2D playerTexture;
        private Vector2 position = new Vector2(0 ,16);
        private Vector2 velocity;
        private Rectangle rectangle;
        private float speed = 4.5f;
       

        public bool HasDied = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Player()
        {

        }

        public void Load(ContentManager Content)
        {
            playerTexture = Content.Load<Texture2D>("square");
        }

        public void Update(GameTime gameTime)
        {
            
            position += velocity;
            velocity = Vector2.Zero;
            rectangle = new Rectangle((int)position.X, (int)position.Y, playerTexture.Width, playerTexture.Height);

            Input(gameTime);

           


           

        }


        
       

        private void Input(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                velocity.X = speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                velocity.X = -speed;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                velocity.Y = -speed;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                velocity.Y = speed;

            
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (this.velocity.Y > 0 && rectangle.TouchTopOf(newRectangle))
            {
                velocity.Y = 0;
                
                
            }

            else if (this.velocity.X > 0 &&rectangle.TouchLeftOf(newRectangle))
            {
                velocity.X = 0;
            }
            else if (this.velocity.X < 0 &&rectangle.TouchRightOf(newRectangle))
            {
                velocity.X = 0;
            }
            else if (this.velocity.Y < 0 && rectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 0f;
            }

            if (position.X < 0)
                position.X = 0;

            if (position.X > xOffset - rectangle.Width)
                position.X = xOffset - rectangle.Width;

            if (rectangle.Y < 0)
                velocity.Y = 1f;

            if (position.Y > yOffset - rectangle.Height)
                position.Y = yOffset - rectangle.Height;




        }

        public void CollisionCircle(Rectangle CircleRect)
        {
            if (this.rectangle.Intersects(CircleRect))
            {
                this.HasDied = true;

            }

           
        }

        public void Restart()
        {
            position = new Vector2(0, 16);
        }



        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, rectangle, Color.White);
        }

    }
}
