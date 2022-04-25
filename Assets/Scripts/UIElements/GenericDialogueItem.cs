using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

[RequireComponent(typeof(RectTransform))]

public class GenericDialogueItem : MonoBehaviour
{
    [HideInInspector]
    public bool isOpen;
    public bool autoClose;
    public bool startOpen;

    [Space]
    public bool animateMovement;
    public float movementDuration;

    [Space]
    public string dialogueId;
    public string dialogueGroupId;


    [Space]
    public CanvasGroup dialogue;

    [Space]
    public Ease ease;
    [Space]
    public Vector2 defaultPosition;
    public Vector2 editPosition;
    [Space]
    public float fadeSpeed;

    [Space]
    public Vector2 animateEndPosition;

    [Space]
    public UnityEvent onShow;
    public UnityEvent onHide;

    private void Start()
    {
        if (startOpen)
        {
            ShowDialogue();
        }
        else
        {
            dialogue.alpha = 0;
            dialogue.interactable = false;
            dialogue.blocksRaycasts = false;
            SetDefaultPosition();
        }
    }

    [Button("▼ Set Default Position")]
    public void SetDefaultPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = defaultPosition;
    }


    [Button("▲ Set Edit position")]
    public void SetEditPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = editPosition;
    }

    [Button("♦ Set current position as default position")]
    public void SetAsDefaultPosition()
    {
        defaultPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    [Button("♦ Set current position as Edit position")]
    public void SetAsEditPosition()
    {
        editPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    [Button("Runtime Show")]
    public void ShowDialogue()
    {
        StartCoroutine(Show());

        if(animateMovement)
        {
            GetComponent<RectTransform>().DOAnchorPos(animateEndPosition, movementDuration).SetEase(Ease.OutBack, 2);
        }

        if (autoClose)
        {
            StartCoroutine(AutoClose());
        }
    }

    [Button("Runtime Hide")]
    public void HideDialogue()
    {
        StartCoroutine(Hide());

        if (animateMovement)
        {
            GetComponent<RectTransform>().DOAnchorPos(defaultPosition, movementDuration).SetEase(Ease.OutBack, 2);
        }
    }

    [Button("Toggle Visibility")]
    public void ToggleEditorVisibility()
    {
        if (dialogue.alpha == 1)
        {
            dialogue.alpha = 0;
        }
        else
        {
            dialogue.alpha = 1;
        }
    }

    IEnumerator AutoClose()
    {
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(Hide());
    }

    IEnumerator Show()
    {
        yield return dialogue.DOFade(1, fadeSpeed).SetUpdate(true).SetEase(ease);
        isOpen = true;
        dialogue.interactable = true;
        dialogue.blocksRaycasts = true;

        onShow.Invoke();
    }

    IEnumerator Hide()
    {
        yield return dialogue.DOFade(0, fadeSpeed).SetUpdate(true).SetEase(ease);
        isOpen = false;
        dialogue.interactable = false;
        dialogue.blocksRaycasts = false;

        onHide.Invoke();
    }



}
