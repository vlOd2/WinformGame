using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformGame
{
    public partial class GameCanvas : UserControl
    {
        private Bitmap image;
        private Graphics graphics;
        public event EventHandler OnDrawTick;

        public GameCanvas()
        {
            InitializeComponent();
        }

        public void SetupCanvas()
        {
            image = new Bitmap(Width, Height);
            graphics = Graphics.FromImage(image);
            graphics.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);
            FlushCanvas();
        }

        public void FlushCanvas()
        {
            pbCanvas.Image = image;
        }

        public Graphics GetCanvasGraphics()
        {
            return graphics;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (OnDrawTick != null) 
            {
                OnDrawTick.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
