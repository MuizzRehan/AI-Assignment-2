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
            a.AddNewNode(9);
            a.AddNewNode(9);
            a.AddNewNode(9);
            a.AddNewNode(9);
            a.AddNewRowNode(9);
            a.AddNewNode(9);
            a.AddNewNode(9);
            a.AddNewNode(9);
            a.AddNewRowNode(9);
            a.AddNewNode(9);
            a.SetStart(0, 0);
            a.SetGoal(0, 0);
            a.BreathFirstSearch(99);
            a.Display();
            Console.Read();
        }
    }
}
