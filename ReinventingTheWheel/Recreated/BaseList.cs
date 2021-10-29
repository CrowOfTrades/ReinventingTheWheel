namespace ReinventingTheWheel.Recreated
{
    public class BaseList<T>
    {
        private BaseListItem<T>? Initial;

        public BaseList() { }

        public void Show()
        {
            BaseListItem<T>? actual = Initial;
            WriteGenericProps(actual);

            while (actual is not null && actual?.GetNext() is not null)
            {
                actual = actual?.GetNext();
                WriteGenericProps(actual);
            }
        }

        #region First
        public T? FirstOrDefault() => First().GetValue();

        public void AddFirst(T item)
        {
            BaseListItem<T> listItem = new(item);
            if (Initial != null)
            {
                Initial.SetPrevious(listItem);

                listItem.SetNext(Initial);
            }
            Initial = listItem;
        }

        public void RemoveFirst()
        {
            Initial = Initial.GetNext();

            if (Initial is not null)
                Initial.SetPrevious(null);
        }

        #endregion First

        #region Last
        public T? LastOrDefault() => Last().GetValue();

        public void AddLast(T item)
        {
            BaseListItem<T> listItem = new(item);
            if (Initial == null)
            {
                Initial = listItem;
            }
            else
            {
                BaseListItem<T>? last = Last();
                last.SetNext(listItem);
                listItem.SetPrevious(last);
            }
        }

        public void RemoveLast()
        {
            if (Last().GetPrevious() is not null)
            {
                Last().GetPrevious().SetNext(null);
            }
            else
                Initial = null;
        }
        #endregion Last

        #region Index
        public void AddBefore(int index, T item)
        {
            BaseListItem<T>? indexItem = GetByIndex(index);
            BaseListItem<T>? beforeItem = indexItem.GetNext();

            BaseListItem<T> newItem = new(item);
            newItem.SetPrevious(beforeItem);
            newItem.SetNext(indexItem);

            indexItem.SetPrevious(newItem);
            beforeItem.SetNext(newItem);
        }

        public void AddAfter(int index, T item)
        {
            BaseListItem<T>? indexItem = GetByIndex(index);
            BaseListItem<T>? nextItem = indexItem.GetNext();

            BaseListItem<T> newItem = new(item);
            newItem.SetPrevious(indexItem);
            newItem.SetNext(nextItem);

            indexItem.SetNext(newItem);
            nextItem.SetPrevious(newItem);
        }

        public void Substitute(int index, T item)
        {
            BaseListItem<T>? indexItem = GetByIndex(index);
            indexItem.SetValue(item);
        }

        public T? Index(int index) => GetByIndex(index).GetValue();
        #endregion Index

        #region private methods
        private BaseListItem<T>? First()
        {
            return Initial;
        }

        private BaseListItem<T>? GetByIndex(int index)
        {
            int count = 0;
            BaseListItem<T>? actual = Initial;

            while (actual is not null && actual?.GetNext() is not null && count < index)
            {
                actual = actual?.GetNext();
                count++;
            }

            return actual;
        }

        private BaseListItem<T>? Last()
        {
            BaseListItem<T>? actual = Initial;

            while (actual is not null && actual?.GetNext() is not null)
            {
                actual = actual?.GetNext();
            }

            return actual;
        }

        private static void WriteGenericProps(BaseListItem<T>? item)
        {
            if (item is null) return;

            foreach (var prop in typeof(T).GetProperties())
            {
                if (prop.Name is not null)
                    Console.WriteLine($"{prop.Name}: {typeof(T).GetProperty(prop.Name).GetValue(item.GetValue())}");
            }
        }

        #endregion private methods
    }

    internal class BaseListItem<T>
    {
        private T? Value;
        private BaseListItem<T>? Previous;
        private BaseListItem<T>? Next;

        public BaseListItem(T item)
        {
            Value = item;
        }

        #region Value

        public T? GetValue()
        {
            return Value;
        }

        public void SetValue(T? value)
        {
            Value = value;
        }

        #endregion Value

        #region Previous
        public BaseListItem<T>? GetPrevious()
        {
            return Previous;
        }

        public void SetPrevious(BaseListItem<T>? item)
        {
            Previous = item;
        }

        #endregion Previous

        #region Next
        public BaseListItem<T>? GetNext()
        {
            return Next;
        }

        public void SetNext(BaseListItem<T>? item)
        {
            Next = item;
        }
        #endregion Next
    }
}
