using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCharacter : MonoBehaviour
{
    public Animator currentAnimator;

    [Space]
    public SwirlEffect swirlEffect;

    [Space]
    public int index;

    [Space]
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

        if (index < 3)
        {
            variations[index].GetComponent<RandomMaterial>().AssignMaterials();

        }

        currentAnimator = variations[index].GetComponent<Animator>();

        variations[index].GetComponent<AnimationControllerAssigner>().SetAnimator();

        if (playEffect)
        {
            swirlEffect.PlayEffect();
        }
    }
}
