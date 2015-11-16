using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ShortestPathInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            Cell[,] matrix = new Cell[rows, cols];
            Cell[] graph = new Cell[rows*cols];
            FillTheMatrix(matrix);
            BuildGraph(matrix, graph);

            PriorityQueue<Cell> queue = new PriorityQueue<Cell>();
            graph[0].Visited = true;
            queue.Enqueue(graph[0]);

            while (queue.Count>0)
            {
                var currentCell = queue.Dequeue();
                foreach (var neighbour in currentCell.Neighbours)
                {
                    var newValue = currentCell.Value + neighbour.InitialValue;
                    if (!neighbour.Visited)
                    {
                        neighbour.Value = newValue;
                        neighbour.Visited = true;
                        neighbour.Previuose = currentCell;
                        queue.Enqueue(neighbour);
                    }
                    else
                    {                        
                        if (newValue<neighbour.Value)
                        {
                            neighbour.Value = newValue;
                            neighbour.Previuose = currentCell;
                        }
                    }
                }
            }

            PrintOutput(graph);
        }

        private static void PrintOutput(Cell[] graph)
        {
            Console.WriteLine($"Length: {graph[graph.Length-1].Value}");
            List<int> path = new List<int>();
            var current = graph[graph.Length - 1];
            while (true)
            {              
                if (current==null)
                {
                    break;
                }
                var value = current.InitialValue;
                path.Add(value);
                current = current.Previuose;               
            }

            path.Reverse();
            Console.WriteLine($"Path: {string.Join(" ", path)}");
        }

        private static void BuildGraph(Cell[,] matrix, Cell[] graph)
        {
            int counter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    List<Cell> validNeghbours = FindValidNeghbours(row, col, matrix);
                    graph[counter] = matrix[row, col];
                    graph[counter].Neighbours = validNeghbours;
                    counter++;
                }
            }
        }

        private static List<Cell> FindValidNeghbours(int row, int col, Cell[,] matrix)
        {
            List<Cell> validCells = new List<Cell>();
            if (row-1>=0)
            {
                validCells.Add(matrix[row-1, col]);
            }
            if (col-1>=0)
            {
                validCells.Add(matrix[row, col-1]);
            }
            if (row+1<matrix.GetLength(0))
            {
                validCells.Add(matrix[row+1, col]);
            }
            if (col+1<matrix.GetLength(1))
            {
                validCells.Add(matrix[row, col+1]);
            }

            return validCells;
        }

        private static void FillTheMatrix(Cell[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Cell current = new Cell(i, j, currentRow[j], currentRow[j]);
                    matrix[i, j] = current;
                }
            }
        }
    }

    internal class Cell:IComparable
    {
        public Cell(int row, int col, int value, int initialValue)
        {
            InitialValue = initialValue;
            this.Row = row;
            this.Col = col;
            this.Value = value;
            this.Visited = false;
            Neighbours = new List<Cell>();
        }

        public int InitialValue { get; set; }

        public bool Visited { get; set; }

        public int Value { get; set; }

        public int Col { get; set; }

        public int Row { get; set; }

        public Cell Previuose { get; set; }

        public List<Cell> Neighbours { get; set; }

        public int CompareTo(object obj)
        {
            return Value.CompareTo((obj as Cell).Value);
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

}
