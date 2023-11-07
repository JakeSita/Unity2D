using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_attack : StateMachineBehaviour
{
    BoxCollider2D AOE;
    HealthSystem hp;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AOE = animator.GetComponentInChildren<BoxCollider2D>();
        hp = animator.GetComponentInParent<HealthSystem>();
        AOE.enabled = true;
        animator.SetTrigger("Idle");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AOE.enabled = false;
        hp.enabled = true;
        animator.ResetTrigger("Slam Attack");
    }
}
