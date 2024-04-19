using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody ball;
    public float ballForce;
    public Text score;

    private int obstacleCollisions = 0;
    private bool sceneLoaded = false;

    void Start()
    {
    }

    void Update()
    {
        score.text = ball.position.z.ToString("0");

        if (Input.GetKey("a"))
        {
            ball.AddForce(-ballForce * 2, 0f, 0f);
        }
        else if (Input.GetKey("l"))
        {
            ball.AddForce(ballForce * 2, 0f, 0f);
        }
        else if (Input.GetKey("k"))
        {
            ball.AddForce(0f, 0f, ballForce);
        }
        else if (Input.GetKey("m"))
        {
            ball.AddForce(0f, 0f, -ballForce);
        }

        if (ball.position.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (ball.position.z > 500)
        {
            ball.AddForce(0f, 0f, ballForce + 1);
        }
    }

   private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("obstacle") && !sceneLoaded)
    {
        Debug.Log("collides");
        obstacleCollisions++;
        if (obstacleCollisions > 2)
        {
            Debug.Log(
                "collides twice"
            );
            SceneManager.LoadScene(1);
            sceneLoaded = true;
        }
    }
}

}

