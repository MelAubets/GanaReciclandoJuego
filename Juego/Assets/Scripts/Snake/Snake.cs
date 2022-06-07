using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right.normalized;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int score;
    public TMP_Text thisScore;

    private string username;
    private int userScore;

    private void Start()
    {
        username = PlayerPrefs.GetString("Username");
        userScore = PlayerPrefs.GetInt(username + ".Score", 0);
        _segments = new List<Transform>();
        _segments.Add(transform);
        score = 0;
        thisScore.text = score.ToString();
    }

    private void Update()
    {
        thisScore.text = score.ToString();
        if(_segments.Count == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
                _direction = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.S))
                _direction = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.A))
                _direction = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.D))
                _direction = Vector2.right;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.W) && _direction != Vector2.down)
                _direction = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.S) && _direction != Vector2.up)
                _direction = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.A) && _direction != Vector2.right)
                _direction = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.D) && _direction != Vector2.left)
                _direction = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        for(int i= _segments.Count-1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x) + _direction.x, Mathf.Round(transform.position.y) + _direction.y, 0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            Grow();
            score++;
            if (score > userScore)
                PlayerPrefs.SetInt(username + ".Score", score);
        }
        else if(collision.tag == "Obstacle")
        {
            GameOver();
        }
    }
  
    private void EnableAll()
    {
    }
}
