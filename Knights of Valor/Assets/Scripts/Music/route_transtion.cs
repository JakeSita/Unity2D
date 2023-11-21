using System.Collections;
using UnityEngine;
using TMPro;

public class route_transition : MonoBehaviour
{
    [SerializeField, Tooltip("Name Of DialogBox")]
    private GameObject dialogBox;

    [SerializeField, Tooltip("Name Of TMP Text")]
    private TextMeshProUGUI dialogText;

    public string dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            StartCoroutine(ShowDialog()); // Start the dialog coroutine
        }
    }

    private IEnumerator ShowDialog()
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        yield return new WaitForSeconds(2); // Dialog box will show for 4 seconds
        dialogBox.SetActive(false);
    }
}
