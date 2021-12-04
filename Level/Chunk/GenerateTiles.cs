using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateTiles : MonoBehaviour
{
    private bool isChunkReady = false;

    [SerializeField] private TileBase platformTile;
    [SerializeField] private Tilemap platformTilemap;
    [SerializeField] private TilemapCollider2D tilemapCollider;
    [SerializeField] private int chunkHeight = 12;
    [SerializeField] private int chunkLength = 38;

    public bool IsChunkReady => isChunkReady;

    private IEnumerator InitializeTilemap()
    {
        for (int x = 0; x < chunkLength / 2; x++)
        {
            for (int y = 1; y < chunkHeight - 3; y += 3)
            {
                var tilePosition = new Vector3Int(x, y, 0);
                platformTilemap.SetTile(tilePosition, platformTile);
            }
        }

        isChunkReady = true;
        yield break;
    }

    private void Awake()
    {
        StartCoroutine(InitializeTilemap());
    }
}
