using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    private  AIBrain2D Brain;
    public Transform ShotPos;

    private float timer;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        Brain = GetComponentInParent<AIBrain2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2 && Brain.isFiring)
        {
            timer = 0;
            Shooting();
        }
        
    }


    void Shooting()
    {
       Instantiate(bulletPrefab, ShotPos.position, Quaternion.identity);

    }
}
