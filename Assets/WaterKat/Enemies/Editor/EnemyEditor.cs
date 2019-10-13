using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace WaterKat.CustomEditors
{
    [CustomEditor(typeof(StandardEnemyCrawl))]
    public class EnemyEditor : Editor
    {
        SerializedProperty Velocity;
        SerializedProperty PatrolPath;

        void OnEnable()
        {
            Velocity = serializedObject.FindProperty("Velocity");
            PatrolPath = serializedObject.FindProperty("PatrolPath");

        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.Space();

            serializedObject.Update();
            EditorGUILayout.PropertyField(Velocity);

            if (PatrolPath != null)
            {
                CustomLists.Show(PatrolPath);
                //EditorGUILayout.PropertyField(PatrolPath, true) ;
            }
            else
            {
                EditorGUILayout.TextArea("ArrayGoesHere");
            }

            serializedObject.ApplyModifiedProperties();

            // DrawDefaultInspector();
        }
    }
}