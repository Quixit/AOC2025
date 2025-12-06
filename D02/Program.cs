using D02;

var input = File.ReadAllText( "input.txt").Split(',').Select(i => i.Split('-').Select(x => Convert.ToInt64(x))).Select(y  =>
{
    var array = y.ToArray();
    return new Tuple<long, long>(array[0], array[1]);
});
var evaluator = new Evaluator();

foreach (var item in input)
{
    evaluator.AddRange(item);
}

Console.WriteLine($"Invalid Sum: {evaluator.InvalidTotal}");
Console.WriteLine($"Extended Invalid Sum: {evaluator.ExtendedInvalidTotal}");
