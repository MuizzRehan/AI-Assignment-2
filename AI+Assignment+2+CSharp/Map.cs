using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Resources;
namespace AI_Assignment_2_CSharp
{
    
    class Map : IDisposable
    {
        private Node currentNode;
        private Node currentRow;
        private Node baseNode;
        private Node connector; //Helper for Bottom-Top Connection
        private int Rows;
        //Custom Use Nodes
        private Node startNode;
        private Node goalNode;
        private char WALL;
        private char WAY;
        public Map()
        {
            connector=  currentNode = currentRow = baseNode = null;
            Rows = 0;
            WALL = char.Parse(Properties.Resources.WALL.ToString());
            WAY = char.Parse(Properties.Resources.WAY.ToString());
        }
        public void Dispose()
        {
            currentNode.Dispose();
            currentRow.Dispose();
            baseNode.Dispose();
        }
        public void Display()
        {
            string printer = "";
            Stack<String> helper = new Stack<string>();
            for(Node i = baseNode; i != null;i=i.up)
            {
                string temp = null;
                for(Node j = i;j!=null;j=j.right)
                {
                    
                    temp+=( j.value.ToString() + "\t");
                }
                helper.Push(temp);
                helper.Push( "\r\n");
            }
            while(helper.Count > 0)
            {
                printer += helper.Pop();
            }
            Write(printer);
            
        }
        public void DepthFirstSearch()
        {
            if(startNode !=null && goalNode!=null)
            {
                
                RecursiveDepthFirstSearch(startNode);

            }
        }
        private bool RecursiveDepthFirstSearch(Node current)
        {
            try
            {
                if(startNode !=null && goalNode != null)
                {
                    
                    if(current == goalNode)
                    {
                        //We're are Goal so
                        
                        return true;
                    }
                    else
                    {
                        if(current.value==WAY)
                        {
                            
                            if (RecursiveDepthFirstSearch(current.right))
                            {
                                current.value = '*';
                            }
                            else
                            {
                                current.value = '.';
                            }
                            if (RecursiveDepthFirstSearch(current.up))
                            {
                                current.value = '*';
                            }
                            else
                            {
                                current.value = '.';
                            }
                        }else
                        {
                           
                            return false;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SetGoal(int row,int column)
        {
            try
            {
                
                
                    Node temp = baseNode;
                
                    for(int i=0;i<column;i++)
                    {
                        temp = temp.right;
                    }
                
                    for(int i=0;i<row;i++)
                    {
                        temp = temp.up;
                    }
                
                goalNode = temp;
                    return true;
                
            }
            catch(Exception e)
            {
                Console.Write("Exception at SetGoal"+e.Message);
                return false;
            }
        }
        public bool SetStart(int row,int column)
        {
            try
            {
               
                
                    Node temp = baseNode;
                    for (int i = 0; i < column; i++)
                    {
                        temp = temp.right;
                    }
                    for (int i = 0; i < row; i++)
                    {
                        temp = temp.up;
                    }
                    startNode = temp;
                    return true;
                
                
            }
            catch
            {
                return false;
            }
        }
        public bool AddNewRowNode(char value)
        {
            try
            {
                if (currentRow == null)
                {
                    AddNewNode(value);
                }
                else if(currentRow == baseNode)
                {
                    //Creating Second row
                    connector = currentRow;
                    currentRow.up = new Node(value);
                    currentNode = currentRow.up;
                    currentRow = currentRow.up;
                    connector = connector.right;

                }else
                {
                    //Valid from third row to onwards...
                    connector = currentRow;
                    currentRow.up = new Node(value);
                    currentNode = currentRow.up;
                    currentRow = currentRow.up;
                    connector = connector.right;
                }
                Rows++; //A New row is Added So ...
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddNewNode(char value)
        {
            try
            {
                {
                    if(baseNode == null)
                    {
                        //Its First Node
                        baseNode = new Node(value);
                        currentRow = baseNode;
                        currentNode = baseNode;
                        connector = currentRow; //For First Time/Row only
                    }
                    else if(baseNode != currentRow)
                    {
                        currentNode.right = new Node(value);
                        currentNode = currentNode.right;
                        connector.up = currentNode;
                        connector = connector.right;
                    }
                    else
                    {
                        currentNode.right = new Node(value);
                        currentNode = currentNode.right;
                        connector = connector.right;
                        
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
