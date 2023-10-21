using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyItems : MonoBehaviour
{
    public static DontDestroyItems Instance;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
}
