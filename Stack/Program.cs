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
            try
            {
                s.Pop();
            }
            catch
            {
                Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            }
        }

        public class Stack
        {
            public Stack(params string[] elements)
            {
                this.elements = new List<string>(elements.Length);
                foreach (var element in elements)
                {
                    this.elements.Add(element);
                    this.Size++;
                }
                this.Top = this.elements[^1];
            }

            public List<string> elements;
            public int Size;
            public string? Top;


            public void Add(string element)
            {
                this.elements.Add((element));
                this.Top = this.elements[^1];
                this.Size++;
            }

            public string? Pop()
            {
                if (Size == 0)
                {
                    throw new Exception("Стек пустой");
                }
                else
                {
                    this.elements.RemoveAt(this.Size - 1);
                    this.Size--;
                    if (Size == 0)
                    {
                        this.Top = null;
                    }
                    else
                    {
                        this.Top = this.elements[^1];
                    }

                    return this.Top;
                }
            }

            class StackItem
            {
                private string? top;
                public int? PreviousIndex;

                public string? Top
                {
                    get { return this.top; }

                    set { this.top = value; }
                }


            }
        }
    }
}
