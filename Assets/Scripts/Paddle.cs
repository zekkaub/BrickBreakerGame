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
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);

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
