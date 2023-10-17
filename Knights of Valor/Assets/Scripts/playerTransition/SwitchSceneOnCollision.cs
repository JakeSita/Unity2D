using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollision : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of scene to load.")]
    private string _sceneToLoad;

    [SerializeField, Tooltip("Seconds between collision and load.")]
    private float _transitionTime = 1f;

    private bool _hasCollided = false;

    void Update()
    {
        if (_hasCollided)
        {
            _transitionTime -= Time.deltaTime;

            if (_transitionTime <= 0f)
            {
                SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)  // Fixed the capitalization
    {

        if(collision.CompareTag("Player")) 
        {
            _hasCollided = true;
            Debug.Log("Collision with PlayerMovement detected!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // Fixed the capitalization
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
        }
    }
}
