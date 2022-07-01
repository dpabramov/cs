using System;
using System.Threading;
using System.Drawing;
using System.Reflection;

namespace A_Drawing
{
    public class Map : IDisposable
    {
        private Timer _timer;

        private int timeStep = 750;

        private int[,] _field;

        private Brush[,] _color;

        private int[,] _shape = new int[2, 4];

        private Brush _shapeColor;

        public int FieldWidth { get => _field.GetLength(0); }

        public int FieldHeight { get => _field.GetLength(1); }

        public event EventHandler<NewMapCreatedEventArgs> NewMapCreated;

        public event EventHandler<NewShapeCreatedEventArgs> NewShapeCreated;

        public event EventHandler<ShapePositionChangedEventArgs> ShapePositionChanged;

        public Map(int width, int height)
        {
            //создаем пустую карту 
            _field = new int[width, height];

            //массив цветов карты
            _color = new Brush[width, height];

            //заполняем дно на карте
            for (int i = 0; i < width; i++)
            {
                _field[i, height - 1] = 1;
                _color[i, height - 1] = Brushes.Green;
            }

            //заполним боковые границы
            for (int i = 0; i < height; i++)
            {
                _field[0, i] = _field[width - 1, i] = 1;
                _color[0, i] = _color[width - 1, i] = Brushes.Green;
            }
        }

               private void OnTimer(object state)
        {
            ShapeDown();
        }

        private void NewFigure()
        {
            Random x = new Random();
            switch (x.Next(7))
            {
                case 0: _shape = new int[,] { { 6, 7, 8, 9 }, { 1, 1, 1, 1 } }; break;
                case 1: _shape = new int[,] { { 6, 7, 6, 7 }, { 1, 1, 2, 2 } }; break;
                case 2: _shape = new int[,] { { 6, 7, 8, 8 }, { 1, 1, 1, 0 } }; break;
                case 3: _shape = new int[,] { { 6, 6, 7, 8 }, { 0, 1, 1, 1 } }; break;
                case 4: _shape = new int[,] { { 6, 7, 7, 8 }, { 1, 1, 2, 2 } }; break;
                case 5: _shape = new int[,] { { 6, 6, 7, 7 }, { 0, 1, 1, 2 } }; break;
                case 6: _shape = new int[,] { { 6, 7, 7, 8 }, { 1, 1, 0, 1 } }; break;
            }

            _shapeColor = RandomBrush();

            if (!IsPossible(_shape))
                Environment.Exit(0);
            else
            {
                var spc = new NewShapeCreatedEventArgs
                {
                    Shape = _shape,
                    ShapeColor = _shapeColor
                };

                NewShapeCreated?.Invoke(this, spc);
            }
        }

        private void ModifyRemoveNewFigure()
        {
            ModifyFieldByShape();
            RemoveFullLines();
            NewFigure();
        }

        private void RemoveFullLines()
        {
            //номер заполненной строки
            int numberFullLine = 0;
            bool isNumberFullLine = false;

            do
            {
                //если заполненная строка есть,
                //то запоминаем ее номер и выставляем флаг
                for (int j = _field.GetLength(1) - 2; j > 1; j--)
                {
                    numberFullLine = j;
                    isNumberFullLine = true;

                    for (int i = 1; i < _field.GetLength(0) - 1; i++)
                    {
                        if (_field[i, j] == 0)
                        {
                            isNumberFullLine = false;
                            break;
                        }
                    }

                    if (isNumberFullLine)
                        break;
                }

                if (isNumberFullLine)
                {
                    //очищаем всю строку  
                    for (int i = 1; i < _field.GetLength(0) - 1; i++)
                    {
                        _field[i, numberFullLine] = 0;
                    }

                    //и смещаем остальные строки вниз
                    for (int n = numberFullLine - 1; n > 2; n--)
                    {
                        for (int m = 1; m < _field.GetLength(0) - 1; m++)
                        {
                            _field[m, n + 1] = _field[m, n];
                            _field[m, n] = 0;
                        }
                    }
                }
            }
            while (isNumberFullLine);

            var nmc = new NewMapCreatedEventArgs
            {
                Field = _field,
                Color = _color
            };

            NewMapCreated?.Invoke(this, nmc);
        }

        private void ModifyFieldByShape()
        {
            for (int i = 0; i < 4; i++)
            {
                _field[_shape[0, i], _shape[1, i]] = 1;
                _color[_shape[0, i], _shape[1, i]] = _shapeColor;
            }

            NewShapeCreated?.Invoke(this,
                    new NewShapeCreatedEventArgs
                    {
                        Shape = _shape,
                        ShapeColor = _shapeColor
                    });
        }

        private void UpdateShapeByNewShape(int[,] newShape)
        {
            _shape = (int[,])newShape.Clone();
        }

