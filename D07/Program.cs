using System.Text;

var raw = File.ReadAllLines("input.txt");
var splits = 0L;

var input = raw.Select(i => new StringBuilder(i)).ToArray();

for (var y = 0; y < input.Length - 1; y++) // No need to process last row.
{
    for (var x = 0; x < input[y].Length; x++)
    {
        if (input[y][x] == '|' || input[y][x] == 'S')
        {
            if (input[y + 1][x] == '^')
            {
                input[y + 1][x-1] = '|';
                input[y + 1][x+1] = '|';
                
                splits++;
            }
            else if (input[y + 1][x] == '.')
            {
                input[y + 1][x] = '|';
            }
            else if (input[y + 1][x] == '|')
            {
                //Don't need to do anything.
            }
            else
            {
                throw new Exception("Unexpected input!");
            }
        }
    }
} 

Console.WriteLine($"Splits: {splits}");