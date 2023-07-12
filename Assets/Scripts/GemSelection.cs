using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSelection : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject gemaA;
    public GameObject gemaB;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //gameManager.ElegirGema(gameObject.tag);
            gemaA.SetActive(false);
            gemaB.SetActive(false);
        }
    }
}
