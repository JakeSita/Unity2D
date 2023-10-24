using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioTransition : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioSource previousAudioSource;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (previousAudioSource && previousAudioSource.isPlaying)
            {
                previousAudioSource.Stop();
            }
            
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Collision with Audio Source");
            }
        }
    }
}

