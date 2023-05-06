using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component just keeps a list of allowed tiles.
 * Such a list is used both for pathfinding and for movement.
 */
public class AllowedTiles : MonoBehaviour
{
    [SerializeField] TileBase[] allowedTiles = null;
    [SerializeField] TileBase[] seaTiles = null;
    [SerializeField] TileBase shipTile = null;
    public bool Contain(TileBase tile)
    {
        return allowedTiles.Contains(tile);
    }

    public bool IsSeaTile(TileBase tile)
    {
        return seaTiles.Contains(tile);

    }

    public bool IsShipTile(TileBase tile)
    {
        return shipTile == tile;
    }
    public TileBase[] Get() { return allowedTiles; }
}
