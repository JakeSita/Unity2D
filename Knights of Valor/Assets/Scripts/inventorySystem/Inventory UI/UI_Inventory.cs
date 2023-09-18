using System.Collections;
using System.Collections.Generic;
using inventorySystem;
using UnityEditor;
using UnityEngine;

namespace inventorySystem.UI
{

    public class UI_Inventory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventorySlotPrefab;
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private List<UI_InventorySlot> _slots;

        public Inventory Inventory => _inventory;

        [ContextMenu("Initialize Inventory")]
        private void IntializeInventoryUi()
        {
            if (_inventory == null || _inventorySlotPrefab == null) return;

            _slots = new List<UI_InventorySlot>(_inventory.Size);

            for (var i = 0; i < _inventory.Size; i++)
            {
                var uiSlot = PrefabUtility.InstantiatePrefab(_inventorySlotPrefab) as GameObject;
                uiSlot.transform.SetParent(transform, false);
                var uiSlotScript = uiSlot.GetComponent<UI_InventorySlot>();
                uiSlotScript.AssignSlot(i);
                _slots.Add(uiSlotScript);

            }
        }
    }
}

