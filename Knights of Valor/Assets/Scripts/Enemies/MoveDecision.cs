using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveDecision : StateMachineBehaviour
{

    NavMeshAgent ai;
    AIBrain2D brain;
    private int decision;
    public GameObject bulletPrefab;
    private Transform BossShoot;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.GetComponent<NavMeshAgent>();
        brain = animator.GetComponent<AIBrain2D>();
        BossShoot = animator.GetComponentInChildren<Transform>();
        animator.ResetTrigger("Move");
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Slam Attack");
        decision = Random.Range(0, 2);
        Debug.Log("Moving decision " + decision);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (brain.hunt)
        {
            switch (decision)
            {

                case 0:
                    var Bullet = Instantiate(bulletPrefab, BossShoot.position, Quaternion.identity);
                    Destroy(Bullet, 10f);
                    decision = Random.Range(0, 2);
                    break;

                case 1:
                    animator.SetTrigger("Slam Attack");
                    break;

                default:
                    decision = Random.Range(0, 2);
                    break;



            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
