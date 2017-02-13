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
        public static bool Compare(T first,int second)
        {
            if(first.GetType()==second.GetType())
            {
                int temp = int.Parse(first.ToString());
                if (temp == second)
                    return true;
                return false;
            }else
            {
                throw new Exception("Both Types Must be Same");
            }
        }
    }
}
