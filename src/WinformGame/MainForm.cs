using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformGame
{
    public partial class MainForm : Form
    {
        private static readonly Font GAME_FONT = new Font(FontFamily.GenericSerif, 10.0F);
        private RawKeyboard rawKeyboard = new RawKeyboard();
        private long ticksSinceFramerateCalc;
        private int framesSinceSecond;
        private int framerate;
        public readonly List<Entity> Entities = new List<Entity>();
        public Player Player = new Player();

        public MainForm()
        {
            InitializeComponent();
            Entities.Add(Player);
        }

        public static long GetCurrentUnixMillis() 
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static void DrawString(Graphics graphics, string str, int x, int y, Brush color) 
        {
            graphics.DrawString(str, GAME_FONT, color, x, y);
        }

        public static void DrawStringCenter(Graphics graphics, string str, int x, int y, Brush color)
        {
            graphics.DrawString(str, GAME_FONT, color, x - TextRenderer.MeasureText(str, GAME_FONT).Width / 2, y);
        }

        private void gc_OnDrawTick(object sender, EventArgs e)
        {
            gc.SetupCanvas();
            Graphics graphics = gc.GetCanvasGraphics();

            framesSinceSecond++;
            long currentTime = GetCurrentUnixMillis();
            if (currentTime - ticksSinceFramerateCalc >= 1000) 
            {
                framerate = framesSinceSecond;
                framesSinceSecond = 0;
                ticksSinceFramerateCalc = currentTime;
            }

            OnGameTick(graphics);
        }

        private void gc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
                Entities.Add(new Zombie());
        }

        private void OnGameTick(Graphics graphics)
        {
            rawKeyboard.Update();

            if (rawKeyboard.IsPressed(Keys.A))
                Player.X -= 5;
            if (rawKeyboard.IsPressed(Keys.D))
                Player.X += 5;
            if (rawKeyboard.IsPressed(Keys.W))
                Player.Y -= 5;
            if (rawKeyboard.IsPressed(Keys.S))
                Player.Y += 5;

            foreach (Entity entity in Entities.ToArray())
                entity.SetGame(this);
            foreach (Entity entity in Entities.ToArray()) 
                entity.Update(gc.Width, gc.Height);
            foreach (Entity entity in Entities.ToArray())
                entity.Render(graphics, gc.Width, gc.Height);

            if (Player.GetCollidingWith().Length > 0) 
            {
                Player.X = 0;
                Player.Y = 0;
            }

            DrawString(graphics, "WinformGame: A game rendered using winforms", 0, 0, Brushes.Black);
            DrawString(graphics, "Framerate: " + framerate, 0, 10, Brushes.Black);
            DrawString(graphics, "Entities: " + Entities.Count, 0, 20, Brushes.Black);
            DrawString(graphics, "X: " + Player.X, 0, 30, Brushes.Black);
            DrawString(graphics, "Y: " + Player.Y, 0, 40, Brushes.Black);
        }
    }
}
