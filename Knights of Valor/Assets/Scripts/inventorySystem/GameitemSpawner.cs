using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace inventorySystem
{


    public class GameitemSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemBasePrefab;
        private Vector2 movementInput;
        private Animator anime;
        
        

        private void Awake()
        {
            if(gameObject.tag == "Player")
                anime = GetComponent<Animator>();
           
        }



        public void SpawnItem(ItemStack itemstack)
        {
            //    if (_itemBasePrefab == null) return;

            //    var item = PrefabUtility.InstantiatePrefab(_itemBasePrefab) as GameObject;

            //    item.transform.position = transform.position;

            //    var GameItemScript = item.GetComponent<GameItem>();

            //    GameItemScript.SetStack(new ItemStack(itemstack.Item, itemstack.NumberOfItems));

            //    if(gameObject.tag == "Player")
            //        GameItemScript.Throw(anime.GetFloat("x"), anime.GetFloat("y"));

            //}
            if (_itemBasePrefab == null) return;

            var item = Instantiate(_itemBasePrefab, transform.position, Quaternion.identity);

            var GameItemScript = item.GetComponent<GameItem>();

            if (GameItemScript != null)
            {
                GameItemScript.SetStack(new ItemStack(itemstack.Item, itemstack.NumberOfItems));

                if (gameObject.tag == "Player")
                    GameItemScript.Throw(anime.GetFloat("x"), anime.GetFloat("y"));
            }
        }




        }
}
