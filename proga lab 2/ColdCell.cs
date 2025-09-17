
//класс холодной клетки
public class ColdCell
{
	protected int X;

	protected int Y;

	public ColdCell(int x, int y)
	{
		X = x;
		Y = y;
	}
	
	//метод для вычисления текущего состояния клетки
	public virtual int CurrentState()
	{
		// всегда возвращает 0 в холодной клетке
		return 0;
	}
	
	//метод который вычисляет количество нагретых соседей 
	//возвращает количество нагретых соседей
	protected int CountN(ColdCell[,] grid)
	{
		int count = 0;
		for (int dx = -1; dx <= 1; dx++)
		{
			for (int dy = -1; dy <= 1; dy++)
			{
				
				int nx = X + dx;
				int ny = Y + dy;
				//ОТВРАТИТЕЛЬНО НАПИСАНО ПЕРЕПИСАТЬ 
				//НЕ НУЖНА ПРОВЕРКА
					// используем CurrentState(), чтобы определить состояние соседней клетки
					if (grid[nx, ny].CurrentState() == 1)
					{
						count++;
					}
				
			}
		}
        // пропускаем текущую клетку
		if (grid[X, Y].CurrentState() == 1)
		{
			count -= 1;
		}
		return count;
		//организовываем цикл
		//этот метод принимает на вход только пластину
		//и получается x y хранятся как поля у меня в классе
		//просто суммирую все состояния от всех координат вокруг x y кроме самой клетки
		//суммирую с помощью метода CurrentState
		//CurrentState вызывается при подсчете горячих соседей
	}
	
	//метод который отвечает за следующее состояние клетки
	//этот метод смотрит по условию
	public virtual ColdCell NextState(ColdCell[,] grid)
	{
		int neighbors = CountN(grid);
			return neighbors == 2  ? new HotCell(X, Y) : this; 
	}
	
	public virtual char Print()
	{
		return '.';
	}
}