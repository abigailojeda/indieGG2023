using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScore : MonoBehaviour
{
    public Image imageWhenEqual;
    public Image imageWhenLess;
    public TMP_Text scoreText;

    void Start()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore");
        int totalGems = PlayerPrefs.GetInt("TotalGems");

        Debug.Log("Puntuación total: " + totalScore);
        Debug.Log("Total de gemas: " + totalGems);

        if (totalScore == totalGems)
        {
            imageWhenEqual.gameObject.SetActive(true);
            imageWhenLess.gameObject.SetActive(false);
        }
        else
        {
            imageWhenEqual.gameObject.SetActive(false);
            imageWhenLess.gameObject.SetActive(true);
            scoreText.text = "You forgot " + (totalGems - totalScore) + " little birds";
        }
    }
}
