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

//reduce overlapping ranges
var reducedFresh = new List<LongRange>();

foreach (var freshItem in fresh)
{
    var found = false;
    
    foreach (var reducedItem in reducedFresh)
    {
        if (freshItem.Start <= reducedItem.End  && freshItem.Start >= reducedItem.Start )
        {
            reducedItem.End =  freshItem.End;
            found = true;
        }
        
        if (freshItem.End  >= reducedItem.Start && freshItem.End <= reducedItem.End)
        {
            reducedItem.Start = freshItem.Start;
            found = true;
        }
    }

    if (!found)
    {
        reducedFresh.Add(freshItem);
    }
}

var fullTotal = 0L;

foreach (var reducedItem in reducedFresh)
{
    fullTotal += (reducedItem.End - reducedItem.Start + 1L);
}

Console.WriteLine($"Fresh Items: {total}");
Console.WriteLine($"Total Fresh: {fullTotal}");