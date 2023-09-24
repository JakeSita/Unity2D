using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    private float _healthMax              = 10;
    private float _healthCur              = 10;
    private float _invincibilityFrameMax  = 1;
    private float _invicibilityFramesCurr = 0;
    private bool _isdead                  = false;


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
            Destroy(gameObject);
        }
        
    }


    public float adjustCurrentHealth(float change) {
        if (_invicibilityFramesCurr > 0)
            return _healthCur;

        _healthCur += change;

        if(_healthCur <= .01f)
            onDeath();
        
        else if(_healthCur > _healthMax)
            _healthCur = _healthMax;

        if (change <= 0 && _invincibilityFrameMax > 0)
            _invicibilityFramesCurr = _invincibilityFrameMax;


        return _healthCur;
        
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
