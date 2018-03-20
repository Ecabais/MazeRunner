using mazeRunner.Model;
using mazeRunner.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace mazeRunner
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Sprites> _sprite;

        public static int ScreenWidth;
        public static int ScreenHeight;

        public bool hasStarted = false;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ScreenWidth = graphics.PreferredBackBufferWidth;
            ScreenHeight = graphics.PreferredBackBufferHeight;
        }

       
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Restart();
        }

        private void Restart()
        {
            var box = Content.Load<Texture2D>("square");
            var circle = Content.Load<Texture2D>("Red dot");

            _sprite = new List<Sprites>()
            {

                //player sprite
                new Player(box)
                {
                    Position = new Vector2(0,0),
                    input = new Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                        Up = Keys.W,
                        Down = Keys.S,

                    },

                    Speed = 3.75f
                },
                
                // circles going up and down
                new Circles(circle)
                {
                    Position = new Vector2(100, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(175, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(250, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(325, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(400, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(475, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(550, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(625, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(700, ScreenHeight / 2),
                    velocity = new Vector2 (0f, 450f),
                },


                // circles moving left and right 
                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 50),
                    velocity = new Vector2(900f, 0f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 125),
                    velocity = new Vector2(900f, 0f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 200),
                    velocity = new Vector2(900f, 0f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 275),
                    velocity = new Vector2(900f, 0f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 350),
                    velocity = new Vector2(900f, 0f),
                },

                new Circles(circle)
                {
                    Position = new Vector2(ScreenWidth / 2, 425),
                    velocity = new Vector2(900f, 0f),
                },
            };
        }

       
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                hasStarted = true;

            if (!hasStarted)
                return;

            foreach (var sprite in _sprite)
            {
                sprite.Update(gameTime, _sprite);
            }

            for (int i = 0; i < _sprite.Count; i++)
            {
                var sprite = _sprite[i];



                if (sprite is Player)
                {
                    var player = sprite as Player;

                    if (player.HasDied)
                    {
                        Restart();
                    }
                }

                base.Update(gameTime);
            }
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var sprite in _sprite)
            {
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
