using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audios;
    public void playAudio(string sound)
    {
        switch (sound)
        {
            case "magic":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[0]);
                break;
         
            case "jump":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[1]);
                break;
          
        }
    }
}
