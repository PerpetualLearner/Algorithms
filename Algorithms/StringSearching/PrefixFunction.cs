using System;

namespace Algorithms.StringSearching
{
    public static class PrefixFunction
    {
        /// <summary>
        /// Префикс-функция.        
        /// </summary>
        /// <remarks>
        /// Вычисляет префикс-функцию грубой силой за время О(n^3). 
        /// Наихудший случай - строка из одинаковых символов - тогда префикс функция будет расти и внутренний цикл будет выполняться (длина префикса - 1) раз.
        /// Для строки aa -   1 сравнение.
        /// Для строки aaa -  4 сравнения.
        /// Для строки aaaa - 10 сравнений.
        /// Для строки aaaaa - 20 сравнений.
        /// Для строки aaaaaa - 35 сравнений.
        /// </remarks>
		/// <returns>
		/// Возвращает массив максимальных длин совпадающих суффикса и префикса для каждой подстроки исходной строки.
		/// </returns>
        public static int[] Naive(string text)
        {
	        // Счетчик кол-ва сравнений.
			var comparesCounter = 0;
			
			
			// Результаты значения префикс функции для каждого префикса строки.
            var resultArray = new int[text.Length];

            // Префикс-функция для строки из одного элемента по определению равна 0,
            // т.е. префикс не должен совпадать с самой строкой.
            resultArray[0] = 0;

            // Вычисляем значение префикс-функции для каждого префикса, начиная со второго, проходя по всем префиксам.
            // i на каждой итерации определяет длину(! не индекс) текущего префикса и соответственно сам префикс.
            for (int i = 2; i <= text.Length; i++)
            {
                int maxLength = 0;
                // Проходим по всем префиксам самого префикса (исключая собственный)!
                // j на каждой итерации определяет длину (! не индекс) префикса префикса.
                // j так же определяет суффикс префикса, т.к. мы знаем длину всего префикса.
                for (int j = 1; j < i; j++)
                {
                    bool isEqual = true;
                    // Сравниваем суффикс и префикс посимвольно, начиная с первого символа. 
                    for (int k = 0; k < j; k++)
                    {
	                    ++comparesCounter;
	                    if (text[k] != text[i - j + k])
	                    {
		                    isEqual = false;
							break;
	                    }
                    }
                    // Если префикс равен суффиксу, проверяем не самая ли это длинная пара из встреченных ранее?
                    if (isEqual && j > maxLength)
                        maxLength = j;
                }

				// Запоминаем вычисленное значение префикс фукнции.
                resultArray[i - 1] = maxLength;
            }
			Console.WriteLine("Кол-во сравнений: " + comparesCounter);
            return resultArray;
        }

		public static int Search(string pattern, string text)
		{
			var prefixes = Naive(pattern + "#" + text);

			for (int i = 0; i < prefixes.Length; i++)
			{
				if (prefixes[i] == pattern.Length)
				{
					return i - pattern.Length - pattern.Length;
				}
			}
			return -1;
		}
    }
}