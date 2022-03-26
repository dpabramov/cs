using System;

namespace _073_PascalCasing_CamelCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "   В лЕсу    ПосПела   бузинА";
            string pascalCasingInput = string.Empty;
            string camelCasingInput = string.Empty;

            string[] inputArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray[i].Length; j++)
                {
                    if (i == 0)
                    {
                        camelCasingInput += char.ToLower(inputArray[i][j]);
                        pascalCasingInput += char.ToUpper(inputArray[i][j]);
                    }
                    else if (j == 0)
                    {
                        camelCasingInput += char.ToUpper(inputArray[i][j]);
                        pascalCasingInput += char.ToUpper(inputArray[i][j]);
                    }
                    else
                    {
                        camelCasingInput += char.ToLower(inputArray[i][j]);
                        pascalCasingInput += char.ToLower(inputArray[i][j]);
                    } 
                }
            }
        }
    }
}
