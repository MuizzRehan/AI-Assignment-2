using System;
using System.ComponentModel;
namespace AI_Assignment_2_CSharp
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Node : IDisposable
    {
       [DefaultValue(99)]
       public int value { get; set; }
       
       public Node up { get; set; }
       
       public Node right { get; set; }
        public Node()
        {
            value = default(int);
            up = null;
            right = null;
        }
        public Node(int value)
        {
            this.value = value;
            up = null;
            right = null;
        }

        public void Dispose()
        {
            value = default(int);
            GC.SuppressFinalize(true);
        }
        
    }
}
