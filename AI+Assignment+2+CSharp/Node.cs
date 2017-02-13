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
       public char value { get; set; }
       
       public Node up { get; set; }
       
       public Node right { get; set; }
        public Node()
        {
            value = default(char);
            up = null;
            right = null;
        }
        public Node(char value)
        {
            this.value = value;
            up = null;
            right = null;
        }

        public void Dispose()
        {
            value = default(char);
            GC.SuppressFinalize(true);
        }
        
    }
}
