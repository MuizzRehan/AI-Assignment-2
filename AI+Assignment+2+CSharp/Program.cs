using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace AI_Assignment_2_CSharp
{
    class coods
    {
       public int x;
       public int y;
    }
    class Program
    {

        static void Main(string[] args)
        {
            Map map = new Map();
            coods start = new coods(), end = new coods();
            Console.WriteLine("Artificial Intelligence Assignment 2");
            Console.WriteLine("Type help for help");
            Console.WriteLine();
            if(args.Length == 1)
            {
                if (args[0].ToLower().Equals("help"))
                {
                    Console.WriteLine("Command Format : Run filepath/filename.txt [printInput | printResult]");
                    Console.WriteLine("Example Run C://Users/YourName/Destop/input.txt printResult");
                    Console.WriteLine();
                    Console.WriteLine("Type \"readme\" to See Read me Information");

                }else if (args[0].ToLower().Equals("readme"))
                {
                    Console.WriteLine("pending task");
                }else
                {
                    Console.WriteLine("The Term \""+args[0]+" \" is not recognized try help command");
                }
            }
            else if(args.Length > 2)
            {
                if(args[0].Equals("Run"))
                {
                    int rowSize = 0;

                    
                    StreamReader fileReader = new StreamReader(args[1]);
                    string line = fileReader.ReadLine();
                    rowSize = int.Parse(line.Split(' ')[1]);
                    int columnSize = int.Parse(line.Split(' ')[0]);
                    line = fileReader.ReadLine(); //Start Coods
                    string[] c = line.Split(' ');
                    start.x = int.Parse(c[0]);
                    start.y = int.Parse(c[1]);

                    line = fileReader.ReadLine();
                    c = line.Split(' ');
                    end.x = int.Parse(c[0]);
                    end.y = int.Parse(c[1]);
                    Stack<char> st = new Stack<char>();
                    for(int i=0;i<columnSize;i++)
                    {
                        line = fileReader.ReadLine();
                        c = line.Split(' ');
                        foreach(string ii in c)
                        {
                            st.Push(ii[0]);
                        }
                    }
                    for(int i=0;i<st.Count;i++)
                    {
                        if(i%rowSize == 0)
                        {
                            map.AddNewRowNode(st.Pop());
                        }else
                        {
                            map.AddNewNode(st.Pop());
                        }
                    }
                    if(args[2].Equals("printInput") || args[3].Equals("printInput"))
                    {
                        map.Display();
                    }
                    map.BreathFirstSearch();
                    if (args[2].Equals("printResult") || args[3].Equals("printResult"))
                    {
                        map.Display();
                    }

                }
                else
                {
                    Console.WriteLine("Try help command to get Help : Failed Execution of Command");
                }
            }else
            {
                Console.WriteLine("Try help command to get Help : Failed Execution of Command");
            }
            
        }
        
    }
}
