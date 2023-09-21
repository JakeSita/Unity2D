using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using inventorySystem;

public class WhatWeaponAnimations : MonoBehaviour
{
    Animator anime;

    Inventory _inventory;
    InventorySlot cur;


    void Start()
    {
        anime = GetComponent<Animator>();
        _inventory = GetComponent<Inventory>();
        
    }

    private void Update()
    {
        CurrentSlot();
    }

    private void CurrentSlot()
    {

        if (_inventory.GetActiveSlot().HasItem)
        {
            if (_inventory.GetActiveSlot().Item.Name == "Melee Weapon")
            {
                anime.SetBool("Melee Weapon", true);
            }
        }
        else
        {
            
        }
    }

    
}
