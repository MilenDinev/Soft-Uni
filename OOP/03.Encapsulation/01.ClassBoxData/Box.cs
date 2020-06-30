using System;
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
            this.Length = length;
            this.Width = width;
            this.Height = height;
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

        private double GetSurfaceArea ()
        {
            double surfaceArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

            return surfaceArea;
        }

        private double GetLateralSurfaceArea()
        {
            double lateralSurfaceArea =  (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

            return lateralSurfaceArea;
        }

        private double GetVolume()
        {
            double volume = this.Length * this.Height * this.Width;

            return volume;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Surface Area - {GetSurfaceArea():f2}");
            stringBuilder.AppendLine($"Lateral Surface Area - {GetLateralSurfaceArea():f2}");
            stringBuilder.AppendLine($"Volume - {GetVolume():f2}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
