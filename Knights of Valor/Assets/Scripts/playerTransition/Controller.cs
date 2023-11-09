using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    FadeIn fade; 
    // Start is called before the first frame update
    void Start()
    {
        fade = FindObjectOfType<FadeIn>();

        fade.StartFadeOut(); 
    }

}
