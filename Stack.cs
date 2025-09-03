namespace DataStructure
{
    public class Stack<T>
    {
        private System.Collections.Generic.LinkedList<T> data = new System.Collections.Generic.LinkedList<T>();
        public Stack() { }
        public void Push(T item)
        {
            data.AddFirst(item);
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
                return default;
            var firstItem = data.First();
            data.RemoveFirst();
            return firstItem;
        }

        public T? Peek()
        {
            return data.First();
        }

        public int Count()
        {
            return data.Count;
        }
    }
}
