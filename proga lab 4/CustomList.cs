
public class CustomList<T> where T : class, IComparable<T>

{
    private Node<T> head;
    
    //метод добавления элемента в конец списка
    public void Add(T data)
    {
        if (head == null)  
        {
            head = new Node<T>(data);
            return;
        }
            Node<T> current = head;
            Node<T> previous = null; 
            while (current != null)
            {
                previous = current;
                current = current.Next;
            }
            previous.Next = new Node<T>(data); 
    }
    
    //метод для поиска последнего вхождения элемента 
    private Node<T> FindPrevOfLastOccurrence(T data)
    {
        Node<T> prevOfLast = null;
        Node<T> current = head;
        Node<T> prev = null;
    
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
            {
                prevOfLast = prev; 
            }
            prev = current;
            current = current.Next;
        }
        return prevOfLast;
    }
    
//метод для удаления последнего вхождения в списке
    public void Delete(T data)
    {
        Node<T> prevOfLast = FindPrevOfLastOccurrence(data);
        
        if (prevOfLast != null)
        {
                prevOfLast.Next = prevOfLast.Next.Next;
        }
       
        else if (head != null && head.Data.CompareTo(data) == 0)
        {
            head = head.Next;
        }
    }

    //метод для вывода списка
    public void Print()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
        Console.WriteLine();
    }
    
    //метод для удаления повторяющихся узлов
    public void DeleteDuplicate() 
    {
        Node<T> current = head; 
        while (current != null)
        {
            Node<T> search = current.Next; 
            Node<T> previous = current; 
            while (search != null)
            {
                if (search.Data.CompareTo(current.Data) == 0)
                {
                    previous.Next = search.Next;
                    search = search.Next;
                }
                else
                {
                    previous = search;
                    search = search.Next;
                }
            }
            current = current.Next;
        }
    }
}