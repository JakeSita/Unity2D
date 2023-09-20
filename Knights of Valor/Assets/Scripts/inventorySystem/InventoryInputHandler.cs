
using UnityEngine;
using UnityEngine.InputSystem;
using GameInput;

namespace inventorySystem
{


    public class InventoryInputHandler : MonoBehaviour
    {
        private Inventory _inventory;


        private void Awake()
        {
            _inventory = GetComponent<Inventory>();

        }


        private void OnEnable()
        {
            InputActions.Instance.Game.Throw.performed += OnThrow;
            InputActions.Instance.Game.Next.performed += OnNext;
            InputActions.Instance.Game.Previous.performed += OnPrevious;

        }

        private void OnDisable()
        {
            InputActions.Instance.Game.Throw.performed -= OnThrow;
            InputActions.Instance.Game.Next.performed -= OnNext;
            InputActions.Instance.Game.Previous.performed -= OnPrevious;
        }

        void OnThrow(InputAction.CallbackContext ctx)
        {
            //
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
