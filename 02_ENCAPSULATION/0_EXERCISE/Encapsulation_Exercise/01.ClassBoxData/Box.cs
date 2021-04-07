using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                ThroIfInvalideSide(value, nameof(Length));
                length = value;
            }
        }
        public double Width
        {
            get => length;
            private set
            {
                ThroIfInvalideSide(value, nameof(Width));
                width = value;
            }
        }
        public double Height
        {
            get => length;
            private set
            {
                ThroIfInvalideSide(value, nameof(Height));
                height = value;
            }
        }

        public double Volume()
        {
            return length * width * height;
        }
        public double LateralSurfaceArea()
        {
            return 2 * length * height + 2 * width * height;
        }
        public double SurfaceArea()
        {
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        private void ThroIfInvalideSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} cannot be zero or negative.");
            }
        }
    }
}
