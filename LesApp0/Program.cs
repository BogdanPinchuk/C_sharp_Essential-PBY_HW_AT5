using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // для випадкових чисел
            Random rnd = new Random();

            // створення колекції для цілих чисел
            DynamicIntArray array = new DynamicIntArray();

            // внесення даних
            for (int i = 0; i <= 5; i++)
            {
                // створення масиву з випадковим розиміром
                int[] temp = new int[rnd.Next(1, 10)];

                // його заповнення випадковими елементнами
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = rnd.Next(sbyte.MinValue, sbyte.MaxValue);
                }

                // додавання даних в колекцію
                array.AddRange(temp);
            }

            // вивід результатів на екран
            Console.WriteLine(array.ToString());

            // корекція виведення
            array.TypeOutResult = DynamicIntArray.OutResult.first;

            // Вивід при іншому форматуванні
            Console.WriteLine("\n\t" + array.ToString());

            // інфо про масив
            ShowInfo(array);

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }

        private static void ShowInfo(DynamicIntArray array)
        {
            Console.WriteLine("\n\tCount: " + array.Count);
            Console.WriteLine("\tCapacity: " + array.Capacity);
        }
    }
}
