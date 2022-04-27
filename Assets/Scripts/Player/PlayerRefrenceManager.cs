using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Dreamteck.Forever;


public class PlayerRefrenceManager : MonoBehaviour
{
    public Runner foreverBasicRunner;

    [Title("Controllers")]
    public PlayerCharacterAnimationController animationController;
    public PlayerMovementController movementController;

    [Title("UI Elements")]
    public CalenderUIElement calender;

    [Space]
    public SwirlEffect swirlEffect;

}
