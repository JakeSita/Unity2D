using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace inventorySystem
{

    [CreateAssetMenu(menuName ="Inventory/Item Definition", fileName ="New Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField]
        private string    _name;
        [SerializeField]
        private bool      _isStackable;
        [SerializeField]
        private Sprite    _inGameSprite;
        [SerializeField]
        private Sprite    _uiSprite;

        public string Name => _name;
        public bool isStackable => _isStackable;
        public Sprite InGameSprite => _inGameSprite;
        public Sprite uiSprite => _uiSprite;






    }
    
}
