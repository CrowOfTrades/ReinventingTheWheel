namespace ReinventingTheWheel
{ 
    public abstract class BaseItem
    {
        public BaseItem? Previous;
        public BaseItem? Next;

        public BaseItem? GetPrevious()
        {
            return Previous;
        }

        public void SetPrevious(BaseItem item)
        {
            Previous = item;
        }

        public BaseItem? GetNext()
        {
            return Next;
        }

        public void SetNext(BaseItem item)
        {
            Next = item;
        }
    }
}
