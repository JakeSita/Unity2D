using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class WhatWeaponAnimations : MonoBehaviour
{
    private Animator anime;

    private Inventory _inventory;

    private HealthSystem PlayerHealth;

    private HealthModifier damageModifier;

    private bool health = false;
    private bool Speed = false;


    void Start()
    {
        anime = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
        PlayerHealth = GetComponent<HealthSystem>();
        damageModifier = GetComponentInChildren<HealthModifier>();

    }

    private void Update()
    {
        WhatAmIHolding();
    }

    private void WhatAmIHolding()
    {

        if (_inventory.GetActiveSlot().HasItem)
        {
            switch (_inventory.GetActiveSlot().Item.Name)
            {
                case "Melee Weapon":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    damageModifier._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    break;

                case "Silver Weapon":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    damageModifier._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    break;

                case "Projectile Weapon":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    health = false;
                    Speed = false;
                    break;


                case "Silver Projectile":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    health = false;
                    Speed = false;
                    break;


                case "Health Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = true;
                    Speed = false;
                    break;

                case "Speed Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = true;
                    break;

                default:
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = false;
                    break;
            }


        }
        else
        {
            anime.SetBool("Melee Weapon", false);
            anime.SetBool("projectile Weapon", false);
            health = false;
            Speed = false;
        }
    }


    void OnFire()
    {
        if(health == true) { 
            PlayerHealth._healthCur += 25;
           if(_inventory.GetActiveSlot().NumberOfItems <= 1)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
            }
            else
            {
                _inventory.GetActiveSlot().NumberOfItems--;
            }
        }

        if(Speed)
        {
            GetComponent<PlayerMovement>().moveSpeed += 2;
            if (_inventory.GetActiveSlot().NumberOfItems <= 1)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
            }
            else
            {
                _inventory.GetActiveSlot().NumberOfItems--;
            }
        }


    }
}
