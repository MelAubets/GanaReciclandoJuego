using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Container : MonoBehaviour
{
    private int score;

    [SerializeField]
    private Board board;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI lifeText;
    [SerializeField]
    private Slider lifeSlider;

    private string username;
    private int userScore;

    //public Piece activePiece;
    private void Start()
    {
        score = 0;
        scoreText.text = "Puntos\n" + score;
        lifeText.text = "Vida ";
        lifeSlider.value = 10;
        username = PlayerPrefs.GetString("Username");
        userScore = PlayerPrefs.GetInt(username + ".Score", 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == board.activePiece.data.waste.ToString())
        {
            score += 1;
            scoreText.text = "Puntos\n" + score;

            if(score%2 == 0)
            {
                board.level += 1;
            }

            if (score > userScore)
                PlayerPrefs.SetInt(username + ".Score", score);
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
