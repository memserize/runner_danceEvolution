using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Forever;

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
            refrences.levelGenerator.StartGeneration();

            refrences.player.foreverBasicRunner.followSpeed = 2;
            refrences.player.animationController.SetAnimation("walking");
            gameRunning = true;
        }
    }
    
}
