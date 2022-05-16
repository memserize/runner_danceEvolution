using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;

public class PlayerCharacter : MonoBehaviour
{
    public Animator animator;

    [Space]
    public Material[] characterMaterials;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        transform.localPosition = new Vector3(0, -0.679f, 0);
    }
}
