public class HotCell: ColdCell
{
    public HotCell(int x, int y) : base(x, y) { }
    
    public override int CurrentState()
    {
        return 1;
    }
    
    public override ColdCell NextState(ColdCell[,] grid)
    {
        int neighbors = CountN(grid);
        return (neighbors >= 4 && neighbors <= 8) ? this : new ColdCell(X, Y);
    }
    
    public override char Print()
    {
        //горячая
        return 'w';
    }
}

