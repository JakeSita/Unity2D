using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementDirection : MonoBehaviour
{
    public AIPath aiPath;
    private Animator anime;



    private void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("x", aiPath.desiredVelocity.x);
        anime.SetFloat("y", aiPath.desiredVelocity.y);
        if(aiPath.velocity.magnitude > 0.1f)
        {
            anime.SetBool("IsRunning", true);
        }
        else
        {
            anime.SetBool("IsRunning", false);
        }
    }
}
