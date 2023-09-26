using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDirections : MonoBehaviour
{
    Animator anime;
    float Xmouse = 0f;
    float Ymouse = 0f;


    private void Start()
    {
        anime = GetComponentInParent<Animator>();
    }

    public void AttackHorizontal()
    {

        Xmouse = anime.GetFloat("XMouse");

        // Calculate a position offset based on XMouse
        float offset = Xmouse >= 0 ? Mathf.Abs(transform.position.x) : -Mathf.Abs(transform.position.x);
        Debug.Log(offset);
        // Apply the offset to the current position
        transform.position = new Vector3(offset, transform.position.y, transform.position.z); // Flip horizontally

        // Check if XMouse is positive or negative and rotate accordingly
        if (Xmouse > 0)
        {
            // Rotate the object to the right
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f); // No rotation
        }
        else if (Xmouse < 0)
        {
            // Rotate the object to the left
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f); // 180-degree rotation
        }
    }

    public void AttackVertical() { }

}
