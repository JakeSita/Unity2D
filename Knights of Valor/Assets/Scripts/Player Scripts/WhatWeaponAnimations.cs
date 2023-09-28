using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class WhatWeaponAnimations : MonoBehaviour
{
    private Animator anime;

    private Inventory _inventory;

    private HealthSystem PlayerHealth;


    void Start()
    {
        anime = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
        PlayerHealth = GetComponent<HealthSystem>();

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
                    break;

                case "Projectile Weapon":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    break;


                case "Health Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    break;

                case "SpeedPotion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    break;

                default:
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    break;
            }


        }
        else
        {
            anime.SetBool("Melee Weapon", false);
            anime.SetBool("projectile Weapon", false);
        }
    }
}
