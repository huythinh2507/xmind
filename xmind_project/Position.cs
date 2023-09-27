using System;

namespace xmind_project
{
    public class Position
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Position() { }
        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        internal double GetX()
        {
            return X;
        }
        internal double GetY()
        {
            return Y;
        }

        public Position SetNewPosition(double x, double y)
        {
            X = (double)x;
            Y = (int)y;
            return this;
        }
        public Position SetNewXPosition(double x)
        {
            X = (double)x;
            return this;
        }
        public Position SetNewYPosition(double y)
        {
            Y = (double)y;
            return this;
        }
    }
}