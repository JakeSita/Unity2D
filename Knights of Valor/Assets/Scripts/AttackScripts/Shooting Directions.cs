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
        transform.localPosition = new Vector3(.69f, 0f, 0);
        // Calculate a position offset based on XMouse
        float offset = Xmouse >= 0 ? Mathf.Abs(transform.localPosition.x) : -Mathf.Abs(transform.localPosition.x);
        
        // Apply the offset to the current position
        transform.localPosition = new Vector3(offset, 0f, 0f); // Flip horizontally

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

    public void AttackVertical() {
        Ymouse = anime.GetFloat("YMouse");
        transform.localPosition = new Vector3(.14f, -.68f, 0);//set the begining edge of the staff
        if (Ymouse > 0)
        {
            // Rotate the object to the up
            transform.localRotation = Quaternion.Euler(0f, 0f, -270f);//rotate it up or down based on the position of the mouse
        }
        else if (Ymouse < 0)
        {
            // Rotate the object to the down
            transform.localRotation = Quaternion.Euler(0f, 0f, 270f);
        }

            // Calculate a position offset based on XMouse

        float offset = Ymouse >= 0 ? Mathf.Abs(transform.localPosition.y)+.2f : -Mathf.Abs(transform.localPosition.y);

        // Apply the offset to the current position
        transform.localPosition = new Vector3(0f, offset, 0f); // Flip horizontally
    
}

}
