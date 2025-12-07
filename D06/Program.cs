var input = File.ReadAllLines("input.txt");

var updated = 1;

for (var i = 0; i < input.Length; i++)
{
    while (input[i].Contains("  "))
    {
        input[i] = input[i].Replace("  ", " ");
    }
}

var numbers = input[0..^1].Select(l => l.Trim().Split(' ').Select(s => long.Parse(s)).ToArray()).ToArray();
var operators = input[^1].Split(" ");

var sum = 0L;

for (var col = 0; col < numbers[0].Length; col++)
{
    var operation = numbers[0][col];

    for (var row = 1; row < numbers.Length; row++)
    {
        switch (operators[col])
        {
            case "+":
                operation += numbers[row][col];
                break;
            case "*":
                operation *= numbers[row][col];
                break;
            default:
                throw new Exception($"Operator {operators[col]} not implemented");
        }
    }
    
    sum += operation;
}

Console.WriteLine($"Sum: {sum}");