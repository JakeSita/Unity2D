using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class idleMovement : StateMachineBehaviour
{

    AIBrain2D brain;
    NavMeshAgent movement;
    private float laserShot = 6f;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        brain = animator.GetComponent<AIBrain2D>();
        movement = animator.GetComponent<NavMeshAgent>();
        movement.isStopped = false;
        timer = laserShot;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (brain.hunt)
        {
            timer -= Time.deltaTime;
            if (brain.CalcDistanceToPlayer() < 2)
            {
                animator.SetTrigger("ArmShoot");
            }


            if (timer < 0)
            {
                animator.SetTrigger("ChargeBeam");
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
