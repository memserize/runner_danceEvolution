using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MeterObject : MonoBehaviour
{
    public Transform needle;
    Tween tween;

    public void Start()
    {
        Tween();
    }

    public void Tween()
    {
        //tween = needle.DOLocalRotate(new Vector3(0, 0, 45), 1).SetLoops(-1, LoopType.Yoyo);
        tween = needle.DOLocalRotate(new Vector3(0, 0, 45), 1).SetLoops(3, LoopType.Yoyo).OnComplete(StopMeter);

    }

    public void StopMeter()
    {
        tween.Pause();
        needle.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
    }

    public void PlayMeter()
    {
        tween.Play();
    }
}
