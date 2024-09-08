using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class InteractiveEvent
{
    [HideInInspector]public string name;
    public string eventName;
    public string eventDescription;

    public delegate void EventContent();
    public EventContent eventContent;

    public InteractiveEvent(string name, string description)
    {
        this.name = name;
        eventName = name;
        eventDescription = description;
    }
}

[CustomPropertyDrawer(typeof(InteractiveEvent))]
public class InteractiveEventEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // SerializedProperty 참조 가져오기
        SerializedProperty eventNameProp = property.FindPropertyRelative("eventName");
        SerializedProperty eventDescriptionProp = property.FindPropertyRelative("eventDescription");

        // 각각의 필드를 인스펙터에서 보여주기
        Rect eventNameRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect eventDescriptionRect = new Rect(position.x, position.y + EditorGUIUtility.singleLineHeight + 2, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.LabelField(eventNameRect, "Event Name", eventNameProp.stringValue);
        EditorGUI.LabelField(eventDescriptionRect, "Event Description", eventDescriptionProp.stringValue);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // 필드 두 개를 표시할 공간 확보
        return EditorGUIUtility.singleLineHeight * 2 + 4;
    }
}