// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using UnityEngine.Tilemaps;

// /**
//  * A graph that represents a tilemap, using only the allowed tiles.
//  */
// public class TilemapWeightedGraph : IWeightedGraph<Vector3Int>
// {
//     private Tilemap tilemap;
//     private TileBase[] allowedTiles;

//     public TilemapWeightedGraph(Tilemap tilemap, TileBase[] allowedTiles)
//     {
//         this.tilemap = tilemap;
//         this.allowedTiles = allowedTiles;
//     }


//     static Vector3Int[] directions = {
//             new Vector3Int(-1, 0, 0),
//             new Vector3Int(1, 0, 0),
//             new Vector3Int(0, -1, 0),
//             new Vector3Int(0, 1, 0),
//     };

//     public IEnumerable<Vector3Int> GetNodes()
//     {
//         BoundsInt bounds = tilemap.cellBounds;
//         for (int x = bounds.min.x; x < bounds.max.x; x++)
//         {
//             for (int y = bounds.min.y; y < bounds.max.y; y++)
//             {
//                 Vector3Int pos = new Vector3Int(x, y, 0);
//                 TileBase tile = tilemap.GetTile(pos);
//                 if (allowedTiles.Contains(tile))
//                 {
//                     yield return pos;
//                 }
//             }
//         }
//     }
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
