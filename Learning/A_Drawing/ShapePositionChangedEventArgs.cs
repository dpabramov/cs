using System.Drawing;

namespace A_Drawing
{
    public class ShapePositionChangedEventArgs
    {
        public int[,] Shape = new int[2, 4];

        public int[,] PreviosShape = new int[2, 4];

        public Brush ShapeColor;
    }
}