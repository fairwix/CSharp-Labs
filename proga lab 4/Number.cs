public class Number : IComparable<Number>
{
    public int Value { get; }

    public Number(int value) => Value = value;
    
    //метод для подсчета количества делителей числа
    private int CountDivisors()
    {
            if (Value == 1) 
                return 1;
    
            int count = 0;
            int sqrt = (int)Math.Sqrt(Value);

            for (int i = 1; i <= sqrt; i++)
            {
                if (Value % i == 0)
                {
                    count += 2;
                }
            }
            // коррекция для полных квадратов
            if (sqrt * sqrt == Value)
            {
                count--;
            }

            return count;
        
    }
    
    public int CompareTo(Number? other)
    {
        if (other is null) return 1;
        return (this.CountDivisors() - other.CountDivisors());
    }
    
    // Переопределение метода ToString
    public override string ToString() => Value.ToString();
    
}
