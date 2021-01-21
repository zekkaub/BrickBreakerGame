using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool Play =true;
    public Transform paddleT;
    private Vector3 offset = new Vector3(0, 0.2f, 0);
    public Text txtLives,txtScore;
    public int livesCounter = 3, ScoreCounter = 0, EndGameCounter = 0;
    public GameObject PowerUpLives,ScoreBooster;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Play)
        {
            transform.position = paddleT.position + offset;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
        }
        if (!Play && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Play = true;
            rb.AddForce(Vector2.up * 350);
            int j = Random.Range(1, 10);
            if (j<5)
            {
                rb.AddForce(Vector2.right * 200);

            }
            if (j > 5)
            {
                rb.AddForce(Vector2.left * 200);

            }

        }
        txtLives.text = livesCounter.ToString();

        txtScore.text = ScoreCounter.ToString();

        if(livesCounter == 0)
        {
            Debug.Log("you lost");
        }
        Lose();
        Win();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DownTag")
        {
            Play = false;
            livesCounter--;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag  == "Brick")
        {
            //GameObject poweruplivesclone;
            float i = Random.Range(1, 10);
            if (i<2)
            {
                Instantiate(PowerUpLives, other.transform.position, Quaternion.identity);
            }
            else if (i<3)
            {
                Instantiate(ScoreBooster, other.transform.position, Quaternion.identity);
            }
            Destroy(other.gameObject);

            Instantiate(Effect, other.transform.position, Quaternion.identity);

            ScoreCounter++;
            EndGameCounter++;
        }
       
    }
    void Lose()
    {
        if (livesCounter == 0)
        {
            SceneManager.LoadScene("Finish Game");

        }
    }

    void Win()
    {
        if(EndGameCounter == 14)
        {
            SceneManager.LoadScene("Finish Game");
        }
    }
}
