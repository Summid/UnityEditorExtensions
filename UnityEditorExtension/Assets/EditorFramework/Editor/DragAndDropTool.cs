using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{

    public static class DragAndDropTool
    {
        public class DragInfo
        {
            public bool Dragging;
            public bool EnterArea;
            public bool Completed;
            
            public Object[] ObjectReferences => DragAndDrop.objectReferences;
            public string[] Paths => DragAndDrop.paths;
            public DragAndDropVisualMode VisualMode => DragAndDrop.visualMode;
            public int ActiveControlID => DragAndDrop.activeControlID;
        }

        private static DragInfo dragInfo = new DragInfo();

        private static bool dragging;
        private static bool enterArea;
        private static bool completed;

        public static DragInfo Drag(Event e, Rect content, DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
        {
            if (e.type == EventType.DragUpdated)
            {
                //drag������
                dragging = true;
                completed = false;
                enterArea = content.Contains(e.mousePosition);
                if (enterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                //drag���
                dragging = false;
                completed = true;
                enterArea = content.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                //����Ƴ�������
                dragging = false;
                completed = true;
                enterArea = content.Contains(e.mousePosition);
            }
            else
            {
                dragging = false;
                completed = false;
                enterArea = content.Contains(e.mousePosition);
            }

            dragInfo.Completed = completed && e.type == EventType.Used;//�¼�ʹ�ú��������ɣ��ų�DragExited�����
            dragInfo.EnterArea = enterArea;
            dragInfo.Dragging = dragging;

            return dragInfo;
        }
    }
}