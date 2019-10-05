using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StandardEnemyCrawl))]
public class EnemyEditor : Editor
{
    SerializedProperty Velocity;

    void OnEnable()
    {
        Velocity = serializedObject.FindProperty("Velocity");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(Velocity);
        serializedObject.ApplyModifiedProperties();
    }
}