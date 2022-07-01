using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Tetris
{
    public partial class Form1 : Form
    {
        //public const int width = 15, height = 25, k = 20; // Размеры поля и размер клетки в пикселях
        //public int[,] shape = new int[2, 4]; // Массив для хранения падающей фигурки (для каждого блока 2 координаты [0, i] и [1, i]
        //public int[,] field = new int[width, height]; // Массив для хранения поля
        //public Bitmap bitfield = new Bitmap(k * width, k * height);
        public Graphics gr; // Для рисования поля на PictureBox

        TetrisField tetrisField;

        Shape shape;

        Drawer dr;


        public Form1()
        {
            InitializeComponent();

            tetrisField = new TetrisField();

            shape = new Shape(tetrisField);

            dr = new Drawer();

            dr.DrawFromImage(tetrisField.Bitfield, gr);

            

            // получим новую фигурку
            shape.NewFigure();
            //FillField();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    shape.ToLeft();
                    break;
                case Keys.D:
                    shape.ToRight();
                    break;
                case Keys.W:
                    shape.Rotate();
                    break;
            }

            dr.FillField(pictureBox1, tetrisField, shape, gr);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tetrisField.Field[8, 3] == 1)
                Environment.Exit(0);
            for (int i = 0; i < 4; i++)
                shape.Figure[0, i]++;
            for (int i = tetrisField.FieldHeight - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, tetrisField.Field.GetLength(0)).Select(j => 
                tetrisField.Field[j, i]).ToArray() where t == 1 select t).Count();
                if (cross == tetrisField.FieldWidth)
                    for (int k = i; k > 1; k--)
                        for (int l = 1; l < tetrisField.FieldWidth - 1; l++)
                            tetrisField.Field[l, k] = tetrisField.Field[l, k - 1];
            }

            if (shape.FindMistake())
            {
                for (int i = 0; i < 4; i++)
                    tetrisField.Field[shape.Figure[1, i], --shape.Figure[0, i]]++;

                //?
                shape.NewFigure();
            }

            dr.FillField(pictureBox1, tetrisField, shape, gr);
        }
    }
}
