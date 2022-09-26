using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Amogus
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D BallTexture;
        PlayerCharacter Player;
        Ball[] Ball = new Ball[6];
        bool PersonHit;
        KeyboardState PlayerKeyboard;

        Texture2D ball, farmer;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Player = new PlayerCharacter(new Vector2(100, 100));
            Player.Load(Content);
            for (int i = 0; i < 6; i++)
            {
                Ball[i] = new Ball(i);
            }
            for (int i = 0; i < 6; i++)
            {
                Ball[i].Load(Content);
            }
            // TODO: use this.Content to load your game content here

            BallTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PlayerKeyboard = Keyboard.GetState();

            if (PlayerKeyboard.IsKeyDown(Keys.Up) || PlayerKeyboard.IsKeyDown(Keys.W))
            {
                Player.MoveUp();
                Player.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (PlayerKeyboard.IsKeyDown(Keys.Down) || PlayerKeyboard.IsKeyDown(Keys.S))
            {
                Player.MoveDown();
                Player.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (PlayerKeyboard.IsKeyDown(Keys.Left) || PlayerKeyboard.IsKeyDown(Keys.A))
            {
                Player.MoveLeft();
                Player.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (PlayerKeyboard.IsKeyDown(Keys.Right) || PlayerKeyboard.IsKeyDown(Keys.D))
            {
                Player.MoveRight();
                Player.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (PlayerKeyboard.IsKeyDown(Keys.LeftShift))
            {
                Player.SprintOn();
            }
            if (PlayerKeyboard.IsKeyUp(Keys.LeftShift))
            {
                Player.SprintOff();
            }
            if (PlayerKeyboard.IsKeyUp(Keys.Up) && PlayerKeyboard.IsKeyUp(Keys.W) && PlayerKeyboard.IsKeyUp(Keys.Down) && PlayerKeyboard.IsKeyUp(Keys.S) && PlayerKeyboard.IsKeyUp(Keys.Left) && PlayerKeyboard.IsKeyUp(Keys.A) && PlayerKeyboard.IsKeyUp(Keys.Right) && PlayerKeyboard.IsKeyUp(Keys.D))
            {
                Player.ResetAnimFrame();
            }
            for (int i = 0; i < 6; i++)
            {
                if (Player.Hitbox.Intersects(Ball[i].Hitbox))
                {
                    PersonHit = true;
                    Ball[i].RandomNewPos();
                    break;
                }
                else
                {
                    PersonHit = false;
                }
            }
            Player.UpdatePos();
            for (int i = 0; i < 6; i++)
            {
                Ball[i].Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice GDevice = _graphics.GraphicsDevice;
            if (PersonHit == true)
            {
                GDevice.Clear(Color.Red);
            }
            else
            {
                GDevice.Clear(Color.CornflowerBlue);
            }
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < 6; i++)
            {
                Ball[i].Draw(_spriteBatch);
            }
            Player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
