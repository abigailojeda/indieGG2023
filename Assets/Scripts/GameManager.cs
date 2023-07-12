using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int cantidadGemas;
    public float distanciaMinima;

    private static int totalScore = 0;
    private int totalGems = 0;
    public Slider progressBar;
    public GameObject prefabGem;
    public List<GameObject> plataforms;


    private void Start()
    {
        this.GenerateGems(prefabGem);
    }

    

    public void GenerateGems(GameObject prefabGem)
    {
        GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Floor");

        foreach (GameObject plataforma in plataformas)
        {
            if (plataforma.activeInHierarchy) 
            {
                int cantidadGemas = Random.Range(1, 4); 

                for (int i = 0; i < cantidadGemas; i++)
                {
                    Vector3 posicion = GenerateNear(plataforma.transform.position);
                    Instantiate(prefabGem, posicion, Quaternion.identity);
                    totalGems++;
                }
            }
        }

        Debug.Log("total gems: "+ totalGems);
    }

    private Vector3 GenerateNear(Vector3 posicionPlataforma)
    {
        float rangoX = Random.Range(-6f, 6f); 
        float rangoY = Random.Range(2f, 5f); 
        Vector3 offset = new Vector3(rangoX, rangoY, 0f);
        return posicionPlataforma + offset;
    }

    public void IncrementScore(int scoreValue)
    {
        totalScore += scoreValue; 
       
        //Debug.Log(totalScore);

        float percentage = ((float)totalScore / (float)totalGems) * 100;
        progressBar.value = percentage;

        PlayerPrefs.SetFloat("GemsCompletionPercentage", percentage);
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.SetInt("TotalGems", totalGems);
        PlayerPrefs.Save();
       
    }

    public void ResetScore()
    {
        totalScore = 0; 
    }


}