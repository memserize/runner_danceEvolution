using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

public class PlayerCharacterAnimationController : MonoBehaviour
{
    public string date;

    [Space]
    public DateTime currentDate;

    [Space]
    public Animator animator;

    [Space]
    public int index;
    public DanceStyle[] danceStyles;

    private void Start()
    {
        animator = danceStyles[index].character.animator;
        currentDate = new DateTime(1900, 1, 1);
        date = currentDate.ToString();
    }


    public void UpdateDate(DateTime dateTime)
    {
        currentDate = dateTime;
        date = currentDate.ToString();

        Registry.Instance.refrences.player.calender.dateText.text = currentDate.Year.ToString();

        print(currentDate.Year);
    }

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
            if(currentDate.Year > danceStyles[i].dancePeriod.yearRangeMin && currentDate.Year < danceStyles[i].dancePeriod.yearRangeMax)
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

    [Space]
    public PlayerCharacter character;

}

[System.Serializable]
public class DancePeriod
{
    public int yearRangeMin;
    public int yearRangeMax;
}

