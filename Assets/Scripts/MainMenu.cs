using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenuObject;

    public void StartGame()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        SceneManager.LoadScene("Main");
    }

    public void ShowOptions()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
       // MainMenuObject.SetActive(false);
       // OptionsMenu.SetActive(true);

    }

    public void HideOptions()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
      //  MainMenuObject.SetActive(true);
      //  OptionsMenu.SetActive(false);

    }

    public void QuitBtn()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        Application.Quit();
    }

    public void GoToMenu()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        SceneManager.LoadScene("Menu");

    }
}
