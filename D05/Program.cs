// See https://aka.ms/new-console-template for more information

using D05;

var input = File.ReadAllLines("input.txt");
var fresh = new List<LongRange>();
var items = new List<long>();

foreach (var line in input)
{
    if (line.Contains('-'))
    {
        var split = line.Split('-');
        fresh.Add(new LongRange(long.Parse(split[0]), long.Parse(split[1])));
    }
    else if (line.Length > 0)
    {
        items.Add(long.Parse(line));
    }
}

var total = 0;

foreach (var item in items)
{
    foreach (var freshItem in fresh)
    {
        if (freshItem.Start <= item && freshItem.End >= item)
        {
            //Fresh
            total++;
            break;
        }
    }
}

fresh.Sort();

var last = fresh.First();
var fullTotal = 1 + last.End - last.Start;

for (var i = 1; i < fresh.Count; i++)
{
    var distance = 0L;
    
    if (last.End >= fresh[i].Start)
    {
        distance = fresh[i].End - last.End; //Space not accounted for only. 
    }
    else
    {
        distance = 1 + fresh[i].End - fresh[i].Start; //No overlap.
    }

    // It is theoretically possible that set 2 is shorter than set 1. In which case we ignore it.
    if (distance > 0)
    {
        fullTotal += distance;
        last = fresh[i];
    }
}

Console.WriteLine($"Fresh Items: {total}");
Console.WriteLine($"Total Fresh: {fullTotal}");