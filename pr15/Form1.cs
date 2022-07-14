using System;
using System.Drawing;
using System.Windows.Forms;

namespace pr15 {
	public partial class Form1 : Form {

		private bool rightMouseClick, leftMouseClick;

        public Form1() {
			InitializeComponent();
		}

		private void button1_mouseHover(object sender, EventArgs e) {
			toolTip1.SetToolTip(button1, "Моя формочка");
		}

		private void toolTip1_Draw(object sender, DrawToolTipEventArgs e) {
			e.DrawBackground();
			e.DrawBorder();
			e.DrawText();
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e) {
			double X = (double)e.X/Size.Width * 255;
			double Y = (double)e.Y/Size.Height * 255;

			int red = (int)X;
			int green = (int)Y;
			int blue = (int)Y;

			BackColor = Color.FromArgb(red, green, blue);
		}

		private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				CloseForm();
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.F10)
				CloseForm();

            if (e.KeyCode == Keys.Left)
            {
                this.Left -= 5;
            }

			if (e.KeyCode == Keys.Right)
				this.Left += 5;
			if (e.KeyCode == Keys.Up)
				this.Top -= 5;
			if (e.KeyCode == Keys.Down)
				this.Top += 5;

            Invalidate();
		}

		private void CloseForm()
        {
			DialogResult result = MessageBox.Show("Хотите выйти из программы?",
				"Выход из программы", MessageBoxButtons.OKCancel);

			if (result == DialogResult.OK)
				this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Right)
            {
				rightMouseClick = true;

				if (ModifierKeys == Keys.Shift)
                {
					this.Height += 5;
					this.Width += 5;
				}
				else
                {
					this.Height -= 5;
					this.Width -= 5;
				}
            }
			if (e.Button == MouseButtons.Left)
				leftMouseClick = true;

			if (e.Button == MouseButtons.Middle || leftMouseClick == rightMouseClick)
            {
				this.Location = new Point(Cursor.Position.X - this.Width/2, Cursor.Position.Y - this.Height/2);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
			label2.Text = "Изменение размера: " + this.Height + " " + this.Width;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
				leftMouseClick = false;
				rightMouseClick = false;
            }
        }
    }
}
