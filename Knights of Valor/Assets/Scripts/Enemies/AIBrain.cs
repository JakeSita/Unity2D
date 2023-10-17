using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIBrain : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform target;

    public float speed = 200f;

    Animator anime;

    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;

    

    Seeker seeker;

    Rigidbody2D rb;
    public Transform direct;

    
    private Vector2 offset = Vector2.down * -.7f;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();


        InvokeRepeating("updatePath", 0f, .5f);
        seeker.StartPath(rb.position - offset, target.position, OnPathComplete);



    }

    void updatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position - offset, target.position, OnPathComplete);
    }


    void OnPathComplete(Path p )
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (rb.position - offset)).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position - offset, path.vectorPath[currentWaypoint]);

        if(distance< nextWaypointDistance)
        {
            currentWaypoint++;
        }

        anime.SetFloat("x", rb.velocity.x);
        anime.SetFloat("y", rb.velocity.y);
        if (rb.velocity.magnitude > 0.1f)
        {
            anime.SetBool("IsRunning", true);
        }
        else
        {
            anime.SetBool("IsRunning", false);
        }
    }

}

