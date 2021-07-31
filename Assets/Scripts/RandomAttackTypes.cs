using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAttackTypes : StateMachineBehaviour
{
    public string attackType_param = "type";
    public int[] attackTypes_param = { 0, 1, 2 };
    private AnimationClip[] clips;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log("StateMove");
        
    }

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {

        animator.SetBool("isAttacking", false);

        int index = Random.Range(0, attackTypes_param.Length);
        
        animator.SetInteger(attackType_param, index);
    
     



    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
       
    }

    private IEnumerator PlayRandomly(Animator animator)
    {
        while (true)
        {
            var randInd = Random.Range(0, clips.Length);

            var randClip = clips[randInd];

            animator.Play(randClip.name);

            // Wait until animation finished than pick the next one
            yield return new WaitForSeconds(randClip.length);
        }
    }


}
