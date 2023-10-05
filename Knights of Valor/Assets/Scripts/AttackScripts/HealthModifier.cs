using System.Collections;
using System.Collections.Generic;
//using inventorySystem;
using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    [SerializeField]
    float _healthChange = 0;

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


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.gameObject.tag);
        GameObject hitObj = collision.gameObject;
        HealthSystem healthManager = hitObj.GetComponentInChildren<HealthSystem>();
        if(healthManager && IsValidTarget(hitObj)){
            healthManager.adjustCurrentHealth(_healthChange);

            
        }
        if (_destroyOnCollision)
        {
            GameObject.Destroy(gameObject);
        }


    }


    bool IsValidTarget(GameObject possibleTarget)
    {
        if(_applyToTarget == DamageTarget.All)
        {
            return true;
        }
        else if( _applyToTarget == DamageTarget.None)
        {
            return false;
        }
        else if (_applyToTarget == DamageTarget.Player && possibleTarget.GetComponentInParent<PlayerMovement>())
        {
            Debug.Log("you hit a player");
            return true;
        }
        else if (_applyToTarget == DamageTarget.Enemies && possibleTarget.GetComponent<AIBrain>())
        {
            Debug.Log("you hit an enemy");
            return true;
        }

        return false;
    }
}
