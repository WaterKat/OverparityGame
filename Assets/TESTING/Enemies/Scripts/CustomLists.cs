/*using UnityEditor;
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
                    EditorGUILayout.Space();
                    Debug.DrawLine((Vector3)list.GetArrayElementAtIndex((int)Mathf.Repeat(i+1,list.arraySize)).vector2Value, (Vector3)list.GetArrayElementAtIndex(i).vector2Value, new Color(i/(float)list.arraySize,0,0,1), .25f);
 //                   Handles.DrawLine(Vector3.zero, (Vector3)list.GetArrayElementAtIndex(i).vector2Value);
                }
                EditorGUI.indentLevel -= 1;
                
            }
        }
    }
}*/