# tilemap-path-finding


# Second Part - Dijkstra Algorithm

## Introduction
we utilized the TileMap from the class and implemented the Dijkstra algorithm to create enemies that chase the player intelligently.
the player's objective is to escape from the enemies.

## Implementation
The Dijkstra algorithm is used in conjunction with the game itself. The algorithm is attached to the enemies, which are programmed to chase the player. The player moves at the same speed on all types of tiles, but the enemies have different speeds on different tiles. To implement this, we created a weighted graph of the TileMap and used it to calculate the shortest path between the enemies and the player. The algorithm is run each step because the player can change position at any time, and we need to recalculate the path.

## Scripts
Dijkstra: This script contains the implementation of the Dijkstra algorithm.
IWeightedGraph: This is an interface of the graph, which has two functions: IEnumerable<(T node, int weight)> Neighbors(T node) and IEnumerable<T> GetNodes().
TargetMoverDijkstra: This script handles the movement of the enemies using the Dijkstra algorithm. It runs the algorithm each step to recalculate the path.
TilemapWeightedGraph: This script implements the interface of the weighted graph and creates a graph of the TileMap.
newChaser: This script inherits from TargetMoverDijkstra and updates the target position so that the enemies will follow the target.

