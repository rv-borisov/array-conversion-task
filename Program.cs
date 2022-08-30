using System;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Converter.Execute(new string[] { "ток", "рост", "кот", "торс", "Кто", "фывап", "рок" });

            foreach (var str in result)
            {
                foreach (var word in str)
                {
                    Console.Write($"{word} ");
                }
                Console.WriteLine();
            }
        }

        
    }
}
