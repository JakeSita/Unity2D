using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoryEvent : MonoBehaviour
{
    public static DontDestoryEvent Instance;

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
