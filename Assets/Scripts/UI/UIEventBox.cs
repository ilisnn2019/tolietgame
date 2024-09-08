using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIEventBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI t_EventName;

    public bool IsActive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }

    private InteractiveEvent targetInteractive;

    public void ActiveEventBox(InteractiveEvent interactiveEvent)
    {
        gameObject.SetActive(true);
        t_EventName.text = interactiveEvent.eventName;
        targetInteractive = interactiveEvent;

    }

    public void UpdateEventBox(string eventName)
    {
        t_EventName.text = eventName;
    }

    public void DisactiveEventBox()
    {
        gameObject.SetActive(false);
    }

    public void EventBtnClick()
    {
        targetInteractive.eventContent();
    }
}
