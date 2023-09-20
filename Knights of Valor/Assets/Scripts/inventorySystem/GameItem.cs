using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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
        private float _minXForce = 1f;
        [SerializeField]
        private float _maxXForce = 3f;
        [SerializeField]
        private float _throwYForce = 1f;

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

        public void Throw(float xDir)
        {
            _rb.gravityScale = _throwGravity;
            var throwXForce = Random.Range(_minXForce, _maxXForce);
            _rb.velocity = new Vector2(Mathf.Sign(xDir) * throwXForce, _throwYForce);
            StartCoroutine(DisableGravity(_throwYForce));
        }

        private IEnumerator DisableGravity(float atYVeloctiy)
        {
            yield return new WaitUntil(() => _rb.velocity.y < -atYVeloctiy);
            _rb.velocity = Vector2.zero;
            _rb.gravityScale = 0;
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
