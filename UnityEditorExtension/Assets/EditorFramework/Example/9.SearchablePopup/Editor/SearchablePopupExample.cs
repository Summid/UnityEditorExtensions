using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(9)]
    public class SearchablePopupExample : EditorWindow
    {
        private DayOfWeek value;

        private void OnGUI()
        {
            EditorGUILayout.EnumPopup("DayOfWeek", this.value);
            var rect = GUILayoutUtility.GetRect(200, 200);
            if (GUI.Button(rect, "Change\nthe\nDayOfWeek"))
            {
                SearchablePopup.Show(rect, Enum.GetNames(typeof(DayOfWeek)), (int)this.value, this.OnValueChange);
            }
        }

        private void OnValueChange(int arg1, string arg2)
        {
            this.value = (DayOfWeek)arg1;
            Debug.Log(arg2);
            this.Repaint();
        }
    }
}