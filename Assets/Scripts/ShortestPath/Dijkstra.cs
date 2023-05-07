// using System.Collections.Generic;

// public class Node<T> {
//     public T Id { get; set; }
//     public Dictionary<Node<T>, int> Neighbors { get; set; }

//     public Node(T id) {
//         Id = id;
//         Neighbors = new Dictionary<Node<T>, int>();
//     }

//     public void AddNeighbor(Node<T> neighbor, int distance) {
//         Neighbors[neighbor] = distance;
//     }
// }

// public class Graph<T> {
//     public List<Node<T>> Nodes { get; set; }

//     public Graph() {
//         Nodes = new List<Node<T>>();
//     }

//     public void AddNode(Node<T> node) {
//         Nodes.Add(node);
//     }
// }

// public static class Dijkstra<T> {
//     public static List<Node<T>> FindShortestPath(Graph<T> graph, Node<T> startNode, Node<T> endNode) {
//         Dictionary<Node<T>, int> distances = new Dictionary<Node<T>, int>();
//         Dictionary<Node<T>, Node<T>> previousNodes = new Dictionary<Node<T>, Node<T>>();
//         List<Node<T>> unvisitedNodes = new List<Node<T>>();

//         // Initialize distances to infinity, except for the start node which has a distance of 0
//         foreach (var node in graph.Nodes) {
//             distances[node] = int.MaxValue;
//             previousNodes[node] = null;
//             unvisitedNodes.Add(node);
//         }
//         distances[startNode] = 0;

//         while (unvisitedNodes.Count > 0) {
//             // Find the unvisited node with the smallest distance
//             Node<T> current = null;
//             int smallestDistance = int.MaxValue;
//             foreach (var node in unvisitedNodes) {
//                 if (distances[node] < smallestDistance) {
//                     current = node;
//                     smallestDistance = distances[node];
//                 }
//             }

//             // If we've found the end node, reconstruct the path and return it
//             if (current == endNode) {
//                 List<Node<T>> path = new List<Node<T>>();
//                 while (previousNodes[current] != null) {
//                     path.Add(current);
//                     current = previousNodes[current];
//                 }
//                 path.Reverse();
//                 return path;
//             }

//             // Mark the current node as visited
//             unvisitedNodes.Remove(current);

//             // Update the distances of the current node's neighbors
//             foreach (var neighbor in current.Neighbors.Keys) {
//                 int tentativeDistance = distances[current] + current.Neighbors[neighbor];
//                 if (tentativeDistance < distances[neighbor]) {
//                     distances[neighbor] = tentativeDistance;
//                     previousNodes[neighbor] = current;
//                 }
//             }
//         }

//         // If we get here, there is no path from startNode to endNode
//         return new List<Node<T>>();
//     }

// }
