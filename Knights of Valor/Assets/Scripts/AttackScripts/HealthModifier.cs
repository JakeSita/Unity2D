using System.Collections;
using System.Collections.Generic;
//using inventorySystem;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    [SerializeField]
    public float _healthChange = 0f;

    public enum DamageTarget
    {
        Player,
        Enemies,
        All,
        None
    }
    [SerializeField]
    DamageTarget _applyToTarget = DamageTarget.Player;
    [SerializeField]
    bool _destroyOnCollision = false;

    private Rigidbody2D rb;

    [SerializeField]
    private bool knockBack = true;

    [SerializeField]
    private float knockbackforce = 10f;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        GameObject hitObj = collision.gameObject;
        
        HealthSystem healthManager = hitObj.GetComponent<HealthSystem>();
        Vector2 direction = (collider.transform.position - transform.position).normalized;
        Vector2 knockback = direction * knockbackforce;
        
        if (healthManager && IsValidTarget(hitObj,collider))
        {
            healthManager.adjustCurrentHealth(_healthChange, knockback, knockBack);

        }
        if (_destroyOnCollision)
        {
            GameObject.Destroy(gameObject);
        }


    }


    bool IsValidTarget(GameObject possibleTarget, Collider2D collider)
    {
        if(_applyToTarget == DamageTarget.All)
        {
            return true;
        }
        else if( _applyToTarget == DamageTarget.None)
        {
            return false;
        }
        else if (_applyToTarget == DamageTarget.Player &&  possibleTarget.tag == "Player" && collider.tag != "weapon")
        {
            
            return true;
        }
        else if (_applyToTarget == DamageTarget.Enemies && possibleTarget.tag == "enemy" && collider.tag != "laser")
        {
            
            return true;
        }else if (_applyToTarget == DamageTarget.Enemies && possibleTarget.tag == "Pillar")
        {
            return true;
        }

        return false;
    }
}
