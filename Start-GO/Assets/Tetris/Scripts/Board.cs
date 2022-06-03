using UnityEngine;
using UnityEngine.Tilemaps;


public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public WasteData[] wastes;
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public float life = 10f;
    public float level = 1f;

    public RectInt Bounds
    {
        get
        {
            Vector2Int position = new Vector2Int(-boardSize.x / 2, -boardSize.y / 2);
            return new RectInt(position, boardSize);
        }
    }

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece = GetComponentInChildren<Piece>();
    }
    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, this.wastes.Length);
        WasteData data = this.wastes[random];

        if (life > 0)
        {
            activePiece.Initialize(this, this.spawnPosition, data);
            Set(this.activePiece);
        }  
        else
            Debug.Log("game over");
    }

    public void Set(Piece piece)
    {
        Vector3Int tilePosition = piece.position;
        tilemap.SetTile(tilePosition, piece.data.tile);
    }

    public void Clear(Piece piece)
    {
        Vector3Int tilePosition = piece.position;
        tilemap.SetTile(tilePosition, null);
    }

    public bool IsValidPosition(Vector3Int position)
    {
        RectInt bounds = Bounds;

        if (Mathf.Abs(position.x) >= Mathf.Abs(bounds.position.x))
        {
            return false;
        }

        if (Mathf.Abs(position.y) >= Mathf.Abs(bounds.position.y))
        {
            return false;
        }

        return true;
    }
}
