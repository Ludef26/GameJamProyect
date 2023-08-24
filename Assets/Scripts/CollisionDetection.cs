using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private GameManager gameManager;
    private int lifes;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lifes = GetComponent<PlayerMove>().lifes;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Obstacle")
        {
            lifes--;
            if (lifes < 0)
            {
                gameManager.RestartLevel();
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }
        if(collision.gameObject.tag == "Molino")
        {
            lifes--;
            collision.collider.enabled = false;
            if (lifes < 0)
            {
                gameManager.RestartLevel();
            }
        }
    }
}
