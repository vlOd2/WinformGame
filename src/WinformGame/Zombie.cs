using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WinformGame
{
    public class Zombie : Entity
    {
        private bool movingBackToStart;

        public override void Update(int canvasWidth, int canvasHeight)
        {
            if (!movingBackToStart)
                X += 5;
            else
                X -= 5;

            if (X <= 0)
                movingBackToStart = false;
            if (X >= canvasWidth - Width) 
                movingBackToStart = true;

            base.Update(canvasWidth, canvasHeight);
        }

        public override void Render(Graphics graphics, int canvasWidth, int canvasHeight)
        {
            MainForm.DrawStringCenter(graphics, "Don't touch me!", X + Width / 2, Y - 16, Color);
            base.Render(graphics, canvasWidth, canvasHeight);
        }
    }
}
