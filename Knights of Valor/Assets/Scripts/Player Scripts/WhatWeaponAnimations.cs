using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class WhatWeaponAnimations : MonoBehaviour
{
    private Animator anime;

    private Inventory _inventory;

    private HealthSystem PlayerHealth;

    private HealthModifier[] damageModifier;

    private bool health = false;
    private bool Speed = false;
    private bool Immune = false;
    private bool Red = false;


    void Start()
    {
        anime = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
        PlayerHealth = GetComponent<HealthSystem>();
        //damageModifier = GetComponentInChildren<HealthModifier>();
        damageModifier = GetComponentsInChildren<HealthModifier>();

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
                    foreach(HealthModifier x in damageModifier)
                        x._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;

                case "Silver Weapon":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    foreach (HealthModifier x in damageModifier)
                        x._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;

                case "Projectile Weapon":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;


                case "GoldSword":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    foreach (HealthModifier x in damageModifier)
                        x._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;

                case "SilverDagger":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    foreach (HealthModifier x in damageModifier)
                        x._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;

                case "WoodDagger":
                    anime.SetBool("Melee Weapon", true);
                    anime.SetBool("projectile Weapon", false);
                    foreach (HealthModifier x in damageModifier)
                        x._healthChange = _inventory.GetActiveSlot().Item.Damage;
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;




                case "Silver Projectile":
                    anime.SetBool("projectile Weapon", true);
                    anime.SetBool("Melee Weapon", false);
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;


                case "Health Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = true;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;

                case "Speed Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = true;
                    Immune = false;
                    Red = false;
                    break;

                case "Immune Potion":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = false;
                    Immune = true;
                    Red = false;
                    break;

                case "Red Gem":
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = true;
                    break;



                default:
                    anime.SetBool("Melee Weapon", false);
                    anime.SetBool("projectile Weapon", false);
                    health = false;
                    Speed = false;
                    Immune = false;
                    Red = false;
                    break;
            }


        }
        else
        {
            anime.SetBool("Melee Weapon", false);
            anime.SetBool("projectile Weapon", false);
            health = false;
            Speed = false;
            Red = false;
        }
    }


    void OnFire()
    {
        if (health)
        {
            PlayerHealth._healthCur += 15;
            if (_inventory.GetActiveSlot().NumberOfItems <= 1)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
            }
            else
            {
                _inventory.GetActiveSlot().NumberOfItems--;
            }
        }

        if (Speed)
        {
            GetComponent<PlayerMovement>().moveSpeed += .5f;
            if (_inventory.GetActiveSlot().NumberOfItems <= 1)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
            }
            else
            {
                _inventory.GetActiveSlot().NumberOfItems--;
            }
        }

        if (Immune)
        {
            PlayerHealth._invicibilityFramesCurr += 5f;
            if (_inventory.GetActiveSlot().NumberOfItems <= 1)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, false);
            }
            else
            {
                _inventory.GetActiveSlot().NumberOfItems--;
            }
        }
        if (Red)
        {
            PlayerHealth._healthMax += 10;
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
