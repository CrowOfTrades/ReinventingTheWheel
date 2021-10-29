namespace ReinventingTheWheel
{
    public class BaseList<T> where T : BaseItem
    {
        public T? First;

        public BaseList() { }

        public void AddFirst(T item)
        {
            if (First != null)
            {
                First.SetPrevious(item);
                item.SetNext(First);
            }
            First = item;
        }

        public void AddLast(T item)
        {
            if (First == null)
            {
                First = item;
            }
            else
            {
                T? last = GetLast();
                last.SetNext(item);
                item.SetPrevious(last);
            }
        }

        public void Show()
        {
            Console.WriteLine("Hello, World!");

            T? actual = First;
            WriteGenericProps(actual);

            while (actual is not null && actual?.GetNext() is not null)
            {                
                actual = actual?.GetNext() as T;
                WriteGenericProps(actual);
            }

            static void WriteGenericProps(T? item)
            {
                if (item is null) return;

                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.Name is not null)
                        Console.WriteLine($"{prop.Name}: {typeof(T).GetProperty(prop.Name).GetValue(item)}");
                }

            }  
        }

        private T? GetLast()
        {
            T? actual = First;

            while (actual is not null && actual?.GetNext() is not null)
            {
                actual = actual?.GetNext() as T;
            }

            return actual;
        }
    }


}
