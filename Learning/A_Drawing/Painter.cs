using System;
using System.Drawing;

namespace A_Drawing
{
    public class Painter
    {
        private Map _map;

        private int _width { get => _map.FieldWidth; }

        private int _height { get => _map.FieldHeight; }

        private int _size { get; set; }

        private Bitmap _bitfield;

        private Graphics Gr;

        public event EventHandler<BitfieldUpdatedEventArgs> BitfieldUpdated;

        public Painter(Map map, int size)
        {
            _map = map;

            _size = size;

            _bitfield = new Bitmap(_width * _size, _height * _size);

            Gr = Graphics.FromImage(_bitfield);

            _map.ShapePositionChanged += _map_ShapePositionChanged;

            _map.NewShapeCreated += _map_NewShapeCreated;

            _map.NewMapCreated += _map_NewMapCreated;
        }

        private void _map_NewMapCreated(object sender, NewMapCreatedEventArgs e)
        {
            //формируем карту для отображения на форме
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (e.Field[i, j] == 1)
                        Gr.FillRectangle(e.Color[i, j], i * _size, j * _size, _size, _size);
                    else
                        Gr.FillRectangle(Brushes.Black, i * _size, j * _size, _size, _size);

                    Gr.DrawRectangle(Pens.Gray, i * _size, j * _size, _size, _size);
                }
            }

            //рисуем на форме
            DrawBitfield();
        }

        private void _map_NewShapeCreated(object sender, NewShapeCreatedEventArgs e)
        {
            //формируем фигурку на карте
            ModifyBitfieldByShape(e.ShapeColor, e.Shape);

            //рисуем на форме
            DrawBitfield();
        }

        private void _map_ShapePositionChanged(object sender, ShapePositionChangedEventArgs e)
        {
            //затираем старое положение фигурки на карте
            ModifyBitfieldByShape(Brushes.Black, e.PreviosShape);

            //изменяем карту по фигурке
            ModifyBitfieldByShape(e.ShapeColor, e.Shape);

            //рисуем на форме
            DrawBitfield();
        }

        private void DrawBitfield()
        {
            BitfieldUpdated?.Invoke(this,
                         new BitfieldUpdatedEventArgs
                         {
                             Bitfield = _bitfield
                         });
        }

        private void ModifyBitfieldByShape(Brush brush, int[,] shape)
        {
            for (int i = 0; i < 4; i++)
            {
                Gr.FillRectangle(brush, shape[0, i] * _size, shape[1, i] * _size, _size, _size);

                Gr.DrawRectangle(Pens.Gray, shape[0, i] * _size, shape[1, i] * _size, _size, _size);
            }
        }

        public void ClearPicture()
        {
            Gr.Clear(Color.Black);
        }
    }
}
