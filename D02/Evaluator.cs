using System.ComponentModel;

namespace D02;

public class Evaluator
{
    public long InvalidTotal {
        get;
        set;
    }
    
    public long ExtendedInvalidTotal {
        get;
        set;
    }

    public void AddRange(Tuple<long,long> input)
    {
        var first = input.Item1;
        var last = input.Item2;

        //Console.WriteLine($"Evaluating {first} to {last}");
        
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
                //Console.WriteLine($"{input} Is Invalid");
                InvalidTotal += Convert.ToInt64(input);
            }
        }

        for (var chunkLen = 1; chunkLen <= input.Length / 2; chunkLen++)
        {
            if (input.Length % chunkLen == 0)
            {
                var chunk = input.Substring(0, chunkLen);

                var isInvalid = true;

                for (var i = chunkLen; i <= input.Length - chunkLen; i += chunkLen)
                {
                    if (chunk != input.Substring(i, chunkLen))
                        isInvalid = false;
                }

                if (isInvalid)
                {
                    //Console.WriteLine($"{input} Is Extended Invalid with chunk {chunk}");
                    ExtendedInvalidTotal += Convert.ToInt64(input);
                    return;
                }
            }
        }
    }
}