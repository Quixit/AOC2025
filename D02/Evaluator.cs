using System.ComponentModel;

namespace D02;

public class Evaluator
{
    public long InvalidTotal {
        get;
        set;
    }

    public void AddRange(Tuple<long,long> input)
    {
        var first = input.Item1;
        var last = input.Item2;

        Console.WriteLine($"Evaluating {first} to {last}");
        
        for (var i = first; i <= last; i++)
        {
            Add(i.ToString());
        }
    }

    private void Add(string input)
    {
        if (input.Length % 2 == 0)
        {
            if (input.Substring(0, input.Length / 2) == input.Substring(input.Length / 2))
            {
                Console.WriteLine($"{input} Is Invalid");
                InvalidTotal += Convert.ToInt64(input);
            }
        }

        // for (var chunk = 1; chunk <= input.Length / 2; chunk++)
        // {
        //     for (var start = 0; start <= input.Length - chunk * 2; start++)
        //     {
        //         var first = input.Substring(start, chunk);
        //         var second = input.Substring(start + chunk, chunk);
        //
        //         if (first == second)
        //         {
        //             Console.WriteLine($"  Found invalid chunk: {first} at position {start} of {input}");
        //             InvalidTotal += Convert.ToInt64(input);
        //             return;
        //         }
        //     }
        // }
    }
}