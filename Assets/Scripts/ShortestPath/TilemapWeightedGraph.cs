// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// /**
//  * A graph that represents a tilemap, using only the allowed tiles.
//  */
// public class TilemapWeightedGraph : Graph<Node<Vector3Int>>
// {
//     private Tilemap tilemap;
//     private TileBase[] allowedTiles;

//     public TilemapWeightedGraph(Tilemap tilemap, TileBase[] allowedTiles)
//     {
//         this.tilemap = tilemap;
//         this.allowedTiles = allowedTiles;

//         // Create nodes for each position in the tilemap
//         foreach (var pos in tilemap.cellBounds.allPositionsWithin)
//         {
//             Vector3Int roundedPos = new Vector3Int(pos.x, pos.y, 0);
//             if (allowedTiles.Contains(tilemap.GetTile(roundedPos)))
//             {
//                 Nodes.Add(new Node<Vector3Int>(roundedPos));
//             }
//         }

//         // Connect neighboring nodes
//         foreach (var node in Nodes)
//         {
//             foreach (var neighbor in Neighbors(node.Id))
//             {
//                 node.AddNeighbor(Nodes.First(n => n.Id == neighbor.Key), neighbor.Value);
//             }
//         }
//     }

//     static Vector3Int[] directions = {
//             new Vector3Int(-1, 0, 0),
//             new Vector3Int(1, 0, 0),
//             new Vector3Int(0, -1, 0),
//             new Vector3Int(0, 1, 0),
//     };

//     public IEnumerable<KeyValuePair<Vector3Int, int>> Neighbors(Vector3Int node)
//     {
//         foreach (var direction in directions)
//         {
//             Vector3Int neighborPos = node + direction;
//             TileBase neighborTile = tilemap.GetTile(neighborPos);
//             int weight = 1; // Default weight is 1

//             // Assign weights based on tile name
//             if (neighborTile.name == "bushes")
//             {
//                 weight = 5;
//             }
//             else if (neighborTile.name == "grass")
//             {
//                 weight = 3;
//             }
//             else if (neighborTile.name == "swamp")
//             {
//                 weight = 2;
//             }
//             else if (neighborTile.name == "hills")
//             {
//                 weight = 10;

//             }
//             if (allowedTiles.Contains(neighborTile))
//             {
//                 yield return new KeyValuePair<Vector3Int, int>(neighborPos, weight);
//             }
//         }
//     }
// }
