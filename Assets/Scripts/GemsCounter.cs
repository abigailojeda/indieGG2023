using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsCounter : MonoBehaviour
{
    public int scoreValue = 1; 
    public GameManager gameManager;

  

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // private Text scoreText; // Referencia al componente Text del Canvas

    //private void Start()
    //{
    //    GameObject canvas = GameObject.FindGameObjectWithTag("UI"); // Encontrar el objeto Canvas por su tag único
    //    //scoreText = canvas.GetComponentInChildren<Text>(); // Obtener el componente Text del Canvas
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameManager.IncrementScore(scoreValue);
            UpdateScoreText(); 
            gameObject.SetActive(false);
          
        }
    }

    private void UpdateScoreText()
    {

        //Debug.Log(totalScore);
        //scoreText.text = "Score: " + totalScore.ToString(); // Actualizar el texto de puntuación en el Canvas
    }
}
