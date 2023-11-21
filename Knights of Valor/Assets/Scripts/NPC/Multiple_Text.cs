using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import the TextMeshPro namespace

public class Multiple_Text : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    [SerializeField, Tooltip("List of dialogues")]
    private List<string> dialogues = new List<string>();

    private int currentDialogueIndex = 0;
    public bool playerInRange;  

    // Start is called before the first frame update
    void Start()
    {
        // Initialize your dialogues here, or set them in the inspector
        // Example: dialogues.Add("Hello World!");
        // Example: dialogues.Add("Another line of dialogue");
    }

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
                }
                else
                {
                    dialogText.text = dialogues[currentDialogueIndex]; // Update the text
                }
            }
            else 
            {
                dialogBox.SetActive(true);
                if (dialogues.Count > 0)
                {
                    dialogText.text = dialogues[currentDialogueIndex]; // Set the text to the first dialogue
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
            currentDialogueIndex = 0; // Reset to first dialogue

            if (dialogues.Count > 0)
            {
                dialogText.text = dialogues[currentDialogueIndex]; // Set text to the first dialogue immediately
            }
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
