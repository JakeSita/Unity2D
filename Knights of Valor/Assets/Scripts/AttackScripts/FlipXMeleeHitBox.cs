using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXMeleeHitBox : MonoBehaviour
{
    Collider2D boxCol;
    
    Animator anime;
    Vector2 AttackOffset;
    float Xmouse = 0f;
    Vector2 playerPosition;

    private void Start()
    {
        boxCol = GetComponent<Collider2D>();
        anime = GetComponentInParent<Animator>();
        
    }

    public void Attack() {
        boxCol.enabled = true;
        //Debug.Log("before" + transform.position.x + "," + transform.position.y);

        // Get the XMouse value from the animator
        Xmouse = anime.GetFloat("XMouse");

        // Calculate a position offset based on XMouse
        float offset = Xmouse > 0 ? 1.0f : -1.0f; // Adjust this value as needed

        // Apply the offset to the current position
        transform.position = new Vector3(offset, transform.position.y, transform.position.z);
        

        //Debug.Log("After" + transform.position.x + "," + transform.position.y);
    }


    public void StopAttack() { boxCol.enabled = false; }

    



}
