using System.Text;

var raw = File.ReadAllLines("input.txt");
var splits = 0L;

long start = -1, space = -2, splitter = -3;

var input = raw.Select(i => i.Select(c =>
{
    switch (c)
    {
        case 'S':
            return start;
        case '.':
            return space;
        case '^':
            return splitter;
        default:
            throw new ArgumentOutOfRangeException(nameof(c), c, null);
    }
}).ToArray()).ToArray();

for (var y = 0; y < input.Length - 1; y++) // No need to process last row.
{
    for (var x = 0; x < input[y].Length; x++)
    {
        if (input[y][x] != space && input[y][x] != splitter)
        {
            var source = input[y][x] == start ? 1 : input[y][x];
            
            if (input[y + 1][x] == splitter)
            {
                if (input[y + 1][x - 1] == space)
                    input[y + 1][x - 1] = source;
                else
                    input[y + 1][x - 1] += source;
                
                
                if (input[y + 1][x + 1] == space)
                    input[y + 1][x + 1] = source;
                else
                    input[y + 1][x + 1] += source;
                
                splits++;
            }
            else if (input[y + 1][x] == space)
            {
                input[y + 1][x] = source;
            }
            else if (input[y + 1][x] > 0)
            {
                input[y + 1][x] += source;
            }
        }
    }
} 

for (var y = 0; y < input.Length; y++) // No need to process last row.
{
    for (var x = 0; x < input[y].Length; x++)
    {
       Console.Write(input[y][x] + " ");
    }
    
    Console.WriteLine();
} 



Console.WriteLine($"Splits: {splits}");
Console.WriteLine($"Timelines: {input[^1].Where(v => v > 0).Sum()}");