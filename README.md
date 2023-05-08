# tilemap-path-finding

## Dependencies

Unity version `2021.3.18f1`.

## First Part - Powerups

### Overview

This is an expansion of the game from class, in which powerups are added to the original game to give the player new capabilities.

A new scene named `Powerups` has been added to the folder `Assets/Scenes/5-assignments`.

### New Capabilities

Three new capabilities have been added to the game through the powerups:

1. `Horse`: The horse powerup allows the player to ride on mountains.
2. `Ship`: The ship powerup allows the player to ride on water.
3. `Pickaxe`: This allows the player to change mountains into grass.

The player sprite is updated based on the acquired powerup to enhance the game's visual feedback, enabling the player to easily comprehend the changes happening in the game.

### How to Play

1. [Visit the game page in your web browser.](https://adiy55.itch.io/powerups-game)
2. Use the arrow keys **(left, right, up, and down)** to move the player.
3. Acquire powerups by stepping on the corresponding tiles
4. Use the pickaxe powerup to change mountains into grass.
5. Use the horse powerup to ride on mountains.
6. Use the ship powerup to ride on water.
7. Enjoy the game!

### Modified Scripts

#### AllowedTiles Script

This script from class has been modified by adding new variables and methods to detect more specific tiles. These new methods are used in the `KeyboardMoverByTile` script to check if the player stepped on certain tiles.

#### KeyboardMoverByTile Script

This script from class has been modified to incorporate the new powerup features. It now determines whether a powerup has been acquired and whether any new capabilities should be added. Additionally, the player's sprite is updated by the script to reflect the new powerup acquisition.

## Second Part - Dijkstra Algorithm

### Introduction

We utilized the TileMap from the class and implemented the Dijkstra algorithm to create enemies that chase the player intelligently.
the player's objective is to escape from the enemies.  
[Click here to play the game!](https://orihoward.itch.io/runaway)

### Implementation

The Dijkstra algorithm is used in conjunction with the game itself. The algorithm is attached to the enemies, which are programmed to chase the player. The player moves at the same speed on all types of tiles, but the enemies have different speeds on different tiles. To implement this, we created a weighted graph of the TileMap and used it to calculate the shortest path between the enemies and the player. The algorithm is run each step because the player can change position at any time, and we need to recalculate the path.

### Scripts

Dijkstra: This script contains the implementation of the Dijkstra algorithm.
IWeightedGraph: This is an interface of the graph, which has two functions: `IEnumerable<(T node, int weight)> Neighbors(T node)` and `IEnumerable<T> GetNodes()`.
TargetMoverDijkstra: This script handles the movement of the enemies using the Dijkstra algorithm. It runs the algorithm each step to recalculate the path.
TilemapWeightedGraph: This script implements the interface of the weighted graph and creates a graph of the TileMap.
newChaser: This script inherits from TargetMoverDijkstra and updates the target position so that the enemies will follow the target.
