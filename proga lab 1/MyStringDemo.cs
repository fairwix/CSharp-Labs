public class MyStringDemo
{
    static void Main(string[] args)
    {
        string input = "ababbabcaaababab";
        int pos = 7;
        int replaceIndex = 0;
        char newChar = 'h';
        int substrStart = 2;
        int substrEnd = 9;
        int deleteStart = 5;
        int deleteEnd = 7;
        string[] appends = { "123", "456", "789", "abc" };
        int insertPos = 3;
        string insertStr = "AAA";
        string replaceFrom = "ab";
        string replaceTo = "U";

      
        MyString myString = new MyString(input);
        Console.WriteLine("исходная строка:");
        myString.Print();

        Console.WriteLine($"\nсимвол на позиции {pos}: {myString.CharAt(pos)}");

        myString.SetCharAt(replaceIndex, newChar);
        Console.WriteLine("\nпосле замены символа:");
        myString.Print();

        MyString substring = myString.SubString(substrStart, substrEnd);
        Console.WriteLine("\nподстрока:");
        substring.Print();

        substring.DelString(deleteStart, deleteEnd);
        Console.WriteLine("\nпосле удаления части строки:");
        substring.Print();
        
        for (int i = 0; i < appends.Length; i++)
        {
            substring.Append(appends[i]);
        }
        Console.WriteLine("\nпосле добавления элементов:");
        substring.Print();

        substring.Insert(insertPos, insertStr);
        Console.WriteLine("\nпосле вставки строки:");
        substring.Print();

        MyString replaced = substring.Replace(replaceFrom, replaceTo);
        Console.WriteLine("\nпосле замены вхождений:");
        replaced.Print();
    }
}