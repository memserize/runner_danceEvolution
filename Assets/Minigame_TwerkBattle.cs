using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame_TwerkBattle : MonoBehaviour
{
    
    public void Initalize()
    {
        Registry.Instance.refrences.player.animationController.animator.SetTrigger("idle");
    }


}
