using D04;

var input = File.ReadAllLines("input.txt").Select(l => l.Select(s => s == '@').ToArray()).ToArray();

var gridEvaluator = new GridEvaluator(input, false);

for (var x = 0; x < input.Length; x++)
{
    for (var y = 0; y < input[x].Length; y++)
    {
        gridEvaluator.Evaluate(x, y);
    }
}

Console.WriteLine($"Accessible roles: {gridEvaluator.Accessible}");

var removedTotal = 0L;

do
{
    gridEvaluator = new GridEvaluator(input, true);

    for (var x = 0; x < input.Length; x++)
    {
        for (var y = 0; y < input[x].Length; y++)
        {
            gridEvaluator.Evaluate(x, y);
        }
    }

    removedTotal += gridEvaluator.Accessible;

} while (gridEvaluator.Accessible > 0);

Console.WriteLine($"Accessible roles with removals: {removedTotal}");