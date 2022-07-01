using System.Drawing;

namespace A_Drawing
{
    public class NewShapeCreatedEventArgs
    {
        public int[,] Shape = new int[2, 4];

        public Brush ShapeColor;
    }
}