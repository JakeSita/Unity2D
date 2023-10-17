using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public  AIBrain2D Brain;
    public Transform ShotPos;

    private float timer;
    

    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Debug.Log("timer " + timer + "IsFiring" + Brain.isFiring);
        if (timer > 2 && Brain.isFiring)
        {
            Debug.Log("this happens");
            timer = 0;
            Shooting();
        }
        
    }


    void Shooting()
    {
       Instantiate(bulletPrefab, ShotPos.position, Quaternion.identity);

    }
}
