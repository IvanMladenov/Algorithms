using System;
using System.Collections.Generic;
using System.Linq;

public class DistanceBetweenVertices
{
    private static Dictionary<int, List<int>> graph;

    private static List<int> pathsCount = new List<int>(); 

    private static void Main()
    {
        graph = new Dictionary<int, List<int>>
                    {
                        { 11, new List<int> { 4 } },
                        { 4, new List<int> { 12,1 } },
                        { 1, new List<int> { 12, 21, 7 } },
                        { 7, new List<int> { 21 } },
                        { 12, new List<int> { 4, 19 } },
                        { 19, new List<int>{1, 21} },
                        { 21, new List<int> { 14, 31 } },
                        { 14, new List<int>(){14} },
                        { 31, new List<int> {} },
                    };

        int startVertex = 11;
        int endVertex = 14;
        List<int> visited = new List<int>() { startVertex };

        DistanceBFS(startVertex, endVertex, visited);

        pathsCount.Sort();
        Console.WriteLine(pathsCount.Count == 0?-1:pathsCount.Min());

    }

    static void DistanceBFS(int current, int destination, List<int> visited)
    {
        foreach (var child in graph[current])
        {
            if (visited.Contains(child))
            {
                continue;
            }

            if (child == destination)
            {
                pathsCount.Add(visited.Count);
                break;
            }
        }

        foreach (var child in graph[current])
        {
            if (visited.Contains(child) || child == destination)
            {
                continue;
            }
            visited.Add(child);
            DistanceBFS(child, destination, visited);
            visited.RemoveAt(visited.Count-1);
        }
    }
}