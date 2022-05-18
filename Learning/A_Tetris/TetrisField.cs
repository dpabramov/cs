using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tetris
{
    public class TetrisField
    {
        //Массив для хранения поля
        public int[,] Field;

        //Битовая матрица для прорисовки на форме
        public Bitmap Bitfield;

        public int FieldWidth => (int)Field.GetLongLength(0);

        public int FieldHeight => (int)Field.GetLongLength(1);

        public int BitfieldWidth => Bitfield.Width;

        public int BitfieldHeight => Bitfield.Height;

        public int PixelSize => BitfieldWidth / FieldWidth;

        //Размер поля в ширину в клетках, глубину в клетках 
        //и размер клетки в пикселях
        public TetrisField(int width = 15, int height = 25, int pixelSize = 20)
        {
            Field = new int[width, height];

            Bitfield = new Bitmap(pixelSize * width, pixelSize * height);
        }

        public void InitializeField()
        {
            //заполним стакан-поле данными
            for (int i = 0; i < FieldWidth; i++)
                Field[i, FieldHeight - 1] = 1;

            for (int i = 0; i < FieldHeight; i++)
            {
                Field[0, i] = 1;
                Field[FieldWidth - 1, i] = 1;
            }
        }
    }
}