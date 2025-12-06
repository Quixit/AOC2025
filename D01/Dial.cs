namespace D01;

public class Dial
{
    public int Value { get; set; } = 50;
    
    public int ZeroCount { get; set; } = 0;

    public int HitZero { get; set; } = 0;

    public void Move(char direction, int magnitude)
    {
        var add = 0;
        var start = Value;

        while (magnitude > 100)
        {
            magnitude -= 100;

            HitZero++;
        }
        
        switch (direction)
        {
            case 'L':
                add -= magnitude;
                break;
            case 'R':
                add += magnitude;
                break;
            default:
                throw new NotSupportedException("Bad direction.");
        }
        
        Value += add;

        if (Value < 0)
        {
            Value += 100;

            if (start != 0)
                HitZero++;
        }
        else if (Value > 99)
        {
            Value -= 100;
            
            if (Value != 0)
                HitZero++;
   
        }

        if (Value == 0)
        {
            ZeroCount++;

            HitZero++;
        }
    }
}