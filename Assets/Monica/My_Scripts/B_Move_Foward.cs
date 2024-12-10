using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonicaBoss
{

    public class B_Move_Foward : StateMachineBehaviour
    {
        Boss boss;
        float time = 0;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

            boss = FindObjectOfType<Boss>();
            animator.ResetTrigger("Move Foward");

        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            float distanceToTarget = Vector3.Distance(boss.transform.position, boss.Target.position);

            if (distanceToTarget < boss.HitDistance)
            {
                animator.SetTrigger("Hit");
                return;
            }
            animator.SetBool("Shooting Range", distanceToTarget < boss.MaxShootDistance && distanceToTarget > boss.MinShootDistance);
            time = Time.deltaTime;
            if (time > 7.0f)
            {
                time = 0;
                animator.SetInteger("Bullets", 5);
            }
            Vector3 directionToTarget = boss.Target.position - boss.Target.transform.position;
            directionToTarget.y = 0;
            

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
    }
}
