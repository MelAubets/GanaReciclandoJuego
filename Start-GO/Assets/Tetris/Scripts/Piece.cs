using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get; private set; }
    public WasteData data { get; private set; }
    public Vector3Int position { get; private set; }

    public float stepDelay = 1f;
    public float moveDelay = 0.1f;

    private float stepTime;
    private float moveTime;

    public void Initialize(Board board, Vector3Int position, WasteData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;

        stepTime = Time.time + stepDelay/board.level;
        moveTime = Time.time + moveDelay;
    }

    private void Update()
    {
        board.Clear(this);

        if (Time.time > moveTime)
            HandleMoveInputs();

        if (Time.time > stepTime)
            Step();

        board.Set(this);
    }

    private void HandleMoveInputs()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Move(Vector2Int.down))
                stepTime = Time.time + stepDelay/board.level;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            while (Move(Vector2Int.down))
                continue;
        }


        if (Input.GetKeyDown(KeyCode.A))
            Move(Vector2Int.left);
        else if (Input.GetKeyDown(KeyCode.D))
            Move(Vector2Int.right);
    }

    private void Step()
    {
        stepTime = Time.time + stepDelay/board.level;

        Move(Vector2Int.down);
    }

    private bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = position;

        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = board.IsValidPosition(newPosition);

        if (valid)
            position = newPosition;

        return valid;
    }
}
