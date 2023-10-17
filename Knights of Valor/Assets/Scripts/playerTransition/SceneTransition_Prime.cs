using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public GameObject fadeInPanel; 

    public void Awake(){
        if(fadeInPanel != null){
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1 );
        }
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit collider");
        // if (collion.CompareTag("Player"))
        // {
        //     playerStorage.initialValue = playerPosition;
        //     SceneManager.LoadScene(sceneToLoad);
        // }
    }
}
