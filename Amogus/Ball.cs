using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Amogus
{
    class Ball
    {
        private Texture2D BallTex;
        protected Vector2 BallPos;
        public Rectangle Hitbox;
        int Row;
        Random RNG;

        public Ball(int BallNum)
        {
            Row = BallNum;
            RNG = new Random();
            RandomNewPos();
        }
        public void Load(ContentManager Content)
        {
            BallTex = Content.Load<Texture2D>("ball");
        }
        public void Update()
        {
            Hitbox = new Rectangle((int)BallPos.X, (int)BallPos.Y, 24, 24);
        }
        public Rectangle GetHitbox()
        {
            return Hitbox;
        }
        public void Draw(SpriteBatch _SB)
        {
            _SB.Draw(BallTex, BallPos, new Rectangle(Row * 24, 0, 24, 24), Color.White);
        }
        public void RandomNewPos()
        {

            int NewPosX = RNG.Next(0, GraphicsDeviceManager.DefaultBackBufferWidth - 24);
            int NewPosY = RNG.Next(0, GraphicsDeviceManager.DefaultBackBufferHeight - 24);
            BallPos.X = NewPosX;
            BallPos.Y = NewPosY;
        }
    }
}
