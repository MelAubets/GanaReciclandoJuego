using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField]
    public BoxCollider2D gridArea;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.y);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        int i = Random.Range(0, sprites.Length - 1);

        spriteRenderer.sprite = sprites[i];
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y));
    }
}