using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace inventorySystem
{

    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private int _size = 8;

        public int Size => _size;

        [SerializeField]
        private List<InventorySlot> _slots;

        public List<InventorySlot> Slots => _slots;

        private void OnValidate()
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            _slots ??= new List<InventorySlot>();
            if (_slots.Count > _size) _slots.RemoveRange(_size, _slots.Count - _size);
            if (_slots.Count < _size) _slots.AddRange(new InventorySlot[_size - _slots.Count]);

        }

        public bool IsFull()
        {
            return _slots.Count(Something) >= _size;
        }

        public bool Something(InventorySlot slot) => slot.HasItem;

        public bool CanAcceptItem(ItemStack itemStack)
        {
            var slotWithStackableItem = FindSlot(itemStack.Item, true);

            return !IsFull() || slotWithStackableItem != null;
        }

        private InventorySlot FindSlot(ItemDefinition item, bool onlyStackable = false)
        {
            return _slots.FirstOrDefault(slot => slot.Item == item && item.isStackable || !onlyStackable);
        }

        public ItemStack addItem(ItemStack itemStack)
        {
            var relevantSlot = FindSlot(itemStack.Item, true);
            if(IsFull() && relevantSlot == null)
            {
                throw new InventoryException(InventoryOperation.Add, "Inventory is Full");
            }

            if(relevantSlot != null)
            {
                relevantSlot.NumberOfItems += itemStack.NumberOfItems;
            }

            else
            {
                relevantSlot = _slots.First(slot => !slot.HasItem);
                relevantSlot.State = itemStack;
            }

            return relevantSlot.State;
        }
        
    }
}
