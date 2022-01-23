using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace EditorExtensions
{
    public class EditorGUILayoutAPI
    {
        private BuildTargetGroup buildTargetGroupValue;

        private AnimBool animBool = new AnimBool(false);

        private bool foldOutGroup = false;

        private bool groupValue = false;
        private bool toggle1Value = false;
        private bool toggle2Value = true;

        public void Draw()
        {
            this.animBool.target = EditorGUILayout.ToggleLeft("Open Fade Group", this.animBool.target);

            this.foldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(this.foldOutGroup, "FoldOut");
            if (this.foldOutGroup)
            {
                EditorGUILayout.BeginFadeGroup(this.animBool.faded);
                if(this.animBool.target)
                {
                    this.buildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();
                    EditorGUILayout.EndBuildTargetSelectionGrouping();
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();


            this.groupValue = EditorGUILayout.BeginToggleGroup("»´≤ø…Ë÷√", this.groupValue);
            {
                this.toggle1Value = EditorGUILayout.Toggle(this.toggle1Value);
                this.toggle2Value = EditorGUILayout.Toggle(this.toggle2Value);
            }
            EditorGUILayout.EndToggleGroup();

        }
    }

}
