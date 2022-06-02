using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class AnimationControllerAssigner : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController[] runtimeAnimatorControllers;

    [Space]
    public UnityEvent onEnable;


    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void Start()
    {
        SetAnimator();
    }

    public void SetAnimator()
    {
       animator.runtimeAnimatorController = runtimeAnimatorControllers[Random.Range(0, runtimeAnimatorControllers.Length)];
    }


}
