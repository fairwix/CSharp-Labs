
//обобщенный делегат для фильтрации
public delegate bool FilterType<T>(Transaction t, T type); //будем использовать для лямбда выражения

//обобщенный делегат для сравнения(определяет порядок сортировки)
public delegate bool Compare(Transaction tr1, Transaction tr2);

//класс для представления финансовой транзакции
public class Transaction
{
    public double Amount { get; } 
    public DateOnly Date { get; } 
    public string Type { get; }

    public Transaction(double amount, DateOnly date, string type)
    {
        Amount = amount;
        Date = date;
        Type = type;
    }
    
    // переопределяет метод ToString() для представления объекта Product в виде строки.
    public override string ToString() => $"{Amount} {Date} {Type}";
    
  //метод для сортировки по неубывнию
  public static bool CompareAsc(Transaction tr1, Transaction tr2)
  {
      int cmpType = string.Compare(tr2.Type, tr1.Type);//сраниваем по типу
      if ( cmpType > 0)
          return true;
      if (cmpType == 0)
      { 
          int cmpAmount = tr1.Amount.CompareTo(tr2.Amount); 
          if (cmpAmount > 0)
              return true;
          if (cmpAmount == 0)
          {
              return tr1.Date > tr2.Date;
          }
      }
      return false;
  }
  
//аналогичный предыдущему
//для сравнения и сортировки по невозрастанию
  public static bool CompareDsc(Transaction tr1, Transaction tr2)
  {
      int cmpType = string.Compare(tr2.Type, tr1.Type);
      if ( cmpType > 0)
          return true;
      if (cmpType == 0)
      {
          int cmpAmount = tr1.Amount.CompareTo(tr2.Amount); 
          if (cmpAmount < 0)
              return true;
          if (cmpAmount == 0)
          {
              return tr1.Date < tr2.Date;
          }
      }
      return false;
  }
  
    //для обмена двух элементов в массиве
    public static void Swap(ref Transaction transaction1, ref Transaction transaction2) 
        => (transaction1, transaction2) = (transaction2, transaction1);
}
