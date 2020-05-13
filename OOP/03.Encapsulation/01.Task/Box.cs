using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Task
{
    public class Box
    {

        private double length;
        private double width;
        private double height;

        public Box(double height, double length, double width)
        {
            this.Height = height;
            this.Length = length;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value > 0)
                {
                    this.height = value;
                }

                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

            }
        }
        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value > 0)
                {
                    this.length = value;
                }

                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }

            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }

            }
        }

        public double GetSurfaceArea(double lenght, double width, double height)
        {
            double surfaceArea = 2 * (lenght * width) + 2 * (lenght * height) + 2 * (width * height);

            return surfaceArea;
        }

        public double GetLateralSurfaceArea(double lenght, double width, double height)
        {
            double lateralSurfaceArea = 2 * (lenght * height) + 2 * (width * height);

            return lateralSurfaceArea;
        }

        public double GetVolume(double lenght, double width, double height)
        {
            double volume = lenght * width * height;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Surface Area - {GetSurfaceArea(this.Length, this.Width, this.Height):f2}");
            stringBuilder.AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea(this.Length, this.Width, this.Height):f2}");
            stringBuilder.AppendLine($"Volume - {GetVolume(this.Length, this.Width, this.Height):f2}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}

