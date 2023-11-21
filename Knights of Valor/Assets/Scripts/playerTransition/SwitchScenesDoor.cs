using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenesDoor : MonoBehaviour
{
    FadeIn fade;
    public bool playerInRange;
    private Transform playerTransform; // A reference to the player's transform

    [SerializeField, Tooltip("Name of scene to load.")]
    private string _sceneToLoad;

    [SerializeField, Tooltip("Seconds between interaction and scene load.")]
    private float _transitionTime = 1f;
    private bool _startCountdown = false;

    [SerializeField, Tooltip("X position where the player will spawn")]
    public float xPosition;
    [SerializeField, Tooltip("Y position where the player will spawn")]
    public float yPosition;

    void Start()
    {
        fade = FindObjectOfType<FadeIn>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            _startCountdown = true;
        }

        if (_startCountdown)
        {
            StartCoroutine(SwitchSceneAfterFade());
        }
    }

    private IEnumerator SwitchSceneAfterFade()
    {
        // Start the fade-in process
        fade.StartFadeIn();

        // Wait for the specified transition time
        yield return new WaitForSeconds(_transitionTime);

        // Move the player to the specified position
        if (playerTransform != null)
        {
            playerTransform.position = new Vector3(xPosition, yPosition);
        }

        // Load the new scene
        SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerTransform = collision.transform; // Get the player's transform
            Debug.Log("Player in range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            playerTransform = null; // Nullify the player's transform reference
            Debug.Log("Player has left range");
        }
    }
}
