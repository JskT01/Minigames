using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{
    public AudioClip win;
    public AudioClip match;
    public AudioClip error;
    public AudioSource audioSource;
    public AudioSource audioSourceBackground;

    public void Match()
    {
        audioSource.clip = match;
        audioSource.Play();
    }
    public void Error()
    {
        audioSource.clip = error;
        audioSource.Play();
    }
    public void Win()
    {
        audioSourceBackground.Stop();
        audioSource.clip = win;
        audioSource.loop = true;
        audioSource.Play();        
                                     
    }
    
}
