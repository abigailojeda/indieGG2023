using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public List<GameObject> plataformsA;
    public List<GameObject> plataformsB;
    //public List<GameObject> gemsA;
    //public List<GameObject> gemsB;

    public GameObject prefabGemA;
    public GameObject prefabGemB;

    public bool isGemSelected = false;
    public string gemSelected = "";
    public int cantidadGemas;
    public float distanciaMinima;

    private static int totalScore = 0;
    private int totalGems = 0;
    public Slider progressBar;

    //private GemsGenerator gemsGenerator;

    //private void Start()
    //{
    //    gemsGenerator = GemsGenerator.Instance;
    //}

    public void ElegirGema(string gemaSeleccionada)
    {
        if (gemaSeleccionada == "GemA")
        {

            Debug.Log("Has elegido la Gema A");
            this.gemSelected = "GemA";
            ActivatePlataforms(plataformsA);
            // DesactivarPlataformas(plataformasB);
        }
        else if (gemaSeleccionada == "GemB")
        {
            Debug.Log("Has elegido la Gema B");
            this.gemSelected = "GemB";
            ActivatePlataforms(plataformsB);
            // DesactivarPlataformas(plataformasA);
        }

        this.isGemSelected = true;
    }

    //private void ActivatePlataforms(List<GameObject> plataforms, List<GameObject> gems)
    private void ActivatePlataforms(List<GameObject> plataforms)

    {
        foreach (GameObject plataform in plataforms)
        {
            plataform.SetActive(true);
        }
        //foreach (GameObject gem in gems)
        //{
        //    gem.SetActive(true);
        //}



        GameObject prefabGem = null;

        if (gemSelected == "GemA")
        {
            prefabGem = prefabGemA;
        }
        else if (gemSelected == "GemB")
        {
            prefabGem = prefabGemB;
        }

        this.GenerateGems(prefabGem);


    }

    //public void GenerateGems(GameObject prefabGem)
    //{
    //    GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Floor");
    //    List<GameObject> plataformasActivas = new List<GameObject>();

    //    foreach (GameObject plataforma in plataformas)
    //    {
    //        if (plataforma.activeInHierarchy) // Verificar si la plataforma está activa en la jerarquía
    //        {
    //            plataformasActivas.Add(plataforma);
    //        }
    //    }

    //    int plataformasCount = plataformasActivas.Count;

    //    for (int i = 0; i < cantidadGemas; i++)
    //    {
    //        Vector3 posicion;
    //        bool posicionValida = false;

    //        while (!posicionValida)
    //        {
    //            posicion = GenerarPosicionAleatoria();

    //            if (posicion.y > 14f)
    //            {
    //                posicion.y = 14f;
    //            }

    //            posicionValida = VerificarDistanciaMinima(posicion, plataformasActivas, distanciaMinima);
    //            if (posicionValida)
    //            {
    //                Instantiate(prefabGem, posicion, Quaternion.identity);
    //            }
    //        }
    //    }
    //}

    //private Vector3 GenerarPosicionAleatoria()
    //{
    //    float x = Random.Range(-10f, 10f); // Ajusta los valores según el rango en el que deseas generar las gemas
    //    float y = Random.Range(-10f, 14f); // Ajusta los valores según el rango en el que deseas generar las gemas (limitado a 14 en el eje Y)
    //    return new Vector3(x, y, 0f);
    //}

    //private bool VerificarDistanciaMinima(Vector3 posicion, List<GameObject> plataformasActivas, float distanciaMinima)
    //{
    //    foreach (GameObject plataforma in plataformasActivas)
    //    {
    //        if (Vector3.Distance(posicion, plataforma.transform.position) < distanciaMinima)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    public void GenerateGems(GameObject prefabGem)
    {
        GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Floor");

        foreach (GameObject plataforma in plataformas)
        {
            if (plataforma.activeInHierarchy) 
            {
                int cantidadGemas = Random.Range(1, 3); 

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
        Debug.Log((float)totalScore +"/"+ (float)totalGems );
        Debug.Log("Porcentaje de gemas recogidas: " + percentage.ToString("F1") + "%");

        PlayerPrefs.SetFloat("GemsCompletionPercentage", percentage);
        PlayerPrefs.Save();
    }

    public void ResetScore()
    {
        totalScore = 0; 
    }


}