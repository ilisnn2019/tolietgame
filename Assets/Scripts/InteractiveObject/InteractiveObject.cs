using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IInteractive
{
    [HideInInspector]
    public List<InteractiveEvent> InteractiveEvents = new();

    [HideInInspector]
    public List<string> event_name = new();

    [HideInInspector]
    public List<string> event_description = new();

    private bool isInteractive = false;
    public bool IsInteractive { get => isInteractive; set => isInteractive = value; }

    public delegate void showAvailableEvent();
    public showAvailableEvent ShowAvailable;

    public virtual void Start()
    {
        InitEvent(); // Adjust Events
        ShowAvailable(); // Add Events
    }

    //클릭시, 불러오는 함수
    public virtual void Interactive(GameObject player)
    {
        Debug.Log(InteractiveEvents.Count);
        UIEventGroup.ActiveEventBoxes(InteractiveEvents);
    }

    //용도 미정
    public void UpdateEvents()
    {
        InteractiveEvents.Clear();
    }


    /// <summary>
    /// 선택가능한 이벤트 정의
    /// 해당 함수를 오버라이딩 시, 이벤트를 추가해야 함.
    /// </summary>
    /*
        * 이벤트 추가는 다음과 같은 포멧으로 추가
        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 

        InteractiveEvent interactiveEvent = new("name", "description");
        interactiveEvent.eventContent += () =>
        {
        Debug.Log("test");
        };
        InteractiveEvents.Add(interactiveEvent);

        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        */

    public virtual void InitEvent()
    {
        ShowAvailable = null;
        ShowAvailable += PrimaryEvent;
    }

    void PrimaryEvent()
    {
        //기본 이벤트

        //현재 오브젝트의 모습을 묘사
        InteractiveEvent interactiveEvent = new("primary Event", "description");
        interactiveEvent.eventContent += () =>
        {
            //Function that explain the status of the selected object.
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Active");
            TriggerEnterEvent(collision);
        }
    }

    protected virtual void TriggerEnterEvent(Collider2D collision)
    {
        isInteractive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {          
            TriggerExitEvent(collision);
        }
    }

    protected virtual void TriggerExitEvent(Collider2D collision)
    {
        isInteractive = false;
        UIEventGroup.DisactiveEventBoxes();
    }

    public void AddTemporaryEvent()
    {
        event_name.Clear();
        event_description.Clear();

        Start();
        ShowAvailable();

        for (int i = 0; i < InteractiveEvents.Count; i++)
        {
            event_name.Add(InteractiveEvents[i].name);
            event_description.Add(InteractiveEvents[i].eventDescription);
        }
        InteractiveEvents.Clear();
    }
}

[CanEditMultipleObjects]
[CustomEditor(typeof(InteractiveObject), true)]
public class InteractiveObjectEditor : Editor
{ 
    public override void OnInspectorGUI()
    {
        // 기본 인스펙터 그리기
        DrawDefaultInspector();

        // InteractiveObject 참조 가져오기
        InteractiveObject myScript = (InteractiveObject)target;

        // '이벤트 추가' 버튼
        if (GUILayout.Button("Refresh Event to List"))
        {
            myScript.AddTemporaryEvent();
        }

        EditorGUILayout.LabelField("Added Events:");
        for (int i = 0; i < myScript.event_name.Count; i++)
        {
            EditorGUILayout.LabelField($"Event {i + 1}:");
            EditorGUILayout.TextField("Name", myScript.event_name[i]);
            EditorGUILayout.TextField("Description", myScript.event_description[i]);
        }

    }
}

