using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultipleText_ChangeDirection : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    [SerializeField, Tooltip("List of dialogues")]
    private List<string> dialogues = new List<string>();

    private int currentDialogueIndex = 0;
    public bool playerInRange;

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    [SerializeField] private Sprite spriteUp;
    [SerializeField] private Sprite spriteDown;
    [SerializeField] private Sprite spriteLeft;
    [SerializeField] private Sprite spriteRight;

    private Sprite originalSprite; // To store the original sprite

    private Transform playerTransform; // To store the player's Transform

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        originalSprite = spriteRenderer.sprite; // Store the original sprite

        // Initialize your dialogues here, or set them in the inspector
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                ChangeSpriteDirection(playerTransform.position - transform.position);
            }

            if (currentDialogueIndex < dialogues.Count)
            {
                dialogText.text = dialogues[currentDialogueIndex]; // Update the text
                currentDialogueIndex++;
            }
            else // End of dialogues
            {
                dialogBox.SetActive(false);
                currentDialogueIndex = 0; // Reset to first dialogue for next interaction
                spriteRenderer.sprite = originalSprite; // Revert back to original sprite
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerTransform = collision.transform; // Store the player's transform
            currentDialogueIndex = 0; // Reset to first dialogue
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            spriteRenderer.sprite = originalSprite; // Revert back to original sprite
        }
    }

    private void ChangeSpriteDirection(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            spriteRenderer.sprite = direction.x > 0 ? spriteRight : spriteLeft;
        }
        else
        {
            spriteRenderer.sprite = direction.y > 0 ? spriteUp : spriteDown;
        }
    }
}
