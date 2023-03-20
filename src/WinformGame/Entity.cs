using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WinformGame
{
    public abstract class Entity
    {
        protected MainForm game;
        public int X;
        public int Y;
        public int Width = 16;
        public int Height = 16;
        public Brush Color = Brushes.Black;
        public AABB AABB = new AABB();
        public bool HasGravity = true;

        public void SetGame(MainForm game) 
        {
            this.game = game;
        }

        public virtual void Update(int canvasWidth, int canvasHeight) 
        {
            if (X < 0)
                X = 0;
            if (X >= canvasWidth - Width)
                X = canvasWidth - Width;
            if (Y < 0)
                Y = 0;
            if (Y >= canvasHeight - Height)
                Y = canvasHeight - Height;

            AABB.X1 = X;
            AABB.X2 = X + Width;
            AABB.Y1 = Y;
            AABB.Y2 = Y + Height;

            if (HasGravity && Y < canvasHeight - Height)
                Y += 1;
        }

        public virtual void Render(Graphics graphics, int canvasWidth, int canvasHeight) 
        {
            graphics.FillRectangle(Color, X, Y, Width, Height);
        }

        public Entity[] GetCollidingWith() 
        {
            List<Entity> entities = new List<Entity>();

            foreach (Entity entity in game.Entities.ToArray()) 
            {
                if (entity == this) continue;
                if (AABB.IsColliding(entity.AABB))
                    entities.Add(entity);
            }

            return entities.ToArray();
        }
    }
}
