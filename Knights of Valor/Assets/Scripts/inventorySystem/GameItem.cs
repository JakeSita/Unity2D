using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace inventorySystem
{

    public class GameItem : MonoBehaviour
    {
        [SerializeField]
        private ItemStack _stack;
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private Rigidbody2D _rb;

        [Header("Throw Settings")]
        [SerializeField]
        private float _colliderEnabledAfter = 1f;
        [SerializeField]
        public float _throwGravity = 2f;
        [SerializeField]
        private float _minXandYForce = 1f;
        [SerializeField]
        private float _maxXandYForce = 3f;
        [SerializeField]
        private float _throwYForce = 2f;
        

        public ItemStack Stack => _stack;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _collider.enabled = false;
        }

        private void Start()
        {
            SetUpGameObject();
            StartCoroutine(EnableCollider(_colliderEnabledAfter));
        }

        private void OnValidate()
        {
            SetUpGameObject();
        }

        public void Throw(float Xdir, float Ydir)
        {
            Debug.Log(Xdir);
            _rb.gravityScale = _throwGravity;
            var throwXForce = Random.Range(_minXandYForce, _maxXandYForce);
            if (Ydir != 0 && Xdir == 0)
            {
                StartCoroutine(StartThrow(Ydir));
            }
            else
            {
                _rb.velocity = new Vector2(Mathf.Sign(Xdir) * throwXForce, _throwYForce);
                StartCoroutine(DisableGravity(_throwYForce));
            }
            
        }

        

        private IEnumerator DisableGravity(float atYVelocity)
        {
            
            yield return new WaitUntil(() => _rb.velocity.y < -atYVelocity );
            _rb.velocity = Vector2.zero;
            _rb.gravityScale = 0;
            Debug.Log("Gravity on " + _rb.velocity);
        }


        private IEnumerator StartThrow(float Ydir)
        {
            _rb.gravityScale = 0;
            float initialYPosition = transform.position.y;
            _rb.velocity = new Vector2(_rb.velocity.x, (Mathf.Sign(Ydir) * _throwYForce));


            while (true)
            {
                // Calculate the current Y position relative to the initial position
                float currentYPosition = transform.position.y - initialYPosition;

                // Check if the desired Y distance (_distanceThrown) is reached
                if (Mathf.Abs(currentYPosition) >= .8)
                {
                    // Start the StopThrow coroutine
                    _rb.velocity = Vector2.zero;
                    break; // Exit the loop
                }

                yield return null; // Yield to the next frame
            }
        }

        private IEnumerator StopThrow(float distance, float Ydir)
        {

            yield return new WaitWhile(() => transform.position.y < transform.position.y + (Mathf.Sign(Ydir) * distance));
            _rb.velocity = Vector2.zero;
        }

        private void SetUpGameObject()
        {
            if (_stack.Item == null) return;
            SetGameSprite();
            AdjustNumberOfItems();
            UpdateGameObjectName();
           
            

        }

        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        private void UpdateGameObjectName()
        {
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "ns";
            gameObject.name = $"{name} ({number})";
        }

        private void AdjustNumberOfItems()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }

        public ItemStack Pick()
        {
            Destroy(gameObject);
            return _stack;
        }

        private IEnumerator EnableCollider(float afterTime)
        {
            yield return new WaitForSeconds(afterTime);
            _collider.enabled = true;
        }

        public void SetStack(ItemStack itemStack)
        {
            _stack = itemStack;
        }

    }
}
