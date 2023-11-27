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

    public Transform playerTransform; // Public to set through the Inspector or find automatically
    public float interactionRange = 1f; // Range within which player can interact

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        originalSprite = spriteRenderer.sprite; // Store the original sprite

        if (!playerTransform)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player by tag
        }
    }

    void Update()
    {
        // Check distance to player
        bool wasInRange = playerInRange;
        playerInRange = Vector2.Distance(transform.position, playerTransform.position) <= interactionRange;

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
                HideDialogBox();
            }
        }

        // Check if the player just moved out of range
        if (wasInRange && !playerInRange)
        {
            HideDialogBox();
        }
    }

    private void HideDialogBox()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
            currentDialogueIndex = 0; // Reset to first dialogue for next interaction
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
