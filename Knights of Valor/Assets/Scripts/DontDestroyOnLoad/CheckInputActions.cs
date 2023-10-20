using UnityEngine;
using UnityEngine.InputSystem;

public class CheckInputActions : MonoBehaviour
{
    public InputActionAsset inputActions; // Assign your InputActionAsset in the Unity Inspector.

    private void Start()
    {
        // Check if the input actions are enabled.
        foreach (InputActionMap actionMap in inputActions.actionMaps)
        {
            foreach (InputAction action in actionMap)
            {
                if (action.enabled)
                {
                    Debug.Log($"{action.name} is active and can be used in the current scene.");
                }
                else
                {
                    Debug.Log($"{action.name} is not active and cannot be used in the current scene.");
                }
            }
        }
    }
}

