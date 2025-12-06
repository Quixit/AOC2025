namespace D03;

public class JoltageCalculator(int values)
{
    public long Total { get; set; } = 0;
    
    public void AddBank(ArraySegment<long> bank)
    {
        var total = "";
        var slice = bank;
        
        for (var i = 1; i <= values; i++)
        {
            var highest = GetHighest(slice.Slice(0, slice.Count - values + i));
            total += highest.Joltage.ToString();
            
            if ((highest.Index + 1) < slice.Count)
                slice = slice.Slice(highest.Index + 1);
        }

        Console.WriteLine(total);
        
        Total += Convert.ToInt64(total);
    }

    public Battery GetHighest(ArraySegment<long> bank)
    {
        var highest = new Battery { Joltage = 0, Index = 0 };

        for (var i = 0; i < bank.Count; i++)
        {
            // We want the first value that's the highest available, to give us more options for value two.
            if (bank[i] > highest.Joltage)
            {
                highest = new Battery { Index = i, Joltage = bank[i] };
            }
        }

        return highest;
    }
}

public struct Battery
{
    public long Joltage { get; set; }
    public int Index { get; set; }
}