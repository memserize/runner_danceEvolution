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
    public string currentAnim;
    public Animator animator;

    [Space]
    public int index;
    public DanceStyle[] danceStyles;


    private void Start()
    {
        currentDate = new DateTime(1900, 1, 1);
        date = currentDate.ToString();
    }


    public void UpdateDate(DateTime dateTime)
    {
        currentDate = dateTime;
        date = currentDate.ToString();

        Registry.Instance.refrences.player.calender.dateText.text = currentDate.Year.ToString();
        SetDanceStyle();
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


    public DanceStyle GetDanceStyle(int year)
    {
        DanceStyle danceStyle = new DanceStyle();

        for (int i = 0; i < danceStyles.Length; i++)
        {
            if (year > danceStyles[i].dancePeriod.yearRangeMin && year < danceStyles[i].dancePeriod.yearRangeMax)
            {
                danceStyle = danceStyles[i];
                return danceStyle;
            }
        }
        return danceStyle;
    }


    public void SetDanceStyle()
    {
        Registry.Instance.refrences.player.swirlEffect.PlayEffect();
        Registry.Instance.refrences.player.SetPlayerCharacter();
        SetAnimation(GetDanceStyle(currentDate.Year).id);

        Registry.Instance.refrences.crowdManager.UpdateCharacters();

        if (Registry.Instance.refrences.player.collectedCharacters.Count > 0)
        {
            for (int i = 0; i < Registry.Instance.refrences.player.collectedCharacters.Count; i++)
            {
                Registry.Instance.refrences.player.collectedCharacters[i].variations[Registry.Instance.refrences.player.collectedCharacters[i].index].
                    GetComponent<Animator>().SetTrigger(Registry.Instance.refrences.player.animationController.currentAnim);
            }
        }
    }


    public void UpdateCollectedCharacterAnimators()
    {
        for (int i = 0; i < Registry.Instance.refrences.player.collectedCharacters.Count; i++)
        {
            Registry.Instance.refrences.player.collectedCharacters[i].UpdateCharacter(true);
        }
    }



    public void SetAnimation(string trigger)
    {
        animator.SetTrigger(trigger);
        currentAnim = trigger;
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

