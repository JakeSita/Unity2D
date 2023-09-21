using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace inventorySystem
{


    public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float collisionOffset = .05f;
        public ContactFilter2D movementFilter;
        public List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
        Animator WalkAnimation;
        BoxCollider2D walkCol;
        public Vector2 movementInput;
        Rigidbody2D movementRb;



        // Start is called before the first frame update
        void Start()
        {
            movementRb = GetComponent<Rigidbody2D>();
            WalkAnimation = GetComponent<Animator>();
            walkCol = GetComponent<BoxCollider2D>();

        }


        private void FixedUpdate()
        {
            if (movementInput != Vector2.zero)
            {
                bool success = tryMove(movementInput);
                WalkAnimation.SetBool("IsMoving", true);

                if (!success)
                {
                    success = tryMove(new Vector2(movementInput.x, 0));


                    if (!success)
                    {
                        success = tryMove(new Vector2(0, movementInput.y));

                    }
                }
            }
            else
            {
                WalkAnimation.SetBool("IsMoving", false);
            }

        }

        void OnMove(InputValue movementValue)
        {

            movementInput = movementValue.Get<Vector2>();

        }

        private bool tryMove(Vector2 direction)
        {
            int count = walkCol.Cast(
                    direction,//X and Y value between -1 and 1 that represents the direction from the body to look for collisions
                    movementFilter, //the setting that determine where a collision can occur on such as layers to collide with
                    castCollisions, // list of collisions to store the found collision into after the cast is finished
                    moveSpeed * Time.deltaTime + collisionOffset // the amount to cast equal to the movement plus an offset
                    );
            if (count == 0)
            {
                movementRb.MovePosition(movementRb.position + direction * moveSpeed * Time.deltaTime);
                WalkAnimation.SetFloat("x", movementInput.x);
                WalkAnimation.SetFloat("y", movementInput.y);
                return true;
            }
            else
            {
                return false;
            }
        }


        
    }
}
