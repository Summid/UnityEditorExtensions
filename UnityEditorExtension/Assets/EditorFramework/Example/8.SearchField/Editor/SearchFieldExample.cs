using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(8)]
    public class SearchFieldExample : EditorWindow
    {
        private SearchField searchField;

        private string searchContent = string.Empty;
        private string[] searchableContents = new[] { "mode1", "mode2", "mode3" };

        private void OnEnable()
        {
            this.searchField = new SearchField(this.searchContent, this.searchableContents, 0);

            this.searchField.OnIndexChanged += this.OnSearchFieldIndexChanged;
            this.searchField.OnValueChanged += this.OnSearchFieldValueChanged;
        }

        private void OnSearchFieldValueChanged(string obj)
        {
            Debug.Log(obj);
        }

        private void OnSearchFieldIndexChanged(int obj)
        {
            Debug.Log(obj);            
        }

        private void OnGUI()
        {
            GUILayout.Label("SearchField");
            this.searchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }
}