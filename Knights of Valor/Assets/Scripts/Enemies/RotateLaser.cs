using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLaser : MonoBehaviour
{
    public float rotateSpeed = 1f;
    [SerializeField]
    private GameObject laser;
    // Update is called once per frame
    private SpriteRenderer boss;
    private int count = 0;
    private float timer = 0;
    private Animator anime;
    AIBrain2D ai;


    private void Start()
    {
        boss = GetComponentInParent<SpriteRenderer>();
        anime = GetComponentInChildren<Animator>();
        ai = GetComponentInParent<AIBrain2D>();
       
    }
    void Update() {
        timer += Time.deltaTime;
        if(boss.flipX && count == 0){
            transform.position = new Vector3(transform.position.x - .3f, transform.position.y, transform.position.z);
            count++;
         }
        else if(!boss.flipX && count == 1)
        {
            transform.position = new Vector3(transform.position.x + .3f, transform.position.y, transform.position.z);
            count--;
        }
        float angle = Mathf.Atan2(ai.CalcPlayerPos().y - transform.position.y, ai.CalcPlayerPos().x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //if (timer > 4f)
        //{
        //    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        //    timer = 0;
        //    anime.SetTrigger("Fire");
        //    laser.SetActive(false);
        //}
    }
}
