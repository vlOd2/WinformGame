namespace WinformGame
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gc = new WinformGame.GameCanvas();
            this.SuspendLayout();
            // 
            // gc
            // 
            this.gc.BackColor = System.Drawing.Color.White;
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(509, 325);
            this.gc.TabIndex = 0;
            this.gc.OnDrawTick += new System.EventHandler(this.gc_OnDrawTick);
            this.gc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gc_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 325);
            this.Controls.Add(this.gc);
            this.MinimumSize = new System.Drawing.Size(123, 50);
            this.Name = "MainForm";
            this.Text = "WinformGame";
            this.ResumeLayout(false);

        }

        #endregion

        private GameCanvas gc;



    }
}

