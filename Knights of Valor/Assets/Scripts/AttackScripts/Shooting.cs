using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class Shooting : MonoBehaviour
{ 
    public GameObject bulletPrefab;
    private GameObject Bullet;
    public float distanceOfBullet = 1f;

    public float bulletForce = 10f;
    private Inventory inventory;


    private void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    // Update is called once per frame
    public void fire() {

        Bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var rb = Bullet.GetComponent<Rigidbody2D>();
        var damage = Bullet.GetComponent<HealthModifier>();
        damage._healthChange = inventory.GetActiveSlot().Item.Damage;
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        Destroy(Bullet, distanceOfBullet);
    }

   

}
