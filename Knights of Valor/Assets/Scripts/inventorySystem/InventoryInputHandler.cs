
using UnityEngine;
using UnityEngine.InputSystem;
using GameInput;

namespace inventorySystem
{


    public class InventoryInputHandler : MonoBehaviour
    {
        private Inventory _inventory;

        private Vector2 Movement;


        private void Awake()
        {
            _inventory = GetComponent<Inventory>();

        }


        private void OnEnable()
        {
            InputActions.Instance.Game.Throw.performed += OnThrow;
            InputActions.Instance.Game.Next.performed += OnNext;
            InputActions.Instance.Game.Previous.performed += OnPrevious;
            //InputActions.Instance.Player.Move.performed += OnMove;

        }

        private void OnDisable()
        {
            InputActions.Instance.Game.Throw.performed -= OnThrow;
            InputActions.Instance.Game.Next.performed -= OnNext;
            InputActions.Instance.Game.Previous.performed -= OnPrevious;
            //InputActions.Instance.Player.Move.performed -= OnMove;


        }

        void OnThrow(InputAction.CallbackContext ctx)
        {
            if(_inventory.GetActiveSlot().HasItem)
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, true);
        }

        void OnNext(InputAction.CallbackContext ctx)
        {
            _inventory.ActiveSlot(_inventory.ActiveSlotIndex + 1);
        }

        void OnPrevious(InputAction.CallbackContext ctx) {
            _inventory.ActiveSlot(_inventory.ActiveSlotIndex - 1);
        }
        



    }
}
