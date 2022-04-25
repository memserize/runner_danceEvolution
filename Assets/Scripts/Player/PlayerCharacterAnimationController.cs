using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class PlayerCharacterAnimationController : MonoBehaviour
{
    [Space]
    public int currentYear = 1901;

    [Space]
    public Animator animator;

    [Space]
    public DanceStyle[] danceStyles;


    [Button]
    public void PopulateDanceStyleArray()
    {
        List<DanceStyle> danceStylesList = new List<DanceStyle>();

        for (int i = 0; i < animator.parameters.Length; i++)
        {
            DanceStyle danceStyle = new DanceStyle();
            danceStyle.id = animator.parameters[i].name;

            danceStylesList.Add(danceStyle);
        }

        danceStyles = danceStylesList.ToArray();
    }


    public DanceStyle GetDanceStyle()
    {
        DanceStyle danceStyle = new DanceStyle();

        for (int i = 0; i < danceStyles.Length; i++)
        {
            if(currentYear > danceStyles[i].dancePeriod.yearRangeMin && currentYear < danceStyles[i].dancePeriod.yearRangeMax)
            {
                danceStyle = danceStyles[i];
                return danceStyle;
            }
        }
        return danceStyle;
    }


    public void SetDanceStyle()
    {
        animator.SetTrigger(GetDanceStyle().id);
    }

    public void SetAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
    }

}


[System.Serializable]
public class DanceStyle
{
    public string id;
    [Space]
    public DancePeriod dancePeriod;

}

[System.Serializable]
public class DancePeriod
{
    public int yearRangeMin;
    public int yearRangeMax;
}

