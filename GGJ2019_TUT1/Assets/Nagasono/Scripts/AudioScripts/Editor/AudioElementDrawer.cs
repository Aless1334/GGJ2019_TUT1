using UnityEditor;
using UnityEngine;

namespace Nagasono.AudioScripts.Editor
{
	[CustomPropertyDrawer(typeof(AudioElement))]
	public class AudioElementDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position,
			SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			var setting = property.FindPropertyRelative("Setting");
			
			EditorGUI.indentLevel++;

			var elementWidth = position.width / 3;
			
			EditorGUIUtility.labelWidth = 60;
			position.width = elementWidth;
			EditorGUI.PropertyField(position, property.FindPropertyRelative("Key"), new GUIContent("Key"));
			
			EditorGUIUtility.labelWidth = 60;
			position.x += elementWidth;
			EditorGUI.PropertyField(position, setting.FindPropertyRelative("Clip"), new GUIContent("Clip"));
			
			EditorGUIUtility.labelWidth = 80;
			position.x += elementWidth;
			EditorGUI.PropertyField(position, setting.FindPropertyRelative("Volume"), new GUIContent("Volume"));

			EditorGUI.indentLevel--;
			EditorGUI.EndProperty();
		}
	}
}
