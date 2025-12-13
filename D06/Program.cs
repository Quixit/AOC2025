var raw = File.ReadAllLines("input.txt");
var input = raw.Clone() as string[];

for (var i = 0; i < input.Length; i++)
{
    while (input[i].Contains("  "))
    {
        input[i] = input[i].Replace("  ", " ");
    }
}

var numbers = input[0..^1].Select(l => l.Trim().Split(' ').Select(s => long.Parse(s)).ToArray()).ToArray();
var operators = input[^1].Split(" ");

Console.WriteLine($"Sum: {GetSum(numbers)}");

var numberGrid = raw[0..^1];
var cephalapodNumbers = new List<long[]>();
var currentValues = new List<long>();

for (var x = 0; x < numberGrid[0].Length; x++)
{
   
    var allSpace = true;
    
    var numberString = "";
    
    for (var y = 0; y < numberGrid.Length; y++)
    {
        if (numberGrid[y][x] != ' ')
        {   
            allSpace = false;
            
            numberString += numberGrid[y][x];
        }
    }

    if (allSpace)
    {
        cephalapodNumbers.Add(currentValues.ToArray());
        currentValues = new List<long>();
    }
    else
    {
        currentValues.Add(long.Parse(numberString.Trim()));
    }
}

cephalapodNumbers.Add(currentValues.ToArray());

Console.WriteLine($"Cephalopod Sum: {GetCephalopodSum(cephalapodNumbers.ToArray())}");

long GetSum(long[][] values) {
    var sum = 0L;

    for (var col = 0; col < values[0].Length; col++)
    {
        var operation = values[0][col];

        for (var row = 1; row < values.Length; row++)
        {
            switch (operators[col])
            {
                case "+":
                    operation += values[row][col];
                    break;
                case "*":
                    operation *= values[row][col];
                    break;
                default:
                    throw new Exception($"Operator {operators[col]} not implemented");
            }
        }
    
        sum += operation;
    }

    return sum;
}

long GetCephalopodSum(long[][] values) {
    var sum = 0L;

    for (var row = 0; row < values.Length; row++)
    {
        var operation = values[row][0];

        for (var col = 1; col < values[row].Length; col++)
        {
            switch (operators[row])
            {
                case "+":
                    operation += values[row][col];
                    break;
                case "*":
                    operation *= values[row][col];
                    break;
                default:
                    throw new Exception($"Operator {operators[col]} not implemented");
            }
        }
    
        sum += operation;
    }

    return sum;
}