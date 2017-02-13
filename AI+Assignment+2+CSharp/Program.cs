using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AI_Assignment_2_CSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            Map a = new Map();
            a.AddNewNode('0');
            a.AddNewNode('1');
            a.AddNewNode('0');
            a.AddNewNode('1');
            a.AddNewRowNode('0');
            a.AddNewNode('0');
            a.AddNewNode('1');
            a.AddNewNode('1');
            a.AddNewRowNode('0');
            a.AddNewNode('0');
            a.AddNewNode('0');
            a.SetStart(0, 0);
            a.SetGoal(2, 2);
            a.BreathFirstSearch();
            a.Display();
            Console.Read();
        }
        
    }
}
