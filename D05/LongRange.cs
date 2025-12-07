namespace D05;

public class LongRange : IComparable<LongRange>
{
    public LongRange(long start, long end)
    {
        Start = start;
        End = end;
    }

    public long Start {  get; set; }
    public long End {  get; set; }

    public int CompareTo(LongRange? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return Start.CompareTo(other.Start);
    }
}