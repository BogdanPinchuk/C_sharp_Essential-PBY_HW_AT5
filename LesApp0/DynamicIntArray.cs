using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Динамічний масив цілих чисел (колекція)
    /// </summary>
    class DynamicIntArray
    {
        /// <summary>
        /// Вивід в консоль
        /// </summary>
        public enum OutResult
        {
            /// <summary>
            /// В рядок
            /// </summary>
            first,
            /// <summary>
            /// В колонку
            /// </summary>
            second
        }

        /// <summary>
        /// Масив цілих значень
        /// </summary>
        private int[] array = new int[4];

        /// <summary>
        /// Кількість елементів
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity
        {
            get { return array.Length; }
        }
        /// <summary>
        /// Тип виведення масиву в консоль
        /// </summary>
        public OutResult TypeOutResult { get; set; } = OutResult.second;

        public int this[int index]
        {
            get
            {
                try
                {
                    return array[index];
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                    return default;
                }
            }
            set
            {
                try
                {
                    array[index] = value;
                }
                catch (Exception)
                {
                    Show("\n\tВихід за межі масиву", ConsoleColor.Red);
                }
            }
        }

        /// <summary>
        /// Додавання елемнтів масивом
        /// </summary>
        /// <param name="value">Масив вхідних значень</param>
        public void AddRange(params int[] value)
        {
            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2) 
            #endregion

            // щоб даремно не виконувати лишні операції,
            // то краще перевірити чи щось було передано
            if (value.Length < 1)
            {
                return;
            }

            // зміна розмірів, якщо необхідно
            if (Count + value.Length == Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2)) + 1));
            }
            else if (Count + value.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, Math.Ceiling(Math.Log(Count + value.Length) / Math.Log(2))));
            }

            // присвоєння значень
            for (int i = 0; i < value.Length; i++)
            {
                array[Count] = value[i];
                Count++;
            }
        }

        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        /// <param name="value"></param>
        public void Add(int value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Зміна розміру масиву
        /// </summary>
        /// <param name="num">Необхідна кількість елементів масиву</param>
        private void Resize(int num)
        {
            // новий тимчасовий масив
            int[] mas = new int[num];
            // min, якщо прийдеться обрізати масив
            for (int i = 0; i < Math.Min(array.Length, num); i++)
            {
                mas[i] = array[i];
            }

            array = mas;
        }

        /// <summary>
        /// Відображення рядка в кольорі
        /// </summary>
        /// <param name="s">рядок</param>
        /// <param name="color">колір</param>
        private static void Show(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        /// <summary>
        /// Вивід в консоль
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();

            switch (TypeOutResult)
            {
                case OutResult.first:
                    for (int i = 0; i < Count; i++)
                    {
                        s.Append(array[i] + " ");
                    }
                    break;
                case OutResult.second:
                    for (int i = 0; i < Count; i++)
                    {
                        s.Append($"\n\tArr[{i}] - {array[i]}");
                    }
                    break;
            }

            return s.ToString();
        }
    }
}
