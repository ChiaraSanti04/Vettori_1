using System;

namespace Vectors
{
    internal class Vettore
    {
        public double X { get; }
        public double Y { get; }

        public Vettore(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }

        public static Vettore Parse(string s)
        {
            string[] parts = s.Trim('(', ')').Split(',');
            if (parts.Length == 2 && double.TryParse(parts[0], out double x) && double.TryParse(parts[1], out double y))
            {
                return new Vettore(x, y);
            }
            else
            {
                throw new FormatException("Input string was not in a correct format.");
            }
        }

        public static bool TryParse(string s, out Vettore v)
        {
            v = null;
            try
            {
                v = Parse(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static double Modulo(Vettore v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static Vettore operator +(Vettore v)
        {
            return v;
        }

        public static Vettore operator -(Vettore v)
        {
            return new Vettore(-v.X, -v.Y);
        }

        public static Vettore operator +(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vettore operator -(Vettore v1, Vettore v2)
        {
            return new Vettore(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vettore operator *(Vettore v1, double scalar)
        {
            return new Vettore(v1.X * scalar, v1.Y * scalar);
        }

        public static Vettore operator *(double scalar, Vettore v1)
        {
            return v1 * scalar;
        }

        public static Vettore operator /(Vettore v1, double scalar)
        {
            if (scalar == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return new Vettore(v1.X / scalar, v1.Y / scalar);
        }

        public static double Distance(Vettore v1, Vettore v2)
        {
            double dx = v1.X - v2.X;
            double dy = v1.Y - v2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static bool operator ==(Vettore v1, Vettore v2)
        {
            if (ReferenceEquals(v1, null))
            {
                return ReferenceEquals(v2, null);
            }
            else if (ReferenceEquals(v2, null))
            {
                return false;
            }
            else
            {
                return v1.X == v2.X && v1.Y == v2.Y;
            }
        }

        public static bool operator !=(Vettore v1, Vettore v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vettore other = (Vettore)obj;
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
    }
}
