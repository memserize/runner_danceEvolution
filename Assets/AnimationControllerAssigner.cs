using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerAssigner : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController[] runtimeAnimatorControllers;

    private void Start()
    {
        SetAnimator();
    }

    public void SetAnimator()
    {
        animator.runtimeAnimatorController = runtimeAnimatorControllers[Random.Range(0, runtimeAnimatorControllers.Length)];
    }
}
