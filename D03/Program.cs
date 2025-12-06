// See https://aka.ms/new-console-template for more information

using D03;

var input = File.ReadAllLines("input.txt").Select(l => l.Select(s => Convert.ToInt64($"{s}")));
var calculator = new JoltageCalculator(2);
var largeCalculator = new JoltageCalculator(12);

foreach (var bank in input)
{
    var bankArray = bank.ToArray();
    
    calculator.AddBank(new ArraySegment<long>(bankArray));
    largeCalculator.AddBank(new ArraySegment<long>(bankArray));
}

Console.WriteLine($"Total Joltage x2: {calculator.Total}");
Console.WriteLine($"Total Joltage x12: {largeCalculator.Total}");