using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using System;
using TMPro;

public class GateObject : MonoBehaviour
{
    public enum Period {Days, Months, Years};

    public Period period;

    [Space]
    public int gateValue;
    public TextMeshProUGUI gateText;

    private void Start()
    {
        period = Registry.Instance.refrences.gatesValueAssigner.gateValues[Registry.Instance.refrences.gatesValueAssigner.index].period;
        gateValue = Registry.Instance.refrences.gatesValueAssigner.gateValues[Registry.Instance.refrences.gatesValueAssigner.index].value;
        Registry.Instance.refrences.gatesValueAssigner.index++;
        gateText.text = gateValue + " " + period;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Collider>().enabled = false;

            switch (period)
            {
                case Period.Days:
                    Registry.Instance.refrences.player.animationController.currentDate = Registry.Instance.refrences.player.animationController.currentDate.AddDays(gateValue);
                    break; 
                case Period.Months:
                    Registry.Instance.refrences.player.animationController.currentDate = Registry.Instance.refrences.player.animationController.currentDate.AddMonths(gateValue);
                    break;
                case Period.Years:
                    Registry.Instance.refrences.player.animationController.currentDate = Registry.Instance.refrences.player.animationController.currentDate.AddYears(gateValue);
                    break;
            }
            Registry.Instance.refrences.player.animationController.UpdateDate(Registry.Instance.refrences.player.animationController.currentDate);
        }
    }


}
