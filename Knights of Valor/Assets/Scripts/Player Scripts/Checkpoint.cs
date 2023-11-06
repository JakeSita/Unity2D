using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    GameSessionManager gm;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("trigger hit");
        gm = GameObject.FindAnyObjectByType<GameSessionManager>();

        gm.setActiveRespawn(transform);
    }
}
