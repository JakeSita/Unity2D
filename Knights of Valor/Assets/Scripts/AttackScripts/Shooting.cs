using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{ 
    public GameObject bulletPrefab;
    private GameObject Bullet;
    public float distanceOfBullet = 1f;

    public float bulletForce = 10f;

    // Update is called once per frame
    public void fire() {

        Bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        DestoryBullet(distanceOfBullet);
    }
    private IEnumerator DestoryBullet(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(Bullet);
        
    }

}
