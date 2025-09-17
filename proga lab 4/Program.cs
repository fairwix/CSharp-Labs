
public class Node<T> where T : class, IComparable<T> 
//ограничения в листике, гарантирует что тип T может сравниваться с другими объектами того же типа через метод CompareTo
{
    public T Data { get; }//значение
    public Node<T> Next { get; set; }//ссылка на следующий
    
    //конструктор для инициализации данных и ссылки на следующую
    public Node(T data, Node<T> next = null)
    {
        Data = data;
        Next = next;
    }
}

