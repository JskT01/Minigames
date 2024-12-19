using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gameOver;
    public AudioClip grabItem;
    public AudioSource audioSource;
    public AudioSource audioSourceBackground;

    public void GrabItem()
    {
        audioSource.clip = grabItem;
        audioSource.Play();
    }

    public void GameOver()
    {
        audioSourceBackground.Stop();
        audioSource.clip = gameOver;
        audioSource.loop = true;
        audioSource.Play();        
                                     
    }
    
}
