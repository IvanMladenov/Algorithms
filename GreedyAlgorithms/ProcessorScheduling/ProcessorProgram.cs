namespace ProcessorScheduling
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime;
    using System.Text.RegularExpressions;

    class ProcessorProgram
    {
        static void Main(string[] args)
        {
            int numberOfTasks = int.Parse(Regex.Match(Console.ReadLine(), "[\\d]+").ToString());
            Task[] tasks = new Task[numberOfTasks];
            int maxDeadline = 0;
            for (int i = 0; i < numberOfTasks; i++)
            {
                string[] currentLine = Console.ReadLine()
                    .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                Task current = new Task(int.Parse(currentLine[0]), int.Parse(currentLine[1]), i+1);
                if (current.Deadline>maxDeadline)
                {
                    maxDeadline = current.Deadline;
                }
                tasks[i] = current;
            }

            BinaryHeap<Task> sorted = new BinaryHeap<Task>();
            List<int> output = new List<int>();
            int totalValue = 0;
            for (int i = maxDeadline; i >= 1; i--)
            {
                var currentDeadlineTasks = tasks.Where(x => x.Deadline == i);
                foreach (var task in currentDeadlineTasks)
                {
                    sorted.Insert(task);
                }

                var taskToProcess = sorted.ExtractMax();
                totalValue += taskToProcess.Value;
                output.Add(taskToProcess.TaskNumber);
            }

            output.Reverse();
            Console.WriteLine("Optimal schedule:  {0}", string.Join(" -> ", output));
            Console.WriteLine("Total value: {0}", totalValue);
        }
    }
}
