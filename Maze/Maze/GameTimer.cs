using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    class GameTimer : GameComponent
    {
        private SpriteFont font;
        private string text;
        private float time;
        private bool started;
        private bool paused;
        private bool finished;

        private Vector2 textPosition;

        public GameTimer(Game game, float startTime )
            :base (game)
        {
            time = startTime;
            started = false;
            paused = false;
            finished = false;
            Text = "";
        }

        #region Properties
        public float Time
        {
            get { return time; }
            set { time = value; }
        }
        public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public bool Started
        {
            get { return started; }
            set { started = value; }
        }
        public bool Paused
        {
            get { return paused; }
            set { started = value; }
        }

        public bool Finished
        {
            get { return finished; }
            set { paused = value; }
        }

        public Vector2 TextPosition
        {
            get { return textPosition; }
            set { textPosition = value; }
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Started)
            {
                if (!paused)
                {
                    if (time < 1000)
                        time += deltaTime;
                    else
                        finished = true;
                }
            }

            Text = "Time: " + ((int)time).ToString();

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, Text, textPosition, Color.Black);
        }
    }
}
