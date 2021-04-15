using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form4 : Form
    {
        bool rotate = false;
        int angle = 0;
        Rectangle r = new Rectangle(0, 0, 100, 50);

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rotate = true;

            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = img;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(rotate)
            {
                using (Matrix m = new Matrix())
                {
                    //Graphics g = e.Graphics;
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        angle = (angle + 90) % 360;
                        m.RotateAt(angle, new PointF(pictureBox1.Image.Width / 2, pictureBox1.Image.Height / 2));
                        PointF rectCenter = new PointF(r.X + r.Width / 2, r.Y + r.Height / 2);
                        PointF rectCenterRotated = new PointF(r.X + r.Width / 2, r.Y + r.Height / 2);
                        m.TransformPoints(new PointF[] { rectCenterRotated });

                        g.Transform = m;
                        g.DrawLine(Pens.Yellow, rectCenter, rectCenterRotated);
                        g.DrawRectangle(Pens.Red, r);
                        g.ResetTransform();
                    }
                }
                rotate = false;
            }
            else
             e.Graphics.DrawRectangle(Pens.Red, r);
        }
    }
}
