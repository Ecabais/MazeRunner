using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class Tiles
    {
        protected Texture2D _texture;

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get{ return rectangle;}
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rectangle, Color.White);
        }
    }


    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newRectangle)
        {
            _texture = Content.Load<Texture2D>("BlackSquare");
            this.Rectangle = newRectangle;
        }
    }
}
