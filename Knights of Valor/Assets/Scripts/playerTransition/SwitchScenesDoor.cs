using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenesDoor : MonoBehaviour
{
    public bool playerInRange;
    private Transform playerTransform; // A reference to the player's transform

    [SerializeField, Tooltip("Name Of scene to load.")]
    private string _sceneToLoad;

    [SerializeField, Tooltip("Seconds between collision and load.")]
    private float _transitionTime = 1f;
    private bool _startCountdown = false;

    [SerializeField, Tooltip("X pos will spawn")]
    public float xPosition;
    [SerializeField, Tooltip("Y pos will spawn")]
    public float yPosition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            _startCountdown = true;
        }

        if (_startCountdown)
        {
            _transitionTime -= Time.deltaTime;

            if (_transitionTime <= 0f)
            {
                // Move the player to the specified position
                if (playerTransform != null)
                {
                    playerTransform.position = new Vector3(xPosition, yPosition);
                }

                SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
                _startCountdown = false;  // Stop the countdown
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
            playerTransform = collision.transform;  // Get the player's transform
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
            playerInRange = false;
            playerTransform = null;  // Nullify the player's transform reference
        }
    }
}
