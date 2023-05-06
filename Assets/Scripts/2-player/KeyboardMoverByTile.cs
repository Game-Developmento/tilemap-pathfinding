using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile : KeyboardMover
{
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;

    [SerializeField] bool isOnShip = false;


    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()
    {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);

        if (allowedTiles.Contain(tileOnNewPosition) || (isOnShip && allowedTiles.IsSeaTile(tileOnNewPosition)))
        {
            transform.position = newPosition;
        }
        else
        {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
            return; // If trying to go out of bounds, we do not want to allow ToggleIsOnShip!
        }

        ToggleIsOnShip(tileOnNewPosition);
    }

    private void ToggleIsOnShip(TileBase tile)
    {
        if (allowedTiles.IsShipTile(tile))
        {
            isOnShip = true;
        }
        else if (isOnShip && !allowedTiles.IsSeaTile(tile))
        {
            isOnShip = false;
        }
    }
}
