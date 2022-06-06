using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right.normalized;
    private List<Transform> _segments;
    public Transform segmentPrefab;
    public int score;

    private void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(transform);
        score = 0;
    }

    private void Update()
    {
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
