using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomAnimTrap : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        animator.SetInteger("randAnim", Random.Range(0, 2));
    }
}
