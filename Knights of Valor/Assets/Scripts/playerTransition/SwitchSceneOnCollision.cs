using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollision : MonoBehaviour
{
    FadeIn fade;
    [SerializeField, Tooltip("Name of scene to load.")]
    private string _sceneToLoad;

    [SerializeField, Tooltip("Seconds between collision and scene load.")]
    private float _transitionTime = 1f;

    [SerializeField, Tooltip("X position where the player will spawn")]
    public float xPosition;
    [SerializeField, Tooltip("Y position where the player will spawn")]
    public float yPosition;

    private bool _hasCollided = false;
    private PlayerMovement move;

    void Start()
    {
        fade = FindObjectOfType<FadeIn>();
        move = FindObjectOfType<PlayerMovement>();

    }

    void Update()
    {
        // This will continuously reduce transition time after collision
        // and switch scene when it reaches 0 or below.
        if (_hasCollided)
        {

            _transitionTime -= Time.deltaTime;
            move.canMove = false;
            if (_transitionTime <= 0f)
            {
                move.canMove = true;
                SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
            }
        }
    }

    // Fixed coroutine method to return IEnumerator and named it properly
    private IEnumerator SwitchSceneAfterFade()
    {
        // Start the fade-in process
        fade.StartFadeIn(); // Assuming you corrected the FadeIn script as previously discussed
        
        // Wait for the specified transition time
        yield return new WaitForSeconds(_transitionTime);
        
        // Load the scene after the fade-in is complete and transition time has passed
        SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_hasCollided)
        {
            _hasCollided = true;
            collision.transform.position = new Vector3(xPosition, yPosition);

            // Start the coroutine to switch scenes
            StartCoroutine(SwitchSceneAfterFade());

            Debug.Log("Collision with Player detected!");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
        }
    }
}
