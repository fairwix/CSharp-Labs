
using System.Runtime.Intrinsics.X86;

public class FinanceManager
{
    private Transaction[] transactions;
    private int tranCount = 0;
    private int maxtran = 100;
    
    public FinanceManager()
    {
        transactions = new Transaction[maxtran];
    }
    
    //метод добавления транзакций в конец массива
    public void AddTransaction(Transaction transaction)
    {
            transactions[tranCount] = transaction;
            tranCount++;
    }
    
    
    //метод вычисления суммы транзакций, удовлетворяющих условию
    
    //можно переделать через делегат
    public double Sum(string type)
    //по  доходу или по расходу
    {
        double total = 0;
        for (int i = 0; i < tranCount; i++)
        {
            if (transactions[i].Type == type)
            {
                total += transactions[i].Amount;
            }
        }
        return total;
    }

    //сортировка
    public void Sort(Compare cmp)
    {
        for (int i = 0; i < tranCount - 1; i++)
        {
            for (int j = 0; j < tranCount - 1 - i; j++)
            {
                if (cmp(transactions[j], transactions[j + 1]))
                {
                    Transaction.Swap( ref transactions[j], ref transactions[j + 1]);
                }
            }
        }
    }
    
    //фильтр
    //с помощью обобщенного делегата
    public FinanceManager FilterType<T>(T type, FilterType<T> f) 
    {
        FinanceManager financeManager = new FinanceManager();
        int newCnt = 0;
        for (int i = 0; i < tranCount; i++)
            if ( f(transactions[i], type))
                financeManager.AddTransaction(transactions[i]);
        return financeManager;
    }
    
    //метод для вывода
    public void Print()
    {
        if (tranCount == 0)
        {
            Console.WriteLine("Нет транзакций для отображения");
            return;
        }
        Console.WriteLine("Дата       | Тип     | Сумма ");
        Console.WriteLine("----------------------------");
        
        for (int i = 0; i < tranCount; i++)
        {
            Transaction t = transactions[i];
            Console.WriteLine($"{t.Date:yyyy-MM-dd} | {t.Type,-7} | {t.Amount,6}");
        }
    }
}
