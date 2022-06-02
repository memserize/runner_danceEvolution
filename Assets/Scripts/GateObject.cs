using System.Collections.Generic;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine;
using System;
using TMPro;

public class GateObject : MonoBehaviour
{
    public enum Period {Days, Months, Years};

    public Period period;

    [Space]
    public float distanceToPlayer;

    [Space]
    public Transform canvas;

    [Space]
    public int gateValue;
    public TextMeshProUGUI gateText;

    [Space]
    public UnityEvent onGatePass;

    bool calculateDistance;

    private void Start()
    {
        canvas = transform.GetChild(4).transform;

        if (gateValue > 0)
        {
            gateText.text = " + " + gateValue + " " + period;

        }

        calculateDistance =  true;
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
            StartCoroutine(Registry.Instance.refrences.player.animationController.UpdateCollection());

            if (Registry.Instance.refrences.player.collectedCharacters.Count > 0)
            {
                for (int i = 0; i < Registry.Instance.refrences.player.collectedCharacters.Count; i++)
                {
                    Registry.Instance.refrences.player.collectedCharacters[i].ChangeCharacter();
                }
            }

            FadeOutText();
            onGatePass.Invoke();
        }
    }


    private void Update()
    {
        if(calculateDistance)
        {
            distanceToPlayer = Vector3.Distance(Registry.Instance.refrences.player.transform.position, transform.position);

            if (canvas.localPosition.z != 0)
            {
                if (distanceToPlayer <= canvas.localPosition.z)
                {
                    canvas.localPosition = new Vector3(0, 0.4f, (distanceToPlayer));
                }
            }
        }
    }

    public void FadeOutText()
    {
        canvas.GetComponent<CanvasGroup>().DOFade(0, 1);
        calculateDistance = false;

    }


}
