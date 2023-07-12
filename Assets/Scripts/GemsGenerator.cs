using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemsGenerator : MonoBehaviour
{
    public GameManager gameManager;
    //public GameObject prefabGemaA;
    //public GameObject prefabGemaB;
    public int cantidadGemas;
    public float distanciaMinima;

    public static GemsGenerator Instance { get; private set; }

    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);

    //}

    public void GenerateGems(GameObject prefabGem)
    {
        //if (!gameManager.isGemSelected)
        //{
        //    return;
        //}
        Debug.Log("generate");



        GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] plataformasMoving = GameObject.FindGameObjectsWithTag("MovingFloor");
        int plataformasCount = plataformas.Length + plataformasMoving.Length;

        Debug.Log(plataformasCount);

        for (int i = 0; i < cantidadGemas; i++)
        {
            Vector3 posicion;
            bool posicionValida = false;

            while (!posicionValida)
            {
                posicion = GenerarPosicionAleatoria();
                bool cercaDePlataforma = VerificarDistanciaMinima(posicion, plataformas, distanciaMinima);
                bool cercaDePlataformaMoving = VerificarDistanciaMinima(posicion, plataformasMoving, distanciaMinima);
                posicionValida = cercaDePlataforma || cercaDePlataformaMoving;

                if (posicionValida)
                {
                    Instantiate(prefabGem, posicion, Quaternion.identity);
                }
            }
        }

    }


    private Vector3 GenerarPosicionAleatoria()
    {
        float x = Random.Range(-10f, 10f); // Ajusta los valores según el rango en el que deseas generar las gemas
        float y = Random.Range(-10f, 10f); // Ajusta los valores según el rango en el que deseas generar las gemas
        return new Vector3(x, y, 0f);
    }

    private bool VerificarDistanciaMinima(Vector3 posicion, GameObject[] plataformas, float distanciaMinima)
    {
        foreach (GameObject plataforma in plataformas)
        {
            if (Vector3.Distance(posicion, plataforma.transform.position) < distanciaMinima)
            {
                return false;
            }
        }
        return true;
    }
}
