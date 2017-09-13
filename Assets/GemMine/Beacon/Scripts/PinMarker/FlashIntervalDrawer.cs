using UnityEngine;
using System.Collections;
using UnityEditor;

// the flashInterval has its own custom editor

[CustomPropertyDrawer (typeof(FlashInterval))]
public class FlashIntervalDrawer : PropertyDrawer {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);

		contentPosition.width *= 0.33f;
		EditorGUI.indentLevel = 0;
		EditorGUIUtility.labelWidth = 28f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("onInterval"), new GUIContent("On"));

		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("offInterval"), new GUIContent("Off"));

		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("flashColor"), new GUIContent("Col"));

		EditorGUI.EndProperty ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
