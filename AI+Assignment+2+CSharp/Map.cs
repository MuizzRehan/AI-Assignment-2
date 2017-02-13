using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AI_Assignment_2_CSharp
{
    class Map<T> : IDisposable
    {
        private Node<T> currentNode;
        private Node<T> currentRow;
        private Node<T> baseNode;
        private Node<T> connector; //Helper for Bottom-Top Connection
        private int Rows;
        //Custom Use Nodes
        private Node<T> startNode;
        private Node<T> goalNode;
        public Map()
        {
            connector=  currentNode = currentRow = baseNode = null;
            Rows = 0;
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
            for(Node<T> i = baseNode; i != null;i=i.up)
            {
                string temp = null;
                for(Node<T> j = i;j!=null;j=j.right)
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
        public bool SetGoal(int row,int column)
        {
            if (Rows - row > 0) //Validating Column Value
            {
                int col = Rows - row;
                Node<T> temp = baseNode;
                for (int i = 0; i < col; i++)
                {
                    temp = temp.up;
                }
                //We reached at appropiate row, Now struggling for Column
                for (int i = 0; i < column; i++)
                {
                    if (temp.right != null)
                        temp = temp.right;
                }
                //All Done , Just Set it as Start Position;
                goalNode = temp;
                return true;
            }
            return false;
        }
        public bool SetStart(int row,int column)
        {
            if(Rows-row > 0) //Validating Column Value
            {
                int col = Rows - row;
                Node<T> temp = baseNode;
                for(int i=0;i<col;i++)
                {
                    temp = temp.up;
                }
                //We reached at appropiate row, Now struggling for Column
                for(int i = 0; i < column; i++)
                {
                    if (temp.right != null)
                        temp = temp.right;
                }
                //All Done , Just Set it as Start Position;
                startNode = temp;
                return true;
            }
            return false;
        }
        public bool AddNewRowNode(T value)
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
                    currentRow.up = new Node<T>(value);
                    currentNode = currentRow.up;
                    currentRow = currentRow.up;
                    connector = connector.right;

                }else
                {
                    //Valid from third row to onwards...
                    connector = currentRow;
                    currentRow.up = new Node<T>(value);
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
        public bool AddNewNode(T value)
        {
            try
            {
                {
                    if(baseNode == null)
                    {
                        //Its First Node
                        baseNode = new Node<T>(value);
                        currentRow = baseNode;
                        currentNode = baseNode;
                        connector = currentRow; //For First Time/Row only
                    }
                    else if(baseNode != currentRow)
                    {
                        currentNode.right = new Node<T>(value);
                        currentNode = currentNode.right;
                        connector.up = currentNode;
                        connector = connector.right;
                    }
                    else
                    {
                        currentNode.right = new Node<T>(value);
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
