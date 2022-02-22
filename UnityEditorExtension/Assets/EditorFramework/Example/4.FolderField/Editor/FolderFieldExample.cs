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
            
            Rect[] rects = rect.VerticalSplit(rect.width - 30);
            Rect leftRect = rects[0];
            Rect rightRect = rects[1];

            GUI.Label(leftRect, this.path);

            if (GUI.Button(rightRect, GUIContents.FolderEmpty))
            {
                string path = EditorUtility.OpenFolderPanel("打开文件", Application.dataPath, "default name");

                this.path = path;
                Debug.Log(path);
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);

            if (dragInfo.EnterArea && dragInfo.Completed && !dragInfo.Dragging)
            {
                this.path = dragInfo.Paths[0];
            }
        }
    }
}