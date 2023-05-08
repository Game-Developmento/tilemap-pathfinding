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

    [SerializeField] private bool isOnShip = false;
    [SerializeField] private bool isOnMountains = false;
    [SerializeField] private Sprite spriteToRender = null;
    [SerializeField] private Sprite playerSprite = null;
    [SerializeField] private Sprite shipSprite = null;
    [SerializeField] private Sprite horseSprite = null;
    [SerializeField] private Sprite axePlayerSprite = null;
    [SerializeField] private Tile grassTile = null;

    private TileBase TileOnPosition(Vector3 worldPosition)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        return tilemap.GetTile(cellPosition);
    }

    void Update()
    {
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);

        if (allowedTiles.Contain(tileOnNewPosition)
        || (isOnShip && allowedTiles.IsSeaTile(tileOnNewPosition))
        || ((spriteToRender == horseSprite) && allowedTiles.IsMountainsTile(tileOnNewPosition)))
        {
            transform.position = newPosition;
        }
        else if ((spriteToRender == axePlayerSprite) && allowedTiles.IsMountainsTile(tileOnNewPosition))
        {
            // Changes mountains to grass tiles
            tilemap.SetTile(tilemap.WorldToCell(newPosition), grassTile);
            transform.position = newPosition;
        }
        else
        {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
            return; // If trying to go out of bounds, we do not want to allow HandleShip!
        }

        HandleShip(tileOnNewPosition);
        HandleHorse(tileOnNewPosition);
        HandleAxe(tileOnNewPosition);
        GetComponent<SpriteRenderer>().sprite = spriteToRender;
    }
    private void HandleShip(TileBase tile)
    {
        if (allowedTiles.IsShipTile(tile))
        {
            isOnShip = true;
            spriteToRender = shipSprite;
        }
        else if (isOnShip && !allowedTiles.IsSeaTile(tile))
        {
            isOnShip = false;
            spriteToRender = playerSprite;
        }
    }

    private void HandleHorse(TileBase tile)
    {
        if (allowedTiles.IsHorseTile(tile))
        {
            spriteToRender = horseSprite;
        }
        else if ((spriteToRender == horseSprite) && allowedTiles.IsMountainsTile(tile))
        {
            // Marks the first time the player stepped on mountains. 
            // This is used to detect when the player is off of the mountains to render back to the playerSprite.
            isOnMountains = true; 
        }
        else if (isOnMountains && !allowedTiles.IsMountainsTile(tile)) // Not on mountains
        {
            isOnMountains = false;
            spriteToRender = playerSprite;
        }
    }

    private void HandleAxe(TileBase tile)
    {
        if (allowedTiles.IsAxeTile(tile))
        {
            spriteToRender = axePlayerSprite;
        }
    }
}
