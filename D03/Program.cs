// See https://aka.ms/new-console-template for more information

using D03;

var input = File.ReadAllLines("input.txt").Select(l => l.Select(s => Convert.ToInt64($"{s}")));
var calculator = new JoltageCalculator();

foreach (var bank in input)
{
    calculator.AddBank(new ArraySegment<long>(bank.ToArray()), 2);
}

Console.WriteLine($"Total Joltage: {calculator.Total}");