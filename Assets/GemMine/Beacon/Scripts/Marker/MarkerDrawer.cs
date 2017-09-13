using UnityEngine;
using System.Collections;
/*
// this class can only be used if the program is running in the editor
// if you want to build it for android, this class must be commented out

#if UNITY_EDITOR
using UnityEditor;

// this class creates a custom editor field for latitude, longitude and color
// in a single row

[CustomPropertyDrawer (typeof(Marker))]
public class MarkerDrawer : PropertyDrawer
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = EditorGUI.PrefixLabel(position, label);

		contentPosition.width *= 0.33f;
		EditorGUI.indentLevel = 0;
		EditorGUIUtility.labelWidth = 28f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("latitude"), new GUIContent("Lat"));

		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("longitude"), new GUIContent("Lon"));

		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("markerColor"), new GUIContent("Col"));

		EditorGUI.EndProperty ();
	}
		
}
#endif
*/