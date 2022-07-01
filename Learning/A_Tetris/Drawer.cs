using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tetris
{
    public class Drawer
    {
        Graphics _gr; // Для рисования поля на PictureBox

        TetrisField _tetrisField;  //карта

        Shape _shape;  //фигурка

        public Drawer()  //фигурка
        {
            //_gr = new Graphics();
        }

        public void DrawFromImage(Bitmap bitmap)
        {
            _gr = Graphics.FromImage(bitmap);
        }

        public void FillField(System.Windows.Forms.PictureBox pictureBox,
            TetrisField tetrisField, 
            Shape shape)
        {
            //формируем картинку

            //заливаем фон
            _gr.Clear(Color.Black);

            int k = tetrisField.PixelSize;

            //границы стакана
            for (int i = 0; i < tetrisField.FieldWidth; i++)
                for (int j = 0; j < tetrisField.FieldHeight; j++)
                {
                    if (tetrisField.Field[i, j] == 1)
                        _gr.FillRectangle(Brushes.Green, i * k, j * k, k, k);
                    //горизонтали и вертикали
                    _gr.DrawRectangle(Pens.Gray, i * k, j * k, k, k);
                }

            //добавим фигурку
            for (int i = 0; i < shape.Figure.GetLength(1); i++)
            {
                _gr.FillRectangle(Brushes.Red, shape.Figure[1, i] * k, shape.Figure[0, i] * k, k, k);
                _gr.DrawRectangle(Pens.Gray, shape.Figure[1, i] * k, shape.Figure[0, i] * k, k, k);
            }

            //рисуем
            pictureBox.Image = tetrisField.Bitfield;
        }
    }
}
