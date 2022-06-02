using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CollectableCharacter : MonoBehaviour
{
    public Animator currentAnimator;

    [Space]
    public SwirlEffect swirlEffect;

    [Space]
    public int index;

    [Space]
    public bool lockTransform;
    public GameObject[] variations;


    [Space]
    public Transform lookAtTarget;


    private void Start()
    {
        UpdateCharacter(false);
    }


    public void ChangeCharacter()
    {
        index++;
        UpdateCharacter(true);
    }


    public void UpdateCharacter(bool playEffect)
    {
        for (int i = 0; i < variations.Length; i++)
        {
            variations[i].SetActive(false);
        }

        variations[index].SetActive(true);

        if (variations[index].GetComponent<AnimationControllerAssigner>())
        {
            variations[index].GetComponent<AnimationControllerAssigner>().SetAnimator();
        }

        if (playEffect)
        {
            swirlEffect.PlayEffect();
        }



    }

    private void Update()
    {
        if(lockTransform)
        {
            for (int i = 0; i < variations.Length; i++)
            {
                variations[i].transform.localPosition = new Vector3();
                variations[i].transform.eulerAngles = new Vector3();
            }
        }

    }

    [Button]
    public void ChangeAnimator()
    {
        for (int i = 0; i < variations.Length; i++)
        {
            Destroy(variations[i].GetComponent<AnimationControllerAssigner>());
        }

        for (int i = 0; i < variations.Length; i++)
        {
           variations[i].GetComponent<Animator>().runtimeAnimatorController = Registry.Instance.refrences.player.animationController.animator.runtimeAnimatorController;
        }
    }


    public void SetWalkAnim()
    {
        variations[index].GetComponent<AnimationControllerAssigner>().animator.SetBool("iswalking", true);
    }
}
