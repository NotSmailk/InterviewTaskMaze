using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts
{
    [CustomPropertyDrawer(typeof(ColorVector))]
    public class ColorVectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects)
                return;

            GUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(property.displayName);

            bool y = property.FindPropertyRelative("yellow").boolValue;
            property.FindPropertyRelative("yellow").boolValue = EditorGUILayout.ToggleLeft("Y", y, GUILayout.Width(30), GUILayout.Height(10));

            bool b = property.FindPropertyRelative("blue").boolValue;
            property.FindPropertyRelative("blue").boolValue = EditorGUILayout.ToggleLeft("B", b, GUILayout.Width(30), GUILayout.Height(10));

            bool g = property.FindPropertyRelative("green").boolValue;
            property.FindPropertyRelative("green").boolValue = EditorGUILayout.ToggleLeft("G", g, GUILayout.Width(30), GUILayout.Height(10));
            
            GUILayout.EndHorizontal();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return 0;
        }
    }
}
