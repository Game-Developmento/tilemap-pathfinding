using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A graph that represents a tilemap, using only the allowed tiles.
 */
public class TilemapWeightedGraph : IWeightedGraph<Vector3Int>
{
    private Tilemap tilemap;
    private TileBase[] allowedTiles;

    public TilemapWeightedGraph(Tilemap tilemap, TileBase[] allowedTiles)
    {
        this.tilemap = tilemap;
        this.allowedTiles = allowedTiles;
    }

    static Vector3Int[] directions = {
            new Vector3Int(-1, 0, 0),
            new Vector3Int(1, 0, 0),
            new Vector3Int(0, -1, 0),
            new Vector3Int(0, 1, 0),
    };
    public IEnumerable<Vector3Int> GetNodes()
    {
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = bounds.min.x; x < bounds.max.x; x++)
        {
            for (int y = bounds.min.y; y < bounds.max.y; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);
                if (allowedTiles.Contains(tile))
                {
                    yield return pos;
                }
            }
        }
    }
    public int GetWeight(TileBase tile)
    {
        switch (tile.name)
        {
            case "bushes":
                return 5;
            case "grass":
                return 3;
            case "hills":
                return 10;
            default:
                return 1;
        }
    }
    public IEnumerable<(Vector3Int node, int weight)> Neighbors(Vector3Int node)
    {
        foreach (var direction in directions)
        {
            Vector3Int neighborPos = node + direction;
            TileBase neighborTile = tilemap.GetTile(neighborPos);
            int weight = 1; // Default weight is 1

            // Assign weights based on tile name
            if (neighborTile)
            {
                weight = GetWeight(neighborTile);
                if (allowedTiles.Contains(neighborTile))
                {
                    yield return (neighborPos, weight);
                }
            }
        }
    }
}


