namespace proga_lab_2;
public class Container
{
	private ColdCell[,] currentGrid;
	private ColdCell[,] nextGrid;

	private int n = 42; 

	//изначально заполняю все массивы холодными
	//а потом один массив отвечает за текущее состояние а другой за следующее
	public Container()
	{
		currentGrid = new ColdCell[n, n];
		nextGrid = new ColdCell[n, n];

		InitGrid();
		HotInit();
	}
	
	// метод Init который точечно заполняет горячими клетками те ячейки которые нужно по условию
	private void InitGrid()
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				currentGrid[i, j] = new ColdCell(i, j);
				nextGrid[i, j] = new ColdCell(i, j);
			}
		}
	}
	
	private void HotInit()
	{

	int[,] initialPositions = new int[,]
		{
			
			{ 17, 17 }, { 17, 18 }, { 18, 17 }, { 18, 18 },
			{ 17, 19 }, { 17, 20 }, { 18, 19 }, { 18, 20 },
			{ 19, 17 }, { 19, 18 }, { 20, 17 }, { 20, 18 },
			{ 19, 19 }, { 19, 20 }, { 20, 19 }, { 20, 20 }
			
		};

		for (int k = 0; k<initialPositions.GetLength(0); k++)
	{
		int x = initialPositions[k, 0];
		int y = initialPositions[k, 1];
		currentGrid[x, y] = new HotCell(x, y);
	}
}
	
	//этот метод в цикле пробегается по текущему массиву и высчитывает следующее состояние для каждой клетки
	public void Update()
	{
		ColdCell[,] current = currentGrid;
		for (int i = 1; i < n - 1; i++)
		{
			for (int j = 1; j < n - 1; j++)
			{
				nextGrid[i, j] = current[i, j].NextState(current);
			}
		}
		
		currentGrid = nextGrid;
		nextGrid = current;
	}
	
	public void PrintNew()
	{
		for (int i = 1; i < n-1; i++)
		{
			for (int j = 1; j < n-1; j++)
			{
				Console.Write(currentGrid[i, j].Print());
			}
			Console.WriteLine();
		}
		Console.WriteLine();
	}
}
