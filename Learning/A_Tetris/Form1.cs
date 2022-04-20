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
        public const int width = 15, height = 25, k = 20; // Размеры поля и размер клетки в пикселях
        public int[,] shape = new int[2, 4]; // Массив для хранения падающей фигурки (для каждого блока 2 координаты [0, i] и [1, i]
        public int[,] field = new int[width, height]; // Массив для хранения поля
        public Bitmap bitfield = new Bitmap(k * width, k * height);
        public Graphics gr; // Для рисования поля на PictureBox

        public Form1()
        {
            InitializeComponent();
            gr = Graphics.FromImage(bitfield);
            //заполним стакан-поле данными
            for (int i = 0; i < width; i++)
                field[i, height - 1] = 1;

            for (int i = 0; i < height; i++)
            {
                field[0, i] = 1;
                field[width - 1, i] = 1;
            }

            // задаем фигурку в стакане
            SetShape();
            //FillField();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    for (int i = 0; i < 4; i++)
                        shape[1, i]--;
                    if (FindMistake())
                        for (int i = 0; i < 4; i++)
                            shape[1, i]++;
                    break;
                case Keys.D:
                    for (int i = 0; i < 4; i++)
                        shape[1, i]++;
                    if (FindMistake())
                        for (int i = 0; i < 4; i++)
                            shape[1, i]--;
                    break;
                case Keys.W:
                    var shapeT = new int[2, 4];
                    Array.Copy(shape, shapeT, shape.Length);
                    int maxx = 0, maxy = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (shape[0, i] > maxy)
                            maxy = shape[0, i];
                        if (shape[1, i] > maxx)
                            maxx = shape[1, i];
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        int temp = shape[0, i];
                        shape[0, i] = maxy - (maxx - shape[1, i]) - 1;
                        shape[1, i] = maxx - (3 - (maxy - temp)) + 1;
                    }
                    if (FindMistake())
                        Array.Copy(shapeT, shape, shape.Length);
                    break;
            }
            FillField();
        }

        public void FillField()
        {
            //формируем картинку
            //заливаем фон
            gr.Clear(Color.White);

            //границы стакана
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j] == 1)
                        gr.FillRectangle(Brushes.Green, i * k, j * k, k, k);
                    //горизонтали и вертикали
                    gr.DrawRectangle(Pens.Gray, i * k, j * k, k, k);
                }

            //добавим фигурку
            for (int i = 0; i < shape.GetLength(1); i++)
            {
                gr.FillRectangle(Brushes.Red, shape[1, i] * k, shape[0, i] * k, k, k);
                gr.DrawRectangle(Pens.Gray, shape[1, i] * k, shape[0, i] * k, k, k);
            }

            //рисуем
            pictureBox1.Image = bitfield;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (field[8, 3] == 1)
                Environment.Exit(0);
            for (int i = 0; i < 4; i++)
                shape[0, i]++;
            for (int i = height - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, field.GetLength(0)).Select(j => field[j, i]).ToArray() where t == 1 select t).Count();
                if (cross == width)
                    for (int k = i; k > 1; k--)
                        for (int l = 1; l < width - 1; l++)
                            field[l, k] = field[l, k - 1];
            }
            if (FindMistake())
            {
                for (int i = 0; i < 4; i++)
                    field[shape[1, i], --shape[0, i]]++;
                SetShape();
            }
            FillField();
        }

        public void SetShape()
        {
            Random x = new Random(DateTime.Now.Millisecond);
            switch (x.Next(7))
            {
                case 0: shape = new int[,] { { 1, 2, 3, 4 }, { 8, 8, 8, 8 } }; break;
                case 1: shape = new int[,] { { 1, 2, 1, 2 }, { 8, 8, 9, 9 } }; break;
                case 2: shape = new int[,] { { 1, 2, 3, 3 }, { 8, 8, 8, 9 } }; break;
                case 3: shape = new int[,] { { 1, 2, 3, 3 }, { 8, 8, 8, 7 } }; break;
                case 4: shape = new int[,] { { 2, 2, 3, 3 }, { 7, 8, 8, 9 } }; break;
                case 5: shape = new int[,] { { 2, 2, 3, 3 }, { 9, 8, 8, 7 } }; break;
                case 6: shape = new int[,] { { 2, 3, 3, 3 }, { 8, 7, 8, 9 } }; break;
            }
        }

        public bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                if (shape[1, i] >= width || shape[0, i] >= height ||
                    shape[1, i] <= 0 || shape[0, i] <= 0 ||
                    field[shape[1, i], shape[0, i]] == 1)
                    return true;
            return false;
        }
    }
}
