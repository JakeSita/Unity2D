using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using inventorySystem;
public class HealthSystem : MonoBehaviour
{
    public GameObject FloatingTextPrefab;
    private GameObject floatingNumber;
    public float _healthMax              = 10;
    public float _healthCur              = 10;
    [SerializeField]
    private float _invincibilityFrameMax  = 1;
    [SerializeField]
    private float _invicibilityFramesCurr = 0;
    private bool _isdead                  = false;

    private Rigidbody2D rb;

    private GameSessionManager GameManager;

    private Inventory _inventory;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _inventory = GetComponent<Inventory>();
        if(tag == "Player")
            GameManager = GameObject.Find("GameManager").GetComponent<GameSessionManager>();
    }

    void Update()
    {
        if (_invicibilityFramesCurr > 0)
        {
            _invicibilityFramesCurr -= Time.deltaTime;

            if (_invicibilityFramesCurr < 0)
            {
                _invicibilityFramesCurr = 0;
            }
        }


        if (isDead())
        {
            if(gameObject.tag == "enemy")
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, true);
                Destroy(gameObject);
            }
            if(gameObject.tag == "Player")
            {
                rb.gameObject.GetComponent<PlayerMovement>().LockMovement();
                GameManager.RespawnScreen(true);
            }
        }
        
    }


    public float adjustCurrentHealth(float change, Vector2 direction) {
        if (_invicibilityFramesCurr > 0)
            return _healthCur;

        _healthCur += change;
        if (FloatingTextPrefab)
        {

            ShowFloatingText(change);
        }
        Debug.Log(_healthCur);
        rb.isKinematic = false;


        rb.velocity = Vector2.zero;
        rb.AddForce(direction, ForceMode2D.Impulse);
        rb.drag = 20f;
        StartCoroutine(EndKnockback(1));



        if (_healthCur <= .01f)
            onDeath();
        
        else if(_healthCur > _healthMax)
            _healthCur = _healthMax;

        if (change <= 0 && _invincibilityFrameMax > 0)
            _invicibilityFramesCurr = _invincibilityFrameMax;


        return _healthCur;
        
    }

    private void ShowFloatingText(float change)
    {
        floatingNumber = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
        floatingNumber.transform.GetChild(0).GetComponent<TextMeshPro>().text = change.ToString();

        
    }

    private IEnumerator EndKnockback(float knockbackDuration)
    {
        yield return new WaitForSeconds(knockbackDuration);

        // Re-enable kinematic after knockback is complete
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
   

    void onDeath()
    {
        if (_healthCur > 0)
        {
            Debug.Log(gameObject.name + " set as dead before health");
        }
        _isdead = true;
    }
    public bool isDead()
    {
        return _isdead;
    }

    public void Reset()
    {
        _isdead = false;
        _healthCur = _healthMax;
        _invicibilityFramesCurr = 0;
    }


    
}
