using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Tetris
{
    class Shape
    {
        //Массив поля
        TetrisField _tetrisField;

        //Массив для хранения падающей фигурки
        public int[,] Figure = new int[2, 4];

        public Shape(TetrisField tetrisField)
        {
            _tetrisField = tetrisField;
        }

        public void NewFigure()
        {
            Random x = new Random(DateTime.Now.Millisecond);
            switch (x.Next(7))
            {
                case 0: Figure = new int[,] { { 1, 2, 3, 4 }, { 8, 8, 8, 8 } }; break;
                case 1: Figure = new int[,] { { 1, 2, 1, 2 }, { 8, 8, 9, 9 } }; break;
                case 2: Figure = new int[,] { { 1, 2, 3, 3 }, { 8, 8, 8, 9 } }; break;
                case 3: Figure = new int[,] { { 1, 2, 3, 3 }, { 8, 8, 8, 7 } }; break;
                case 4: Figure = new int[,] { { 2, 2, 3, 3 }, { 7, 8, 8, 9 } }; break;
                case 5: Figure = new int[,] { { 2, 2, 3, 3 }, { 9, 8, 8, 7 } }; break;
                case 6: Figure = new int[,] { { 2, 3, 3, 3 }, { 8, 7, 8, 9 } }; break;
            }
        }

        public void ToLeft()
        {
            for (int i = 0; i < 4; i++)
                Figure[1, i]--;
            if (FindMistake())
                for (int i = 0; i < 4; i++)
                    Figure[1, i]++;
        }

        public void ToRight()
        {
            for (int i = 0; i < 4; i++)
                Figure[1, i]++;
            if (FindMistake())
                for (int i = 0; i < 4; i++)
                    Figure[1, i]--;
        }

        public void Rotate()
        {
            var shapeT = new int[2, 4];
            Array.Copy(Figure, shapeT, Figure.Length);
            int maxx = 0, maxy = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Figure[0, i] > maxy)
                    maxy = Figure[0, i];
                if (Figure[1, i] > maxx)
                    maxx = Figure[1, i];
            }
            for (int i = 0; i < 4; i++)
            {
                int temp = Figure[0, i];
                Figure[0, i] = maxy - (maxx - Figure[1, i]) - 1;
                Figure[1, i] = maxx - (3 - (maxy - temp)) + 1;
            }
            if (FindMistake())
                Array.Copy(shapeT, Figure, Figure.Length);
        }

        public bool FindMistake()
        {
            for (int i = 0; i < 4; i++)
                if (Figure[1, i] >= _tetrisField.FieldWidth
                    || Figure[0, i] >= _tetrisField.FieldHeight
                    || Figure[1, i] <= 0 || Figure[0, i] <= 0
                    || _tetrisField.Field[Figure[1, i], Figure[0, i]] == 1)
                    return true;
            return false;
        }
    }
}
