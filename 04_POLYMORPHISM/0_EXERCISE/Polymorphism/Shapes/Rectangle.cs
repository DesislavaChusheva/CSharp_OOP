using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Widht = width;
        }
        public double Height { get; set; }
        public double Widht { get; set; }

        public override double CalculateArea()
        {
            return Height * Widht;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2 * Widht;
        }

        public override string Draw()
        {
            return base.Draw() + " " + nameof(Rectangle);
        }
    }
}
