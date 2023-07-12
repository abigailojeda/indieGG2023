using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    public int scoreValue = 1; 
    private GameManager gameManager;

  

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           if (gameManager)
            {
                gameManager.IncrementScore(scoreValue);
                //UpdateScoreText();
                gameObject.SetActive(false);
            }
            
          
        }
    }

    private void UpdateScoreText()
    {

        //Debug.Log(totalScore);
        //scoreText.text = "Score: " + totalScore.ToString(); // Actualizar el texto de puntuación en el Canvas
    }
}
