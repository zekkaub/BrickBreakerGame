using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public float rightscreenedge, leftscreenedge;
    public GameObject _ball;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            transform.Translate(touchDeltaPosition.x * speed, 0, 0);
        }
        if (transform.position.x < leftscreenedge)
                {
            transform.position = new Vector2(leftscreenedge, transform.position.y);
        }
        if (transform.position.x > rightscreenedge)
        {
            transform.position = new Vector2(rightscreenedge, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Brick")
        {
            Destroy(other.gameObject);
            _ball.GetComponent<Ball>().livesCounter++;
        }
        if (other.tag == "Score")
        {
            Destroy(other.gameObject);
            _ball.GetComponent<Ball>().ScoreCounter+=10;
        }
    }
}
