using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class FolderField : GUIBase
    {
        protected string path;
        public string title;
        public string folder;
        public string defaultName;
        public string Path => this.path;

        public FolderField(string path = "Assets", string folder = "Assets", string title = "Select Folder", string defaultName = "")
        {
            this.path = path;
            this.title = title;
            this.folder = folder;
            this.defaultName = defaultName;
        }

        public void SetPath(string path)
        {
            this.path = path;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            Rect[] rects = position.VerticalSplit(position.width - 30);
            Rect leftRect = rects[0];
            Rect rightRect = rects[1];

            bool currentGUIEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(leftRect, this.path);
            GUI.enabled = currentGUIEnabled;

            if (GUI.Button(rightRect, GUIContents.FolderEmpty))
            {
                string selectedPath = EditorUtility.OpenFolderPanel(this.title, this.folder, this.defaultName);

                if (!string.IsNullOrEmpty(selectedPath) && selectedPath.IsDirectory())
                {
                    this.path = selectedPath.ToAssetsPath();
                }
                Debug.Log(selectedPath);
            }

            var dragInfo = DragAndDropTool.Drag(Event.current, leftRect);

            if (dragInfo.EnterArea && dragInfo.Completed && !dragInfo.Dragging && dragInfo.Paths[0].IsDirectory())
            {
                this.path = dragInfo.Paths[0];
            }
        }

        protected override void OnDispose()
        {
            
        }
    }
}