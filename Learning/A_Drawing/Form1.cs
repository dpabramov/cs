using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Drawing
{
    public partial class Form1 : Form
    {
        public const int width = 15, height = 25, size = 25;

        Map map;

        Painter painter;

        public Form1()
        {
            InitializeComponent();

            map = new Map(width, height);

            painter = new Painter(map, size);

            painter.ClearPicture();

            painter.BitfieldUpdated += Painter_BitfieldUpdated;

            map.Run();
        }

        private void стопToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            map.Stop();
        }

        private void продолжитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            map.Continue();
        }

        private void Painter_BitfieldUpdated(object sender, BitfieldUpdatedEventArgs e)
        {
            pictureBox1.Image = e.Bitfield;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    map.ShapeLeft();
                    break;
                case Keys.Right:
                    map.ShapeRight();
                    break;
                case Keys.Up:
                    map.ShapeRotate();
                    break;
                case Keys.Space:
                    map.ShapeDrop();
                    break;
            }
        }
    }
}
