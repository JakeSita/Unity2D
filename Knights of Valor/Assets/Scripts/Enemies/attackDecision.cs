using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class attackDecision : StateMachineBehaviour
{
    NavMeshAgent ai;
    AIBrain2D brain;
    private int decision;
    public GameObject Spawner;
    private Transform BossShoot;
    private int counter = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.GetComponent<NavMeshAgent>();
        brain = animator.GetComponent<AIBrain2D>();
        BossShoot = animator.GetComponentInChildren<Transform>();

        animator.ResetTrigger("Move");
        animator.ResetTrigger("Slam Attack");
        animator.ResetTrigger("Idle");
        ai.isStopped = true;
        decision = Random.Range(0, 3);
        Debug.Log(decision);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (brain.hunt)
        {
            switch (decision)
            {

                case 0:
                    animator.ResetTrigger("Move");
                    animator.SetTrigger("Slam Attack");
                    break;

                case 1:
                    ai.isStopped = false;
                    animator.SetTrigger("Move");
                    break;

                case 2:
                    counter++;
                    if (counter == 1)
                    {
                        Debug.Log("Spawning one enemy");
                        Instantiate(Spawner, BossShoot.position, Quaternion.identity);
                        counter = 0;
                    }
                    break;


                default:
                    decision = Random.Range(0, 3);
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
