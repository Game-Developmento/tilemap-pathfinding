using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
   public static List<NodeType> FindShortestPath<NodeType>(
        IWeightedGraph<NodeType> graph,
        NodeType startNode, NodeType endNode)
    {
        Dictionary<NodeType, double> distances = new Dictionary<NodeType, double>();
        Dictionary<NodeType, NodeType> previous = new Dictionary<NodeType, NodeType>();
        HashSet<NodeType> visited = new HashSet<NodeType>();

        // Initialize all distances to infinity, except the start node
        foreach (var node in graph.GetNodes())
        {
            distances[node] = double.PositiveInfinity;
        }
        distances[startNode] = 0;

        // Initialize the queue with the start node
        Queue<NodeType> queue = new Queue<NodeType>();
        queue.Enqueue(startNode);

        // Repeatedly select the unvisited node with the smallest distance
        while (queue.Count > 0 && !visited.Contains(endNode))
        {
            NodeType current = queue.Dequeue();

            // Skip nodes that have already been visited
            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);
            // Update the distances and previous nodes of the unvisited neighbors of the current node
            foreach ((var neighbor, int neighborWeight) in graph.Neighbors(current))
            {
                if (visited.Contains(neighbor))
                {
                    continue;
                }
                double newDistance = distances[current] + neighborWeight;
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    previous[neighbor] = current;

                    // Add the neighbor to the queue to be explored
                    queue.Enqueue(neighbor);
                }
            }
        }

        // Reconstruct the shortest path from startNode to endNode
        List<NodeType> shortestPath = new List<NodeType>();
        double shortestPathLength = distances[endNode];
        if (!double.IsInfinity(shortestPathLength))
        {
            NodeType current = endNode;
            shortestPath.Add(current);
            while (previous.ContainsKey(current))
            {
                current = previous[current];
                shortestPath.Add(current);
            }
            shortestPath.Reverse();
        }
        return shortestPath;
    }

}
