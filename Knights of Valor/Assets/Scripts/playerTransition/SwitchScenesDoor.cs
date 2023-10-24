using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;  // Import the TextMeshPro namespace


public class SwitchScenesDoor : MonoBehaviour
{
    public bool playerInRange;

    [SerializeField, Tooltip("Name Of scene to load.")]
    private string _sceneToLoad;

    [SerializeField, Tooltip("Seconds between collision and load.")]
    private float _transitionTime = 1f;
    private bool _startCountdown = false;


    void Start()
    {
        
    }

    void Update()
{
    if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
    {
        _startCountdown = true;
    }

    if (_startCountdown)
    {
        _transitionTime -= Time.deltaTime;

        if (_transitionTime <= 0f)
        {
            SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
            _startCountdown = false;  // Stop the countdown
        }
    }
}

        private void OnTriggerEnter2D(Collider2D collision)  // Fixed the capitalization
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;  // Set playerInRange to true
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)  // Fixed the capitalization
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
            playerInRange = false;  // Set playerInRange to false
        }
    }   
}
