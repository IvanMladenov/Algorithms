namespace ProcessorScheduling
{
    using System;

    public class Task : IComparable
    {
        public Task(int value, int deadline, int taskNumber)
        {
            this.Value = value;
            this.Deadline = deadline;
            this.TaskNumber = taskNumber;
        }

        public int TaskNumber { get; set; }

        public int Deadline { get; set; }

        public int Value { get; set; }

        public int CompareTo(object other)
        {
            return this.Value.CompareTo((other as Task).Value);
        }
    }
}