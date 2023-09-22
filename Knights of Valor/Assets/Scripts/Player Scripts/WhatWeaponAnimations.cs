using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class WhatWeaponAnimations : MonoBehaviour
{
    Animator anime;

    Inventory _inventory;



    void Start()
    {
        anime = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();

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
                    break;

                case "Projectile Weapon":
                    anime.SetBool("projectile Weapon", true);
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
