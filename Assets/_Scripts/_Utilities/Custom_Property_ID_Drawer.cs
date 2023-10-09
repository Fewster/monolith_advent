using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Custom_Property_ID : PropertyAttribute { }

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Custom_Property_ID))]	
public class Custom_Property_ID_Drawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		GUI.enabled = false;
		if (string.IsNullOrEmpty(property.stringValue))
		{
			property.stringValue = Guid.NewGuid().ToString();
		}
		EditorGUI.PropertyField(position, property, label, true);
		GUI.enabled = true;
	}
}
#endif
