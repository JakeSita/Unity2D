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
                    break;

                case "Projectile Weapon":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    health = false;
                    break;


                case "Health Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = true;
                    break;

                case "SpeedPotion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    break;

                default:
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    break;
            }


        }
        else
        {
            anime.SetBool("Melee Weapon", false);
            anime.SetBool("projectile Weapon", false);
            health = false;
        }
    }


    void OnFire()
    {
        if(health == true) {
            PlayerHealth._healthCur += 25;
            _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
        }


    }
}
