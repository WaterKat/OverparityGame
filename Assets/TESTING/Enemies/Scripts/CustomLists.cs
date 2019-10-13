using UnityEditor;
using UnityEngine;
namespace WaterKat.CustomEditors
{
    public static class CustomLists
    {

        public static void Show(SerializedProperty list)
        {
            EditorGUILayout.PropertyField(list);
            if (list.isExpanded)
            {
                EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
                EditorGUILayout.Space();

                EditorGUI.indentLevel += 1;

                for (int i = 0; i < list.arraySize; i++)
                {
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
//                    Handles.DrawLine(Vector3.zero, list.GetArrayElementAtIndex(i) as Vector3);
                }
                EditorGUI.indentLevel -= 1;
                
            }
        }
    }
}