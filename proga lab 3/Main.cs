//Создайте класс Transaction для представления финансовой транзакции с полями (расход/доход), суммой и датой
//Напишите класс FinanceManager, который будет содержать помимо массива транзакций методы:
//для добавления транзакций в конец массива, нахождения сумм доходов и расходов с использованием ссылок на методы
//упорядочивания транзакций по различным полям с использованием ссылок на методы,
//а также фильтрации по различным критериям с использованием лямбда-выражений
//в методе Main добавьте несколько транзакций, примените упорядочивание,
//суммирование и фильтрацию и выведите результаты на экран
//Упорядочивание должно выполняться без создания нового объекта FinanceManager методом простого обмена
//по неубыванию и по невозрастанию по суммам(по датам, в случае совпадения сумм) сначала доходы потом расходы
//При фильтрации создаются новые объекты FinanceManager, критерии отбора: доход или расход,
//расходы и доходы вместе позже заданной даты

class Program
{
    static void Main()
    {
        FinanceManager manager = new FinanceManager();
        
        manager.AddTransaction(new Transaction(100, new DateOnly(2025, 10, 3), "Expense"));
        manager.AddTransaction(new Transaction(200, new DateOnly(2025, 10, 2), "Income"));
        manager.AddTransaction(new Transaction(150, new DateOnly(2024, 10, 1), "Income"));
        manager.AddTransaction(new Transaction(200, new DateOnly(2024, 10, 2), "Expense"));
        manager.AddTransaction(new Transaction(300, new DateOnly(2023, 10, 4), "Income"));
        manager.AddTransaction(new Transaction(200, new DateOnly(2023, 10, 5), "Income"));

        Console.WriteLine("исходные транзакции:");
        manager.Print();
        
        Console.WriteLine("\nсортировка по неубыванию суммы (сначала доходы):");
        manager.Sort(Transaction.CompareAsc);
        manager.Print();
        
        Console.WriteLine("\nсортировка по невозрастанию суммы (сначала доходы):");
        manager.Sort(Transaction.CompareDsc);
        manager.Print();
        
        double totalIncome = manager.Sum("Income"); 
        double totalExpense = manager.Sum("Expense"); 

        Console.WriteLine($"\nобщая сумма доходов: {totalIncome}");
        Console.WriteLine($"общая сумма расходов: {totalExpense}");
        
        FinanceManager incomeOnly = manager.FilterType("Income", (transaction, type) => transaction.Type == type);

        Console.WriteLine("\nтолько доходы:");
        incomeOnly.Print();
        
        DateOnly cutoffDate = new DateOnly(2024, 10, 2); 
        FinanceManager afterDate = manager.FilterType(cutoffDate, (transaction, date) => transaction.Date > date);

        Console.WriteLine($"\nтранзакции после {cutoffDate:yyyy-MM-dd}:");
        afterDate.Print();
        
        FinanceManager incomeAfterDate = manager.FilterType(cutoffDate, (transaction, date) => transaction.Type == "Income" && transaction.Date > date);

        Console.WriteLine($"\nдоходы после {cutoffDate:yyyy-MM-dd}:");
        incomeAfterDate.Print();
    }
}