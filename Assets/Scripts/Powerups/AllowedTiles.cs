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
    [SerializeField] TileBase horseTile = null;
    [SerializeField] TileBase axeTile = null;
    [SerializeField] TileBase mountainsTile = null;
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

    public bool IsHorseTile(TileBase tile)
    {
        return horseTile == tile;
    }

    public bool IsAxeTile(TileBase tile)
    {
        return axeTile == tile;
    }

    public bool IsMountainsTile(TileBase tile)
    {
        return mountainsTile == tile;
    }
    public TileBase[] Get() { return allowedTiles; }
}
