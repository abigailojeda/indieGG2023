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
                GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("magic");
               GetComponent<Animator>().SetBool("disappear", true);
                StartCoroutine(DisableObjectWithDelay(0.4f)); 
                gameManager.IncrementScore(scoreValue);
                //UpdateScoreText();
                //gameObject.SetActive(false);
            }
            
          
        }
    }

    IEnumerator DisableObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void UpdateScoreText()
    {

        //Debug.Log(totalScore);
        //scoreText.text = "Score: " + totalScore.ToString(); // Actualizar el texto de puntuación en el Canvas
    }
}
