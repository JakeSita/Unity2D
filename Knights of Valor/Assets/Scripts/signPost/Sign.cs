using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Import the TextMeshPro namespace


public class Sign : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    public string dialog;

    public bool playerInRange;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else 
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog; // Changed Text to text
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
            dialogBox.SetActive(false);  // Fixed this line
        }
    }
}
