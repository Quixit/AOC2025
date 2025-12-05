using D01;

var input = File.ReadAllLines("input.txt").Select(line => (line[0],Convert.ToInt32(line.Substring(1)))).ToArray();
var dial = new Dial();

foreach (var line in input)
{
    dial.Move(line.Item1, line.Item2);
}


Console.WriteLine($"Result: {dial.ZeroCount}");