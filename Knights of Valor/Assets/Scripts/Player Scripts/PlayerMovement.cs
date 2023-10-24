using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using inventorySystem;




public class PlayerMovement : MonoBehaviour
    {

        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float collisionOffset = .05f;
        public ContactFilter2D movementFilter;
        public List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
        Animator WalkAnimation;
        BoxCollider2D walkCol;
        private Vector2 movementInput;
        Rigidbody2D movementRb;
        [SerializeField]
        private bool Swing;
        private Vector3 Looking;

        [SerializeField]
        private FlipXMeleeHitBox SwrdAttackX;
        [SerializeField]
        private FlipXMeleeHitBox SwrdAttackY;
        [SerializeField]
        private ShootingDirections ShootingX;
        [SerializeField]
        private Shooting shot;

        bool canMove = true;

        public static PlayerMovement Instance;


   


    // Start is called before the first frame update
    void Start()
        {
            if(Instance != null){
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
            movementRb = GetComponent<Rigidbody2D>();
            WalkAnimation = GetComponent<Animator>();
            walkCol = GetComponent<BoxCollider2D>();
//            transform.position = startingPosition.initialValue;
           

        }


        private void FixedUpdate()
        {
            if (canMove)
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

        }

        void OnMove(InputValue movementValue)
        {

            movementInput = movementValue.Get<Vector2>();

        }


        void OnFire()
        {
            GetMouseValueAttackAnimation();
            
        }
        private IEnumerator DeactivateWeapon(float time)
        {

            yield return new WaitForSeconds(time);

            WalkAnimation.ResetTrigger("SwrdAttack");
            WalkAnimation.ResetTrigger("StaffShoot");

        }

        private void GetMouseValueAttackAnimation()
        {
            Looking = Mouse.current.position.ReadValue();
            Looking = Camera.main.ScreenToWorldPoint(Looking);
            Looking = (Looking - transform.position).normalized;
            WalkAnimation.SetFloat("XMouse", Looking.normalized.x);
            WalkAnimation.SetFloat("YMouse", Looking.normalized.y);
            if(WalkAnimation.GetBool("Melee Weapon"))
            {
                WalkAnimation.SetTrigger("SwrdAttack");
                StartCoroutine(DeactivateWeapon(1));
            }
            if (WalkAnimation.GetBool("projectile Weapon"))
            {
                WalkAnimation.SetTrigger("StaffShoot");
                StartCoroutine(DeactivateWeapon(1));
            }
        }


        public void attackHorizontal()
        {
            LockMovement();

            if (Mathf.Abs(Looking.normalized.x) > Mathf.Abs(Looking.normalized.y))
            {
                    SwrdAttackX.AttackHorizontal();
                
            }
            else
            {
                SwrdAttackY.AttackVertical();
            }
                    
                

        }
        public void Staff()
        {
            LockMovement();

            if (Mathf.Abs(Looking.normalized.x) > Mathf.Abs(Looking.normalized.y))
            {
                ShootingX.AttackHorizontal();
                shot.fire();
            }
            else
            {
                ShootingX.AttackVertical();
                shot.fire();
            }
            
        }

        public void LockMovement()
        {
            canMove = false;
        }

        public void UnlockMovement()
        {
            canMove = true;
            

            if (WalkAnimation.GetBool("Melee Weapon"))
            {
                SwrdAttackX.StopAttack();
                SwrdAttackY.StopAttack();
            }
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
