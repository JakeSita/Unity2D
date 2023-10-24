using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Village_Sound : MonoBehaviour
{
    public AudioSource audioSource; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !audioSource.isPlaying) 
        {
            audioSource.Play();
            Debug.Log("Collision with Audio Source");
        }
    }
}

