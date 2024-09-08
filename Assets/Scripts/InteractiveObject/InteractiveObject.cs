using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IInteractive
{
    public List<InteractiveEvent> InteractiveEvents;

    private bool isInteractive = false;
    public bool IsInteractive { get => isInteractive; set => isInteractive = value; }

    public virtual void Interact(GameObject player)
    {
        Debug.Log(InteractiveEvents.Count);
        UIEventGroup.ActiveEventBoxes(InteractiveEvents);
    }

    public void UpdateEvents()
    {
        InteractiveEvents.Clear();

        AdjustEvents();
    }


    protected void AdjustEvents()
    {
        /*
         * �̺�Ʈ �߰��� ������ ���� �������� �߰�
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        
        InteractiveEvent interactiveEvent = new("name", "description");
        interactiveEvent.eventContent += () =>
        {
            Debug.Log("test");
        };
        interactiveEvents.Add(interactiveEvent);

        * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
        */

        InteractiveEvent interactiveEvent = new(gameObject.name, "description");
        interactiveEvent.eventContent += () =>
        {
            Debug.Log("test");
        };
        InteractiveEvents.Add(interactiveEvent);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Active");
            isInteractive = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInteractive = false;
            UIEventGroup.DisactiveEventBoxes();
        }
    }
}

[CanEditMultipleObjects]
[CustomEditor(typeof(InteractiveObject), true)] // 'true' applies the editor to derived classes too
public class InteractiveObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // �⺻ �ν����� �׸���
        DrawDefaultInspector();

        // InteractiveObject ���� ��������
        InteractiveObject myScript = (InteractiveObject)target;

        // ��ư �����
        if (GUILayout.Button("Add Event to List"))
        {
            myScript.UpdateEvents();
        }
    }
}