        private bool IsPossible(int[,] newShape)
        {
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    if (_field[newShape[0, i], newShape[1, i]] == 1)
                        return false;
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        private int[,] GetCopyShape()
        {
            return (int[,])_shape.Clone();
        }

        private Brush RandomBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            //черный не берем, т.к. это цвет поля
            do
            {
                int random = rnd.Next(properties.Length);
                result = (Brush)properties[random].GetValue(null, null);
            }
            while (result == Brushes.Black);

            return result;
        }

        private void UpdateShapeAndFireEventShapePositionChanged(int[,] newShape)
        {
            var tempShape = (int[,])_shape.Clone();

            UpdateShapeByNewShape(newShape);

            ShapePositionChanged?.Invoke(this,
                new ShapePositionChangedEventArgs
                {
                    Shape = _shape,
                    PreviosShape = tempShape,
                    ShapeColor = _shapeColor
                });
        }

        public void Run()
        {
            NewMapCreated?.Invoke(this,
                new NewMapCreatedEventArgs
                {
                    Field = _field,
                    Color = _color
                });

            //создаем новую фигурку
            NewFigure();

            _timer = new Timer(OnTimer, null, 0, timeStep);
        }

        public void Stop()
        {
            //_timer = new Timer(OnTimer, null, 0, timeStep);
            _timer.Dispose();
        }

        public void Continue()
        {
            _timer = new Timer(OnTimer, null, 0, timeStep);
        }

        public void ShapeLeft()
        {
            int[,] newShape = GetCopyShape();

            for (int i = 0; i < 4; i++)
                newShape[0, i] -= 1;

            if (IsPossible(newShape))
                UpdateShapeAndFireEventShapePositionChanged(newShape);
        }

        public void ShapeRight()
        {
            int[,] newShape = GetCopyShape();

            for (int i = 0; i < 4; i++)
                newShape[0, i] += 1;

            if (IsPossible(newShape))
                UpdateShapeAndFireEventShapePositionChanged(newShape);
        }

        public void ShapeRotate()
        {
            int[,] newShape = new int[2, 4];

            newShape[0, 1] = _shape[0, 1];
            newShape[1, 1] = _shape[1, 1];

            for (int i = 0; i < 4; i++)
            {
                if (i != 1)
                {
                    if (_shape[0, i] < _shape[0, 1] && _shape[1, i] == _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1];
                        newShape[1, i] = _shape[1, 1] + _shape[0, 1] - _shape[0, i];
                    }

                    if (_shape[0, i] == _shape[0, 1] && _shape[1, i] > _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] + _shape[1, i] - _shape[1, 1];
                        newShape[1, i] = _shape[1, 1];
                    }

                    if (_shape[0, i] > _shape[0, 1] && _shape[1, i] == _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1];
                        newShape[1, i] = _shape[1, 1] - (_shape[0, i] - _shape[0, 1]);
                    }

                    if (_shape[0, i] == _shape[0, 1] && _shape[1, i] < _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] - (_shape[1, 1] - _shape[1, i]);
                        newShape[1, i] = _shape[1, 1];
                    }

                    if (_shape[0, i] < _shape[0, 1] && _shape[1, i] > _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] + 1;
                        newShape[1, i] = _shape[1, 1] + 1;
                    }

                    if (_shape[0, i] > _shape[0, 1] && _shape[1, i] > _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] + 1;
                        newShape[1, i] = _shape[1, 1] - 1;
                    }

                    if (_shape[0, i] > _shape[0, 1] && _shape[1, i] < _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] - 1;
                        newShape[1, i] = _shape[1, 1] - 1;
                    }

                    if (_shape[0, i] < _shape[0, 1] && _shape[1, i] < _shape[1, 1])
                    {
                        newShape[0, i] = _shape[0, 1] - 1;
                        newShape[1, i] = _shape[1, 1] + 1;
                    }
                }
            }

            if (IsPossible(newShape))
                UpdateShapeAndFireEventShapePositionChanged(newShape);
        }

        public void ShapeDown()
        {
            int[,] newShape = GetCopyShape();

            for (int i = 0; i < 4; i++)
            {
                newShape[1, i]++;
            }

            if (IsPossible(newShape))
                UpdateShapeAndFireEventShapePositionChanged(newShape);
            else
                ModifyRemoveNewFigure();
        }

        public void ShapeDrop()
        {
            int[,] newShape = GetCopyShape();

            int[,] PrevShape = GetCopyShape();

            for (int i = 0; i < 4; i++)
                newShape[1, i]++;

            while (IsPossible(newShape))
            {
                UpdateShapeByNewShape(newShape);

                for (int i = 0; i < 4; i++)
                    newShape[1, i]++;
            }

            ShapePositionChanged?.Invoke(this,
                new ShapePositionChangedEventArgs
                {
                    Shape = _shape,
                    PreviosShape = PrevShape,
                    ShapeColor = _shapeColor
                });

            ModifyRemoveNewFigure();
        }

        public void Dispose()
        {
            _timer.Dispose();

            _shapeColor.Dispose();
        }
    }
}
