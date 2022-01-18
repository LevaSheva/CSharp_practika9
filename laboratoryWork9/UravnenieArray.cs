using System;
using System.Collections.Generic;

namespace laboratoryWork9
{
    internal class UravnenieArray
    {
        List<Uravnenie> arr;
        public int Size { get; private set; }
    
        public UravnenieArray()
        {
            arr = new List<Uravnenie>();
            Size = 0;
        }

        public UravnenieArray(int size, bool random = true)
        {
            arr = new List<Uravnenie>();
            this.Size = 0;

            if (random)
            {
                RandomFill(size);
            }
            else
            {
                ManualFill(size);
            }
        }

        private void ManualFill(int size)
        {
            double a, b, c;
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"[{i + 1}/{size}] Добавляем новое уравнение: ");
                a = Program.ReadDouble("Введите коэффициент a: ");
                b = Program.ReadDouble("Введите коэффициент b: ");
                c = Program.ReadDouble("Введите коэффициент c: ");
                arr.Add(new Uravnenie(a, b, c));
                this.Size++;
            }
        }

        private void RandomFill(int size)
        {
            var rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                arr.Add(new Uravnenie(rnd.Next(-10, 11), rnd.Next(-10, 11), rnd.Next(-10, 11)));
                this.Size++;
            }
        }

        public void Show()
        {
            int i = 1;
            foreach (var e in this.arr)
            {
                Console.WriteLine($"{i}. {e}");
                i++;
            }
        }

        public override string ToString()
        {
            int i = 1;
            foreach (var e in this.arr)
            {
                Console.WriteLine($"{i}. {e}");
                i++;
            }
            return "";
        }

        public Uravnenie Max()
        {
            Uravnenie u = null;
            foreach (var e in this.arr)
            {
                if (u == null) { u = e; }

                if (e.Solve())
                {
                    if (Math.Abs(e.X[0]) > Math.Abs(u.X[0]))
                    {
                        u = e;
                    }

                    if (u.X.Length > 1 && u.X.Length > 1)
                    {
                        if (Math.Abs(e.X[1]) > Math.Abs(u.X[1]))
                        {
                            u = e;
                        }
                    }
                }
            }
            return u;
        }
    }
}