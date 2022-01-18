using System;

namespace laboratoryWork9
{
    internal class Uravnenie
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        public Uravnenie(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;

            Count++;
        }

        private double[] x;
        public double[] X
        {
            get
            {
                if (x == null) { this.Solve(); }
                return x;
            }
            private set { x = value; }
        }
        public double D { get; private set; }

        public bool Solve()
        {
            D = B * B - (4 * A * C);

            if (D < 0)
            {
                X = new double[] { };
                return false;
            }

            if (D == 0)
            {
                double x = (B * B) / (2 * A);

                X = new double[] { x };
                return true;
            }

            if (D > 0)
            {
                double x1 = ((B * B) - Math.Pow(D, 0.5)) / (2 * A);
                double x2 = ((B * B) + Math.Pow(D, 0.5)) / (2 * A);

                X = new double[] { x1, x2 };
                return true;
            }

            return false;
        }

        static public double[] Solve(double a, double b, double c)
        {
            double D = b * b - (4 * a * c);
            double x1, x2;

            if (D < 0)
            {
                return new double[] { };
            }

            if (D == 0)
            {
                x1 = (b * b) / (2 * a);
                return new double[] { x1 };
            }

            if (D > 0)
            {
                x1 = ((b * b) - Math.Pow(D, 0.5)) / (2 * a);
                x2 = ((b * b) + Math.Pow(D, 0.5)) / (2 * a);
                return new double[] { x1, x2 };
            }

            return null;
        }

        static public int Count { get; private set; }
        ~Uravnenie()
        {
            Count--;
        }

        public static Uravnenie operator ++(Uravnenie t)
        {
            t.A++;
            t.B++;
            t.C++;
            return t;
        }
        public static Uravnenie operator --(Uravnenie t)
        {
            t.A--;
            t.B--;
            t.C--;
            return t;
        }
        public static bool operator true(Uravnenie t)
        {
            return (t.X != null && t.X.Length != 0);
        }
        public static bool operator false(Uravnenie t)
        {
            return (t.X == null || t.X.Length == 0);
        }

        public static bool operator ==(Uravnenie t1, Uravnenie t2)
        {
            if (t1.A == t2.A && t1.B == t2.B && t1.C == t2.C)
                return true;

            if (t1.X == null) { t1.Solve(); }
            if (t2.X == null) { t2.Solve(); }

            if (t1.X.Length != t2.X.Length) return false;

            if (t1.X[0] == t2.X[0])
            {
                if (t1.X.Length > 1)
                {
                    if (t1.X[1] == t2.X[1])
                        return true;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Uravnenie t1, Uravnenie t2)
        {
            return !(t1 == t2);
        }

        public override string ToString()
        {
            return $"{this.A}x^2 + {this.B}x + {this.C} = 0";
        }
    }
}