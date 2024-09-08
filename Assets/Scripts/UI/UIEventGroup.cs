using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIEventGroup : MonoBehaviour
{
    const int EVENTBOX_NUMBER = 8;

    private Canvas _canvas;

    private static UIEventGroup _instance;

    [SerializeField]
    private UIEventBox[] instanceUIEventBoxes = new UIEventBox[8];

    private void Awake()
    {
        // 인스턴스 초기화
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _canvas = GetComponent<Canvas>();

        DisactiveEventBoxes();
    }

    public static void UpdateEventBoxes(List<InteractiveEvent> interactiveEvents)
    {
        for (int iEvent = 0; iEvent < EVENTBOX_NUMBER; ++iEvent)
        {
            _instance.instanceUIEventBoxes[iEvent].UpdateEventBox(interactiveEvents[iEvent].eventName);
           
        }
    }

    public static void ActiveEventBoxes(List<InteractiveEvent> interactiveEvents)
    {
        _instance._canvas.enabled = true;
        for (int iEvent = 0; iEvent < EVENTBOX_NUMBER; ++iEvent)
        {
            if (interactiveEvents.Count > iEvent)
                _instance.instanceUIEventBoxes[iEvent].ActiveEventBox(interactiveEvents[iEvent]);
            else
                _instance.instanceUIEventBoxes[iEvent].DisactiveEventBox();
        }
    }



    public static void DisactiveEventBoxes()
    {
        _instance._canvas.enabled = false;
    }
}


[CustomEditor(typeof(UIEventGroup))]
public class UIEventGroupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector first
        DrawDefaultInspector();

    }
}

