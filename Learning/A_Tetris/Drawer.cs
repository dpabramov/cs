using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tetris
{
    class Drawer
    {
        //public Graphics gr = new Graphics(); // Для рисования поля на PictureBox

        public void DrawFromImage(Bitmap bitmap, Graphics gr)
        {
            gr = Graphics.FromImage(bitmap);
        }

        public void FillField(System.Windows.Forms.PictureBox pictureBox,
            TetrisField tetrisField, 
            Shape shape,
            Graphics gr)
        {
            //формируем картинку

            //заливаем фон
            gr.Clear(Color.White);

            int k = tetrisField.PixelSize;

            //границы стакана
            for (int i = 0; i < tetrisField.FieldWidth; i++)
                for (int j = 0; j < tetrisField.FieldHeight; j++)
                {
                    if (tetrisField.Field[i, j] == 1)
                        gr.FillRectangle(Brushes.Green, i * k, j * k, k, k);
                    //горизонтали и вертикали
                    gr.DrawRectangle(Pens.Gray, i * k, j * k, k, k);
                }

            //добавим фигурку
            for (int i = 0; i < shape.Figure.GetLength(1); i++)
            {
                gr.FillRectangle(Brushes.Red, shape.Figure[1, i] * k, shape.Figure[0, i] * k, k, k);
                gr.DrawRectangle(Pens.Gray, shape.Figure[1, i] * k, shape.Figure[0, i] * k, k, k);
            }

            //рисуем
            pictureBox.Image = tetrisField.Bitfield;
        }
    }
}
