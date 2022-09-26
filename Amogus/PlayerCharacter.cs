using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Amogus
{
    class PlayerCharacter
    {
        private Texture2D CharacterTex;
        protected Vector2 PlayerPos;
        public Rectangle Hitbox;
        private int Speed = 2;

        int Frame;
        int Row;
        float TotalElapsed;
        float TimePerFrame;
        int FramePerSec;
        public PlayerCharacter(Vector2 Pos)
        {
            PlayerPos = Pos;
        }
        public void Load(ContentManager Content)
        {
            CharacterTex = Content.Load<Texture2D>("Char01");
            Frame = 0;
            Row = 0;
            FramePerSec = 7;
            TimePerFrame = (float)1 / FramePerSec;
            TotalElapsed = 0;
        }
        public void MoveUp()
        {
            PlayerPos.Y -= Speed;
            Row = 3;
        }
        public void MoveDown()
        {
            PlayerPos.Y += Speed;
            Row = 0;
        }
        public void MoveLeft()
        {
            PlayerPos.X -= Speed;
            Row = 1;
        }
        public void MoveRight()
        {
            PlayerPos.X += Speed;
            Row = 2;
        }
        public void SprintOn()
        {
            Speed = 20;
        }
        public void SprintOff()
        {
            Speed = 2;
        }
        public void UpdatePos()
        {
            Hitbox = new Rectangle((int)PlayerPos.X, (int)PlayerPos.Y, 32, 48);
        }
        public void UpdateFrame(float Elapsed)
        {
            TotalElapsed += Elapsed;
            if (TotalElapsed > TimePerFrame)
            {
                Frame = (Frame + 1) % 3;
                TotalElapsed -= TimePerFrame;
            }
            if (Frame > 3)
            {
                Frame = 0;
            }
        }
        public void ResetAnimFrame()
        {
            Frame = 0;
        }
        public bool CheckIntersect(Rectangle IntersectedRectangle)
        {
            if (Hitbox.Intersects(IntersectedRectangle) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Draw(SpriteBatch _SB)
        {
            _SB.Draw(CharacterTex, PlayerPos, new Rectangle(Frame * 32, Row * 48, 32, 48), Color.White);
        }
    }
}
