using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int A = int.Parse(Console.ReadLine());
            int B = int.Parse(Console.ReadLine());
            int C = int.Parse(Console.ReadLine());

            int sum = 0;
            int count = 0;

            if(A % 2 == 0)
            {
                count++;
                sum += A;
            }

            if (B % 2 == 0)
            {
                count++;
                sum += B;
            }


            if (C % 2 == 0)
            {
                count++;
                sum += C;
            }

            Console.WriteLine("Количество четных чисел: " + count);
            Console.WriteLine("Сумма четных чисел: " + sum);

            Console.ReadKey();
        }
    }
}
