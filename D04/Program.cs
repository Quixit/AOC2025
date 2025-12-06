using D04;

var input = File.ReadAllLines("input.txt").Select(l => l.Select(s => s == '@').ToArray()).ToArray();

var gridEvaluator = new GridEvaluator(input);

for (var x = 0; x < input.Length; x++)
{
    for (var y = 0; y < input[x].Length; y++)
    {
        gridEvaluator.Evaluate(x, y);
    }
}

Console.WriteLine($"Accessible roles: {gridEvaluator.Accessible}");