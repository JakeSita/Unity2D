using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace inventorySystem
{


    public class GameitemSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemBasePrefab;


        public void SpawnItem(ItemStack itemstack) {
            if (_itemBasePrefab == null) return;

            var item = PrefabUtility.InstantiatePrefab(_itemBasePrefab) as GameObject;
            item.transform.position = transform.position;

            var GameItemScript = item.GetComponent<GameItem>();

            GameItemScript.SetStack(new ItemStack(itemstack.Item, itemstack.NumberOfItems));

            GameItemScript.Throw(transform.localScale.x);
            
        }

        
    }
}
