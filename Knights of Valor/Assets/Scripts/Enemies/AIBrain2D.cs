using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class AIBrain2D : MonoBehaviour
{
    #region **members**

    public UnityEvent _curAIDirective;

    [SerializeField]
    UnityEvent _defaultAction;

    [SerializeField]
    UnityEvent _alertedAction;

    [SerializeField]
    public UnityEvent _huntAction;

    [SerializeField]
    public UnityEvent _miscPattern1Actions;
    public UnityEvent _miscPattern2Actions;
    public UnityEvent _miscPattern3Actions;

    float _pauseTimer = 0f;

    float Distance = 0;

    public GameObject bulletPrefab;
    public Transform ShotPos;

    private PlayerMovement _playerObject = null;

    Animator anime;

    public bool isFiring = false;

    NavMeshAgent agent;

    private float timer;

    [SerializeField]
    private float TargetRange = 7f;
    [SerializeField]
    private float FireRate = 2f;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _playerObject = FindObjectOfType<PlayerMovement>();
        _curAIDirective = _defaultAction;
        anime = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdatePausedAI())
            return;

        _curAIDirective.Invoke();

        //clock -= Time.deltaTime;
        timer += Time.deltaTime;


        if (Distance > CalcDistanceToPlayer())
            SetState_Default();
    }

    bool UpdatePausedAI()
    {
        if (_pauseTimer > 0)
        {
            _pauseTimer -= Time.deltaTime;
            _pauseTimer = Mathf.Max(_pauseTimer, 0f);
        }
        return (bool)(_pauseTimer > 0f);
    }
    

    #region **AI States**
    public void SetState_Default()
    {
        _curAIDirective = _defaultAction;
        anime.SetBool("IsRunning", false);
    }

    public void SetState_Hunt()
    {
        _curAIDirective = _huntAction;
    }

    public void SetState_MiscPattern(int Pattern)
    {
        // Your logic for changing AI patterns here (if needed)
    }

    #endregion

    #region **AI Events**
    public void AlertIFPlayerNearby(float Distance)
    {

        if (CalcDistanceToPlayer() < Distance)
            _alertedAction?.Invoke();
    }

    public void PauseAi(float timeInMS)
    {
        _pauseTimer = timeInMS;
    }

    public void OutofRange()
    {
        if(CalcDistanceToPlayer() > TargetRange)
        {
            SetState_Default();
        }
    }

    public void UseWeapon()
    {
        if (CalcDistanceToPlayer() < 8f && timer > FireRate)
        {
            timer = 0;
            var Bullet = Instantiate(bulletPrefab, ShotPos.position, Quaternion.identity);
            Destroy(Bullet, 10f);

        }
   
    }

    public void Jump(float force)
    {
        GetComponent<Rigidbody2D>()?.AddForce(new Vector2(0, force));
    }

    #endregion

    #region **Player Hunting**

    public float CalcDistanceToPlayer()
    {
        
        return Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(_playerObject.transform.position.x, _playerObject.transform.position.y));
    }

    public Vector2 CalcPlayerPos(bool ignoreY = false)
    {
        Vector2 playerPos = new Vector2(_playerObject.gameObject.transform.position.x, _playerObject.gameObject.transform.position.y);
        if (ignoreY)
            playerPos.y = transform.position.y;
        return playerPos;
    }

    public void LookAtPlayer()
    {
        
    }

    public void MoveTowardsPlayer(float Speed)
    {
       
            Vector2 playerPos = CalcPlayerPos();
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y);
            playerPos.y += .5f;
            Vector2 moveDirection = (playerPos - newPos).normalized * (Speed * Time.deltaTime);
            newPos += moveDirection;
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
            anime.SetFloat("x", moveDirection.x);
            anime.SetFloat("y", moveDirection.y);
            anime.SetBool("IsRunning", true);
    }

    public void MoveTowardsPlayerUsingNavMesh()
    {
        

        if (agent)
        {
            agent.SetDestination(_playerObject.transform.position);
            anime.SetFloat("x", agent.velocity.x);
            anime.SetFloat("y", agent.velocity.y);
            anime.SetBool("IsRunning", true);
            if (Distance > CalcDistanceToPlayer())
                agent.isStopped = true;
            else
                agent.isStopped = false;
        }
    }

   

    #endregion
}

