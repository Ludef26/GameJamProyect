using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    private GameManager gameManager;
    private int lifes;
    public GameObject canvasUpgrades, hud, canvasHearts, lifesText;
    private AudioSource audioSource;
    public AudioClip impactFX;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GetComponent<PlayerMove>().lifes--;
            audioSource.PlayOneShot(impactFX, 1.8f);
            if (GetComponent<PlayerMove>().lifes < 0)
            {
                Time.timeScale = 0;
                canvasUpgrades.SetActive(true);
                hud.SetActive(false);
            }
            else
            {
                collision.gameObject.SetActive(false);
                lifesText.GetComponent<TMP_Text>().text = (GetComponent<PlayerMove>().lifes + 1).ToString();
                canvasHearts.SetActive(true);
                StartCoroutine(DeactivateCanvasHearts());
            }
        }
        if(collision.gameObject.tag == "Molino")
        {
            audioSource.PlayOneShot(impactFX, 1.8f);
            GetComponent<PlayerMove>().lifes--;
            collision.collider.enabled = false;
            if (GetComponent<PlayerMove>().lifes < 0)
            {
                gameManager.RestartLevel();
            }
            else
            {
                lifesText.GetComponent<TMP_Text>().text = (GetComponent<PlayerMove>().lifes + 1).ToString();
                canvasHearts.SetActive(true);
            }
        }
    }

    private IEnumerator DeactivateCanvasHearts()
    {
        yield return new WaitForSeconds(1f);
        canvasHearts.SetActive(false);
    }
}
