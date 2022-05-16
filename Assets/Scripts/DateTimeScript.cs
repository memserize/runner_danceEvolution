using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

public class DateTimeScript : MonoBehaviour
{
    [SerializeField] DateTime date;
    [SerializeField] string dateString;

    public int Days;
    public int Months;
    public int Years;

    private void Start()
    {
        date = new DateTime(2022, 1, 1);
        dateString = date.ToString();
    }

    [Button]
    public void AddYears()
    {
        date = date.AddYears(Years);
        dateString = date.ToString();
    }


    [Button]
    public void AddMonths()
    {
        date = date.AddMonths(Months);
        dateString = date.ToString();
    }


    [Button]
    public void AddDays()
    {
        date = date.AddDays(Days);
        dateString = date.ToString();
    }
}
