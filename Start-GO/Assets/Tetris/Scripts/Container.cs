using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Container : MonoBehaviour
{
    public Board board;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public Slider lifeSlider;

    //public Piece activePiece;
    private void Start()
    {
        scoreText.text = "Puntos\n" + score;
        lifeText.text = "Vida ";
        lifeSlider.value = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == board.activePiece.data.waste.ToString())
        {
            score += 1;
            scoreText.text = "Puntos\n" + score;
            if(score%10 == 0)
            {
                board.level += 1;
            }
        }
        else
        {
            board.life -= 1;
            lifeSlider.value -= 1;
        }

        board.Clear(board.activePiece);
        board.SpawnPiece();
    }
}
