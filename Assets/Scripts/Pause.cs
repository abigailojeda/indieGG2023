using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Intructions;
   // public GameObject IntructionsButton;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (Time.timeScale < 1) 
            {
                hidePause();
                
            }
            else 
            {
                showPause();
            }
        }
    }

    public void showPause()
    {
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        Time.timeScale = 0;
        //  IntructionsButton.SetActive(false);
        Intructions.SetActive(true);
        Debug.Log("showing");
        Debug.Log(Time.timeScale);


    }

    public void hidePause()
    {
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        Time.timeScale = 1;
        // IntructionsButton.SetActive(true);
        Intructions.SetActive(false);
        Debug.Log("hidden");
        Debug.Log(Time.timeScale);

    }

    public void goToMenu()
    {
        //GameObject.Find("SoundManager").GetComponent<SoundManager>().playAudio("button");
        Time.timeScale = 1;
        // IntructionsButton.SetActive(true);
        Intructions.SetActive(false);
        SceneManager.LoadScene("Menu");

    }


}
