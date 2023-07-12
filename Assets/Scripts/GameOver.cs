using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    
  public void RestartBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        SceneManager.LoadScene("AbiScene");
    }

    public void QuitBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        Application.Quit();
    }

    public void MenuBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        SceneManager.LoadScene("Menu");
    }
}
