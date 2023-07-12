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
            case "button":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[0]);
                break;
            case "pick":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[1]);
                break;
            case "goodDelivered":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[2]);
                break;
            case "backDelivered":
                gameObject.GetComponent<AudioSource>().PlayOneShot(audios[3]);
                break;
        }
    }
}
