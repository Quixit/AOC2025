using System.Reflection;

namespace D04;

public class GridEvaluator(bool[][] grid, bool allowRemove)
{
    public long Accessible
    {
        get;
        set;
    } = 0;

    private int _maxX = grid.Length - 1;
    private int _maxY = grid[0].Length - 1;

    public void Evaluate(int x, int y)
    {
        //No roll at coordinates.
        if (!grid[x][y])
            return;

        var count = 0;
        
        count += CheckUpLeft(x, y);
        count += CheckUp(x, y);
        count += CheckUpRight(x, y);
        
        count += CheckLeft(x, y);
        count += CheckRight(x, y);
        
        count += CheckDownLeft(x, y);
        count += CheckDown(x, y);
        count += CheckDownRight(x, y);

        if (count < 4)
        {
            Accessible++;
            
            if (allowRemove)
                grid[x][y] = false;
        }
    }

    public int CheckUpLeft(int x, int y)
    {
        if (x == 0 || y == 0)
            return 0;

        return grid[x - 1][y - 1] ? 1: 0;
    }
    
    public int CheckUp(int x, int y)
    {
        if (y == 0)
            return 0;

        return grid[x][y - 1] ? 1: 0;
    }
    
    public int CheckUpRight(int x, int y)
    {
        if (x == _maxX || y == 0)
            return 0;

        return grid[x + 1][y - 1] ? 1: 0;
    }
    
    public int CheckLeft(int x, int y)
    {
        if (x == 0)
            return 0;

        return grid[x - 1][y] ? 1: 0;
    }
    
    public int CheckRight(int x, int y)
    {
        if (x == _maxX)
            return 0;

        return grid[x + 1][y] ? 1: 0;
    }
    
    public int CheckDownLeft(int x, int y)
    {
        if (x == 0 || y == _maxY)
            return 0;

        return grid[x - 1][y + 1] ? 1: 0;
    }
    
    public int CheckDown(int x, int y)
    {
        if (y == _maxY)
            return 0;

        return grid[x][y + 1] ? 1: 0;
    }
    
    public int CheckDownRight(int x, int y)
    {
        if (x == _maxX || y == _maxY)
            return 0;

        return grid[x + 1][y + 1] ? 1: 0;
    }
}