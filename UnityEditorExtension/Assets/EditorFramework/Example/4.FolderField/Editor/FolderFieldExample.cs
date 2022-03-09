using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private FolderField folderField;

        private void OnEnable()
        {
            this.folderField = new FolderField();
        }

        private void OnGUI()
        {
            GUILayout.Label("Folder Field");
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            this.folderField.OnGUI(rect);
        }
    }
}