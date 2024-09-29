using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Введите верхнюю границу простых чисел:");
        int upperLimit = int.Parse(Console.ReadLine());

        List<int> primes = await GeneratePrimesAsync(upperLimit);

        Console.WriteLine($"Найдено {primes.Count} простых чисел.");
        Console.WriteLine("Первые 10 простых чисел:");

        for (int i = 0; i < Math.Min(10, primes.Count); i++)
        {
            Console.WriteLine(primes[i]);
        }
    }

    static async Task<List<int>> GeneratePrimesAsync(int upperLimit)
    {
        return await Task.Run(() =>
        {
            List<int> primes = new List<int>();
            for (int i = 2; i <= upperLimit; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        });
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
