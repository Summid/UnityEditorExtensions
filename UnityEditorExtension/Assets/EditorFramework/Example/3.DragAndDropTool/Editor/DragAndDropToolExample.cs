using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(4)]
    public class DragAndDropToolExample : EditorWindow
    {
        
        private void OnGUI()
        {
            Rect rect = new Rect(10, 10, 300, 300);
            GUI.Box(rect, "拖拽一些东西到这里");

            DragAndDropTool.DragInfo info = DragAndDropTool.Drag(Event.current, rect);

            if (info.EnterArea && info.Completed && !info.Dragging)
            {
                foreach (string path in info.Paths)
                {
                    Debug.Log($"path {path}");
                }

                foreach (Object objectReference in info.ObjectReferences)
                {
                    Debug.Log($"objectReference {objectReference}");
                }
            }

        }
    }
}