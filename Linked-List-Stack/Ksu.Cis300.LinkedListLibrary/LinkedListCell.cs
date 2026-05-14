namespace Ksu.Cis300.LinkedListLibrary
{
    public class LinkedListCell<T>
    {
        public T Data
        {
            get; set;
        }
        public LinkedListCell<T>? Next 
        {
            get; set;
        }

        public LinkedListCell (T data, LinkedListCell<T>? next)
        {
            Data = data;
            Next = next;
        }
    }
}
