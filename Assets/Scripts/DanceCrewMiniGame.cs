using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DanceCrewMiniGame : MonoBehaviour
{
    public bool initialized;
    [Space]
    public CollectableCharacterSpawner[] dancers;

    public void MoveToCenter()
    {
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("walking");
    }


    public void StopMovement ()
    {
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("idle");
        Registry.Instance.refrences.player.movementController.initialized = false;

        MoveCrewMembers();

        Registry.Instance.refrences.player.currentCharacterIndex++;
        Registry.Instance.refrences.player.animationController.currentAnim = "thriller";
    }


    public void MoveCrewMembers()
    {
        for (int i = 0; i < dancers.Length; i++)
        {
            dancers[i].character.index = 4;
            dancers[i].character.SetWalkAnim();
            dancers[i].GetComponent<SWS.splineMove>().StartMove();
        }
    }


    public void StartDance()
    {
        for (int i = 0; i < dancers.Length; i++)
        {
            dancers[i].character.index = 4;
            dancers[i].character.UpdateCharacter(true);

            dancers[i].character.ChangeAnimator();
        }

        Registry.Instance.refrences.player.swirlEffect.PlayEffect();
        Registry.Instance.refrences.player.SetPlayerCharacter();
        Registry.Instance.refrences.player.animationController.SetAnimation("thriller");

        Registry.Instance.refrences.crowdManager.UpdateCharacters();

        if (Registry.Instance.refrences.player.collectedCharacters.Count > 0)
        {
            StartCoroutine(Registry.Instance.refrences.player.animationController.UpdateCollection());
        }

        Registry.Instance.refrences.player.movementController.forwardMovementSpeed = 1.2f;
        Registry.Instance.refrences.player.movementController.initialized = true;
    }


    public void CheckCharacterSlotIndex()
    {
        if (Registry.Instance.refrences.player.characterSlotIndex == 3)
        {
            StartDance();
        }
    }
}
