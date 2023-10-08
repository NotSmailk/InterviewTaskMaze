using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(Connection))]
    public class ConnectionDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects)
                return;

            property.isExpanded = EditorGUI.Foldout(position, property.isExpanded, label);
            if (property.isExpanded)
            {
                var type = property.FindPropertyRelative("connectionType");
                EditorGUILayout.PropertyField(type);
                EditorGUILayout.BeginHorizontal();
                var room1 = property.FindPropertyRelative("room1");
                var room2 = property.FindPropertyRelative("room2");
                var colorVector = property.FindPropertyRelative("doors");
                room1.objectReferenceValue = EditorGUILayout.ObjectField(room1.objectReferenceValue, typeof(Room), GUILayout.Width(100f), GUILayout.Height(25f));
                var g = colorVector.FindPropertyRelative("green");
                var y = colorVector.FindPropertyRelative("yellow");
                var b = colorVector.FindPropertyRelative("blue");
                y.boolValue = EditorGUILayout.ToggleLeft("Y", y.boolValue, GUILayout.Width(30), GUILayout.Height(10));
                b.boolValue = EditorGUILayout.ToggleLeft("B", b.boolValue, GUILayout.Width(30), GUILayout.Height(10));
                g.boolValue = EditorGUILayout.ToggleLeft("G", g.boolValue, GUILayout.Width(30), GUILayout.Height(10));
                room2.objectReferenceValue = EditorGUILayout.ObjectField(room2.objectReferenceValue, typeof(Room), GUILayout.Width(100f), GUILayout.Height(25f));
                EditorGUILayout.EndHorizontal();
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}