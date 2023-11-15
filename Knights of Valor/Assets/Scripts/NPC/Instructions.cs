using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import the TextMeshPro namespace

public class  instructions: MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    [SerializeField, Tooltip("Image to display with the dialogue")]
    private Image dialogueImage;  // Reference to the Image component

    [SerializeField, Tooltip("Atlas Picture to display")]
    private Sprite atlasPicture;  // The picture to display

    public string dialog;

    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        if(dialogueImage != null)
        {
            dialogueImage.gameObject.SetActive(false);  // Initially hide the image
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                if(dialogueImage != null)
                {
                    dialogueImage.gameObject.SetActive(false);  // Hide the image
                }
            }
            else 
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog; // Set the dialogue text

                if(dialogueImage != null)
                {
                    dialogueImage.sprite = atlasPicture;  // Set the image sprite
                    dialogueImage.gameObject.SetActive(true);  // Show the image
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
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player has left range");
            playerInRange = false;
            dialogBox.SetActive(false);
            if(dialogueImage != null)
            {
                dialogueImage.gameObject.SetActive(false);  // Hide the image
            }
        }
    }
}
