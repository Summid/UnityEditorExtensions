using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : Editor
    {
        CustomEditorExample Target
        {
            get { return (CustomEditorExample)target; }
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            Rect hpRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(hpRect, this.Target.HP, "HP");

            Rect rangeRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(rangeRect, this.Target.Range, "Range");

            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField("½ÇÉ«Ãû", GUILayout.Width(100));
            this.Target.RoleName = EditorGUILayout.TextArea(this.Target.RoleName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.ObjectField(serializedObject.FindProperty("OtherObj"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}