using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEventHandler : MonoBehaviour
{
    public AnimationEvent[] animationEvents;

    public void OnAnimationEvent(string eventID)
    {
        for (int i = 0; i < animationEvents.Length; i++)
        {
            if(animationEvents[i].id == eventID)
            {
                animationEvents[i].onAnimationEvent.Invoke();
            }
        }
    }

}

[System.Serializable]
public class AnimationEvent
{
    public string id;
    public UnityEvent onAnimationEvent;

}
