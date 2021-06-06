using static System.Console;

namespace SOLID
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        public new int Width
        {
            set
            {
                base.Width = base.Height = value;
            } 
        }

        public new int Height
        {
            set
            {
                base.Width = base.Height = value;
            }
        }
    }

    public class LSP
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        public static void MainLSP()
        {
            Rectangle rectangle = new Rectangle(2, 3);
            WriteLine($"{rectangle} has area {Area(rectangle)}");

            Square square = new Square();
            square.Width = 4;
            WriteLine($"{square} has area {Area(square)}");

            ReadKey();
        }
    }
}
