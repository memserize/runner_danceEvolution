using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
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
        if (gateValue > 0)
        {
            gateText.text = " + " + gateValue + " " + period;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gateValue > 0)
        {
            Registry.Instance.refrences.player.currentCharacterIndex++;
        }

        if (other.gameObject.tag == "Player")
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

    float distanceToPlayer;
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(Registry.Instance.refrences.player.transform.position, transform.position);

    }


}
