namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new Stack("a", "b", "c");
            // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();
            // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");

            s = new Stack("a", "b", "c");
            s.Merge(new Stack("1", "2", "3"));
            // в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            // в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
            Console.WriteLine($"size = {s2.Size}, Top = '{s2.Top}'");
        }
    }

    public class Stack
    {
        public Stack(params string[] elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        private StackItem? topElement;

        private int size;
        public int Size
        {
            get { return size; }
        }
        public string? Top
        {
            get
            {
                if (topElement == null)
                {
                    return null;
                } else
                {
                    return topElement.Element;
                }
            }
        }

        public void Add(string element)
        {
            topElement = new StackItem(element, topElement);
            size++;
        }

        public string Pop()
        {
            if (topElement == null)
            {
                throw new Exception("Стек пустой");
            }
            else
            {
                var popElement = topElement.Element;
                topElement = topElement.PreviousElement;
                size--;

                return popElement;
            }
        }

        public static Stack Concat(params Stack[] stacks)
        {
            var s = new Stack();
            foreach (var stack in stacks)
            {
                s.Merge(stack);
            }

            return s;
        }

        class StackItem
        {
            private string element;
            private StackItem? previousElement;

            public StackItem(string element, StackItem? previousElement)
            {
                this.element = element;
                this.previousElement = previousElement;
            }
            
            public string Element
            {
                get { return this.element; }
            }
            public StackItem? PreviousElement
            {
                get { return this.previousElement; }
            }
        }
    }

    public static class StackExtension
    {
        public static void Merge(this Stack s1, Stack s2)
        {
            int stackSize = s2.Size;
            for (int i = 0; i < stackSize; i++)
            {
                s1.Add(s2.Pop());
            }
        }
    }
}
