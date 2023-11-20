using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import the TextMeshPro namespace

public class MultipleTextAndImages : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    [SerializeField, Tooltip("List of dialogues")]
    private List<string> dialogues = new List<string>();

    [SerializeField, Tooltip("List of Images to display with the dialogue")]
    private List<Sprite> dialogueImages;  // List of Sprites for dialogue

    private int currentDialogueIndex = 0;
    public bool playerInRange;  

    [SerializeField, Tooltip("Image Component to display dialogue images")]
    private Image dialogueImageComponent;  // Reference to the Image component

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                currentDialogueIndex++;
                if (currentDialogueIndex >= dialogues.Count) // Check if we've reached the end of the dialogues
                {
                    dialogBox.SetActive(false);
                    currentDialogueIndex = 0; // Reset to first dialogue for next interaction
                    if(dialogueImageComponent != null)
                    {
                        dialogueImageComponent.gameObject.SetActive(false);  // Hide the image
                    }
                }
                else
                {
                    UpdateDialogueAndImage();
                }
            }
            else 
            {
                dialogBox.SetActive(true);
                currentDialogueIndex = 0; // Start from the first dialogue
                UpdateDialogueAndImage();
            }
        }
    }

    private void UpdateDialogueAndImage()
    {
        if (dialogues.Count > 0)
        {
            dialogText.text = dialogues[currentDialogueIndex]; // Set the text to the current dialogue
        }
        if(dialogueImages.Count > currentDialogueIndex)
        {
            dialogueImageComponent.sprite = dialogueImages[currentDialogueIndex]; // Set the image
            dialogueImageComponent.gameObject.SetActive(true);  // Show the image
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
            playerInRange = false;
            dialogBox.SetActive(false);
            if(dialogueImageComponent != null)
            {
                dialogueImageComponent.gameObject.SetActive(false);  // Hide the image
            }
        }
    }
}
