using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameRunning;


    Refrences refrences;

    private void Start()
    {
        refrences = Registry.Instance.refrences;
    }

    public void StartLevel()
    {
        if (!gameRunning)
        {
            refrences.player.movementController.Initalize();
            refrences.player.SetPlayerCharacter();
            refrences.player.animationController.SetAnimation("walking");

            refrences.crowdManager.Initialize();
            gameRunning = true;
        }
    }
    
}
