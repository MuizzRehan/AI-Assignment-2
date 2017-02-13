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
            Map<int> a = new Map<int>();
            a.AddNewNode(1);
            a.AddNewNode(2);
            a.AddNewNode(3);
            a.AddNewNode(4);
            a.AddNewRowNode(5);
            a.AddNewNode(6);
            a.AddNewNode(7);
            a.AddNewNode(8);
            a.AddNewRowNode(9);
            a.AddNewNode(10);
            a.SetStart(0, 0);
            a.SetGoal(1, 0);
            a.BreathFirstSearch(99);
            a.Display();
            Console.Read();
        }
    }
}
