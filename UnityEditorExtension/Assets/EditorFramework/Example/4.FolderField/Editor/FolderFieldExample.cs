using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string path = string.Empty;

        private void OnGUI()
        {
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));

            if (GUI.Button(rect, GUIContents.FolderEmpty))
            {
                string path = EditorUtility.OpenFolderPanel("打开文件", Application.dataPath, "default name");

                this.path = path;
                Debug.Log(path);
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, rect);

            if (dragInfo.EnterArea && dragInfo.Completed && !dragInfo.Dragging)
            {
                this.path = dragInfo.Paths[0];
            }
        }
    }
}