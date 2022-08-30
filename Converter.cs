using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    /// <summary>
    /// Класс-преобразователь
    /// </summary>
    internal static class Converter
    {
        /// <summary>
        /// Преобразование массива. Группирует элементы входного массива строк по наборам символов.
        /// </summary>
        /// <param name="input">Массив строк</param>
        /// <returns>Преобразованный многомерный массив</returns>
        internal static string[][] Execute(string[] input)
        {
            var sortedBySymbols = GetSortedBySymbols(input);

            return ConvertToMultidimensionalArray(sortedBySymbols);
        }

        /// <summary>
        /// Возвращает словарь с ключем, отсортированным по алфавиту набором символов, и значением, массиву соответсвующих ключу слов
        /// </summary>
        /// <param name="input">Массив строк</param>
        /// <returns></returns>
        private static Dictionary<string, List<string>> GetSortedBySymbols(string[] input)
        {
            var dict = new Dictionary<string, List<string>>();

            foreach (var word in input)
            {
                var key = new string(UniqueQuickSort(word.ToLower().ToCharArray()));
                if (dict.TryGetValue(key, out List<string> value))
                {
                    value.Add(word);
                }
                else
                {
                    dict.Add(key, new List<string> { word });
                }
            }

            return dict;
        }

        /// <summary>
        /// Быстрая сортировка символов с исключением повторений
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Уникальные отсортированные символы</returns>
        private static char[] UniqueQuickSort(char[] input)
        {
            if (input.Length < 2)
                return input;

            char pivot = input[0];

            var less = new List<char>();
            foreach (var i in input[1..])
            {
                if (i < pivot)
                {
                    less.Add(i);
                }
            }

            var greather = new List<char>();
            foreach (var i in input[1..])
            {
                if (i > pivot)
                {
                    greather.Add(i);
                }
            }

            return UniqueQuickSort(less.ToArray()).Concat(new char[1] { pivot }).Concat(UniqueQuickSort(greather.ToArray())).ToArray();
        }

        /// <summary>
        /// Преобразование словаря в многомерный массив
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[][] ConvertToMultidimensionalArray(Dictionary<string, List<string>> input)
        {
            string[][] resultAsArray = new string[input.Count][];
            for (int i = 0; i < input.Count; i++)
            {
                resultAsArray[i] = input.ElementAt(i).Value.ToArray();
            }

            return resultAsArray;
        }
    }
}
