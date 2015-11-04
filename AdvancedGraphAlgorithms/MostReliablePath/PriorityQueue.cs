using System;
using System.Collections.Generic;

public class BinaryHeap<T>
    where T : IComparable
{
    private readonly List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMax()
    {
        var max = this.heap[0];
        this.heap[0] = this.heap[this.heap.Count - 1];
        this.heap.RemoveAt(this.heap.Count - 1);
        if (this.heap.Count > 0)
        {
            this.HeapifyDown(0);
        }

        return max;
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        this.HeapifyUp(this.heap.Count - 1);
    }

    private void HeapifyDown(int i)
    {
        var leftIndex = 2 * i + 1;
        var rightIndex = 2 * i + 2;
        var largest = i;
        if (leftIndex < this.heap.Count && this.heap[leftIndex].CompareTo(this.heap[largest]) > 0)
        {
            largest = leftIndex;
        }

        if (rightIndex < this.heap.Count && this.heap[rightIndex].CompareTo(this.heap[largest]) > 0)
        {
            largest = rightIndex;
        }

        if (largest != i)
        {
            T old = this.heap[i];
            this.heap[i] = this.heap[largest];
            this.heap[largest] = old;
            this.HeapifyDown(largest);
        }
    }

    private void HeapifyUp(int i)
    {
        var parentIndex = (i - 1) / 2;
        while (i > 0 && this.heap[i].CompareTo(this.heap[parentIndex]) > 0)
        {
            T old = this.heap[i];
            this.heap[i] = this.heap[parentIndex];
            this.heap[parentIndex] = old;

            i = parentIndex;
            parentIndex = (i - 1) / 2;
        }
    }
}