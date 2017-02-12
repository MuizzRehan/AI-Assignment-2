using System;

namespace AI_Assignment_2_CSharp
{
    class Node<T> : IDisposable
    {
      
       public T value { get; set; }
       
       public Node<T> up { get; set; }
       
       public Node<T> right { get; set; }
        public Node()
        {
            value = default(T);
            up = null;
            right = null;
        }
        public Node(T value)
        {
            this.value = value;
            up = null;
            right = null;
        }

        public void Dispose()
        {
            value = default(T);
            GC.SuppressFinalize(true);
        }
    }
}
