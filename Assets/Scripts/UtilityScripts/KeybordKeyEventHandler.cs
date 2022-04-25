using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class KeybordKeyEventHandler : MonoBehaviour
{
    public KeyBordKeyEvent[] keyEvents;

    protected List<KeyCode> m_activeInputs = new List<KeyCode>();

    public void Update()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    m_activeInputs.Remove(code);
                    m_activeInputs.Add(code);
                    pressedInput.Add(code);

                    //Debug.Log(code + " was pressed");
                    for (int i = 0; i < keyEvents.Length; i++)
                    {
                        if(code == keyEvents[i].key)
                        {
                            keyEvents[i].gameEvent.Invoke();
                        }
                    }
                }
            }
        }

        List<KeyCode> releasedInput = new List<KeyCode>();

        foreach (KeyCode code in m_activeInputs)
        {
            releasedInput.Add(code);

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " was released");
            }
        }

        m_activeInputs = releasedInput;
    }


}

[System.Serializable]
public class KeyBordKeyEvent
{
    public KeyCode key;

    [Space]
    public UnityEvent gameEvent;

    [Space]
    [Multiline]
    public string eventDescription;

}