using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFeedback : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Para iniciar las partículas al caminar
        // animator.gameObject.GetComponent<EnemyController>().PlayDust();
        // animator.gameObject.SendMessage("PlayDust");
        animator.gameObject.SendMessage("PlayDust", SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Entrando a locomotion");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // animator.gameObject.GetComponent<EnemyController>().StopDust();
        // animator.gameObject.SendMessage("StopDust");
        animator.gameObject.SendMessage("StopDust", SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Saliendo de locomotion");
    }

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
