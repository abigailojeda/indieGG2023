
using UnityEngine;

public class ShowScore : MonoBehaviour
{
    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        int totalGems = PlayerPrefs.GetInt("TotalGems");

        Debug.Log("Puntuaci�n total: " + totalScore);
        Debug.Log("Total de gemas: " + totalGems);

    }

}
