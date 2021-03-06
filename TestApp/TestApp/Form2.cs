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
    public partial class Form2 : Form
    {
        private float aspectWidth;
        private float aspectHeight;
        private float aspectX;
        private float aspectY;
        private Dictionary<string, List<float>> _aspectLocs;
        private Dictionary<string, List<float>> _aspectDims;

        public Form2()
        {
            InitializeComponent();
            _aspectLocs = new Dictionary<string, List<float>>();
            _aspectDims = new Dictionary<string, List<float>>();
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            if(aspectWidth != 0 && aspectHeight != 0 && aspectX != 0 && aspectY != 0)
            {
                foreach (Control c in this.Controls)
                {
                    Button b = c as Button;

                    if (b != null)
                    {
                        //b.Width = Convert.ToInt32(Math.Round(_aspectDims[b.Text][0] * this.Width));
                        //b.Height = Convert.ToInt32(Math.Round(_aspectDims[b.Text][1] * this.Height));
                        //b.Location = new Point(Convert.ToInt32(Math.Round(this.Width * _aspectLocs[b.Text][0])), Convert.ToInt32(Math.Round(this.Height * _aspectLocs[b.Text][1])));
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                aspectX = c.Location.X  / (this.Width * 1.0f);
                aspectY = c.Location.Y / (this.Height * 1.0f);

                this._aspectLocs.Add(c.Text, new List<float>() { aspectX, aspectY });

                aspectWidth = c.Width / (this.Width * 1.0f);
                aspectHeight = c.Height / (this.Height * 1.0f);
                this._aspectDims.Add(c.Text, new List<float>() { aspectWidth, aspectHeight });
            }
        }

        PointF TransformPoint(RectangleF source, RectangleF destination, PointF point)
        {
            return new PointF(
                ((point.X - source.X) / source.Width) * destination.Width + destination.X,
                ((point.Y - source.Y) / source.Height) * destination.Height + destination.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
