//операции класса списка (List)
//void Add(T ob); добавляет значения ob в конец списка
//void Delete(T ob); удаляет из списка последнее вхождение значения ob
//void Print()//выводит список на экран
//void DeleteDuplicate(); удаляет из списка все повторяющиеся значения
//Класс значения хранит натуральное число.
//Тот из объектов класса больше, у которого больше число делителей,
//включая 1 и само число.
//Например, 32 больше 51, так как у 32 6 делителей ( 1 2 4 8 16 32), а у 51 только 4 ( 1 3 17 51)

public class Program
{
    public static void Main()
    {
        CustomList<Number> numberList = new CustomList<Number>();
        numberList.Add(new Number(32));
        numberList.Add(new Number(6));
        numberList.Add(new Number(51));
        numberList.Add(new Number(6));
        numberList.Add(new Number(4));
        numberList.Add(new Number(84));
        numberList.Add(new Number(84));
        numberList.Add(new Number(6));
        numberList.Add(new Number(84));

        Console.WriteLine("изначальный список");
        numberList.Print();

        Console.WriteLine("после удаления последнего вхождения значения ");
        numberList.Delete(new Number(84));
        numberList.Print();

        Console.WriteLine("после удаления дубликатов:");
        numberList.DeleteDuplicate();
        numberList.Print();
        
        CustomList<string> stringList = new CustomList<string>();
        stringList.Add("banana");
        stringList.Add("яблоко");
        stringList.Add("banana");
        stringList.Add("вишня");
        stringList.Add("яблоко");
        stringList.Add("яблоко");
        stringList.Add("вишня");

        Console.WriteLine("изначальный список");
        stringList.Print();

        Console.WriteLine("после удаления последнего вхождения 'яблоко'");
        stringList.Delete("яблоко");
        stringList.Print();

        Console.WriteLine("после удаления дубликатов");
        stringList.DeleteDuplicate();
        stringList.Print();
    }
}