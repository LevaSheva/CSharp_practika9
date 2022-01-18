using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoryWork9
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine(":::::::::: Часть 1 ::::::::::\n");

            double a = ReadDouble("Введите коэффициент a: ");
            double b = ReadDouble("Введите коэффициент b: ");
            double c = ReadDouble("Введите коэффициент c: ");
            TestFunction(a, b, c);

            Console.WriteLine(":::::::::: Часть 2 ::::::::::\n");

            Console.WriteLine("Сравнение уравнений (==): {0}", new Uravnenie(1, 2, 3) == new Uravnenie(1, 2, 3));
            Console.WriteLine("Сравнение уравений (!=): {0}", new Uravnenie(1, 2, 3) != new Uravnenie(1, 2, 3));

            Uravnenie obj = new Uravnenie(a, b, c);
            Console.WriteLine($"Унарные операции (++): {obj} => {obj++}");
            Console.WriteLine($"Унарные операции (--): {obj} => {obj--}");

            Console.WriteLine(":::::::::: Часть 3 ::::::::::\n");

            UravnenieArray uarr = new UravnenieArray(10, false);
            uarr.Show();
            Console.WriteLine("Всего создано уравнений: {0}", Uravnenie.Count);
            Console.WriteLine("Всего в массиве: {0}", uarr.Size);
            Console.WriteLine($"Уравнение с самым большим по абсолютному значению корнем: {uarr.Max()}");
        }

        private static void TestFunction(double a = 6, double b = 0, double c = -1)
        {
            Uravnenie obj = new Uravnenie(a, b, c);
            Console.WriteLine($"Уравнение: {obj}");
            Console.WriteLine();
            Console.WriteLine(":::::::::Проверка метода экземпляра:::::::::");

            if (obj.Solve())
            {
                Console.WriteLine($"   x1 = {obj.X[0]}");
                if (obj.X.Length > 1) Console.WriteLine($"   x2 = {obj.X[1]}");
            }
            else
            {
                Console.WriteLine("--- Данное уравнение не имеет корней! ---");
            }
            Console.WriteLine();
            Console.WriteLine("::::::::::Проверка статического метода:::::::::");

            double[] X = Uravnenie.Solve(a, b, c);
            if (X != null && X.Length != 0)
            {
                Console.WriteLine($"   x1 = {X[0]}");
                if (X.Length > 1) Console.WriteLine($"   x2 = {X[1]}");
            }
            else
            {
                Console.WriteLine("--- Уравнение не имеет корней! ---");
            }
            Console.WriteLine();
            Console.WriteLine($"Всего создано {Uravnenie.Count} уравнений");
            var test = new Uravnenie(0, 0, 0);
            Console.WriteLine("Создание ещё одного уравнения...");
            Console.WriteLine($"Всего создано {Uravnenie.Count} уравнений");
        }

        public static double ReadDouble(string str, int min = -1, int max = -1)
        {
            int size;
            bool b;
            do
            {
                Console.Write(str);
                b = int.TryParse(Console.ReadLine(), out size);
                if (!b)
                {
                    Console.WriteLine("\nНекорректный ввод! Пожалуйста, повторите попытку!\n");
                }
                if ((min != -1 && size < min) || (max != -1 && max < size))
                {
                    Console.WriteLine($"\nОшибка: введённое значение не входит в диапазон допустимых значений [{min};{max}]! Повторите попытку!\n");
                    b = false;
                }
            }
            while (b == false);

            return size;
        }
    }
}


