using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DetectFalling : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
  
        if (other.gameObject == player)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        this.gameManager.ResetScore();
        SceneManager.LoadScene("Losing");

    }

   
   
}
