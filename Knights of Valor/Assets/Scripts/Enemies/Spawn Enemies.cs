using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject Spawnable;
    [SerializeField]
    private float SpawnRate = 10f;
    private float count;


    private void Start()
    {
        count = SpawnRate;
    }
    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if(count < 0)
        {
            Instantiate(Spawnable, transform.position + new Vector3(0, -2), Quaternion.identity);
            count = SpawnRate;
        }
    }
}
