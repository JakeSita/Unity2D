using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using inventorySystem.UI;

namespace inventorySystem
{


    public class UI_InventorySlot : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;

        [SerializeField]
        private int _inventorySlotIndex;

        [SerializeField]
        private Image _itemIcon;

        [SerializeField]
        private Image _activeIndicator;

        [SerializeField]
        private TMP_Text _numberOfItems;


        private InventorySlot _slot;

        private PlayerMovement _player;

        private void Start()
        {

            if (_inventory == null)
            {
                _player = FindAnyObjectByType<PlayerMovement>();
                _inventory = _player.gameObject.GetComponent<Inventory>();
            }
            AssignSlot(_inventorySlotIndex);
        }

        public void AssignSlot(int slotIndex)
        {
            if (_slot != null) _slot.StateChanged -= OnStateChanged;
            _inventorySlotIndex = slotIndex;
            if (_inventory == null) _inventory = GetComponentInParent<UI_Inventory>().Inventory;

            _slot = _inventory.Slots[_inventorySlotIndex];
            _slot.StateChanged += OnStateChanged;
            UpdateViewState(_slot.State, _slot.Active);

        }

        private void UpdateViewState(ItemStack state, bool active)
        {
            if (_activeIndicator == null || _itemIcon == null || _numberOfItems == null)
            {
                // Check if any of the UI elements is null and return to avoid errors.
                return;
            }
            _activeIndicator.enabled = active;
            var item = state?.Item;
            var hasItem = item != null;
            var isStackable = hasItem && item.isStackable;
            _itemIcon.enabled = hasItem;
            _numberOfItems.enabled = isStackable;
            if (!hasItem) return;

            _itemIcon.sprite = item.uiSprite;

            if (isStackable) _numberOfItems.SetText(state.NumberOfItems.ToString());

        }


        private void OnStateChanged(object sender, InventorySlotStateChangedArgs args)
        {
            UpdateViewState(args.NewState, args.Active);
        }
    }
}

