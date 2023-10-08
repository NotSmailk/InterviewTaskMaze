using UnityEditor;
using UnityEngine;

namespace Assets.Source.Scripts
{
    [CustomPropertyDrawer(typeof(WallConfig))]
    public class WallConfigDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.serializedObject.isEditingMultipleObjects)
                return;

            EditorGUILayout.PrefixLabel(label);
            var up = property.FindPropertyRelative("up");
            var bot = property.FindPropertyRelative("bot");
            var left = property.FindPropertyRelative("left");
            var right = property.FindPropertyRelative("right");
            EditorGUI.indentLevel = 1;
            up.boolValue = EditorGUILayout.ToggleLeft("U", up.boolValue, GUILayout.Width(60f));
            EditorGUI.indentLevel = 0;
            EditorGUILayout.BeginHorizontal();
            left.boolValue = EditorGUILayout.ToggleLeft("L", left.boolValue, GUILayout.Width(30f));
            right.boolValue = EditorGUILayout.ToggleLeft("R", right.boolValue, GUILayout.Width(30f));
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel = 1;
            bot.boolValue = EditorGUILayout.ToggleLeft("B", bot.boolValue, GUILayout.Width(60f));
            EditorGUI.indentLevel = 0;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }
    }
}
