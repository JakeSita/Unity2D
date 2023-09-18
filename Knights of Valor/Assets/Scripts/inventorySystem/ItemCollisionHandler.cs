using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace inventorySystem
{


    public class ItemCollisionHandler : MonoBehaviour
    {

        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponentInParent<Inventory>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.TryGetComponent<GameItem>(out var gameItem)) return;

            _inventory.addItem(gameItem.Pick());
        }
        

    }
}
