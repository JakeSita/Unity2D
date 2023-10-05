using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXMeleeHitBox : MonoBehaviour
{
    BoxCollider2D boxCol;

    Animator anime;
    float Xmouse = 0f;
    float Ymouse = 0f;


    private void Start()
    {
        
        anime = GetComponentInParent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        
    }

    public void AttackHorizontal() {
        boxCol.enabled = true;
        //Debug.Log("before" + transform.position.x + "," + transform.position.y);

        // Get the XMouse value from the animator
        Xmouse = anime.GetFloat("XMouse");

        // Calculate a position offset based on XMouse
        float offset = Xmouse > 0 ? 1.0f : -1.0f; // Adjust this value as needed

        // Apply the offset to the current position
        transform.localScale = new Vector3(offset, 1f, 1f);
        

        //Debug.Log("After" + transform.position.x + "," + transform.position.y);
    }


    public void AttackVertical()
    {
        boxCol.enabled = true;
        //Debug.Log("before" + transform.position.x + "," + transform.position.y);

        // Get the XMouse value from the animator
        Ymouse = anime.GetFloat("YMouse");

        // Calculate a position offset based on XMouse
        float offset = Ymouse < 0 ? 1.0f : -1.0f; // Adjust this value as needed

        // Apply the offset to the current position
        if(offset == -1.0f)
            transform.localScale = new Vector3(1f, offset - .5f, 1f);
        else
            transform.localScale = new Vector3(1f, offset, 1f);


        //Debug.Log("After" + transform.position.x + "," + transform.position.y);
    }



    public void StopAttack() { boxCol.enabled = false; }



}
