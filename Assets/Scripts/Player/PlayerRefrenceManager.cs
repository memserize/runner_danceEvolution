using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PlayerRefrenceManager : MonoBehaviour
{

    [Title("Controllers")]
    public PlayerCharacterAnimationController animationController;
    public PlayerMovementController movementController;

    [Title("UI Elements")]
    public CalenderUIElement calender;

    [Space]
    public SwirlEffect swirlEffect;

    [Space]
    public int characterSlotIndex;
    public Transform[] characterSlotTransforms;

    [Space]
    public int currentCharacterIndex;
    public PlayerCharacter currentCharacter;

    [Space]
    public List<PlayerCharacter> playerCharacters = new List<PlayerCharacter>();
    public List<CollectableCharacter> collectedCharacters = new List<CollectableCharacter>();
    

    public void SetPlayerCharacter()
    {
        for (int i = 0; i < playerCharacters.Count; i++)
        {
            playerCharacters[i].gameObject.SetActive(false);
        }
        
        currentCharacter = playerCharacters[currentCharacterIndex];
        currentCharacter.gameObject.SetActive(true);
        animationController.animator = currentCharacter.animator;
    }



}
