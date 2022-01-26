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
            GUI.Box(rect, "��קһЩ����������");

            Event e = Event.current;
            bool enterArea;
            bool completed;
            bool dragging;

            if (e.type == EventType.DragUpdated)
            {
                //drag������
                dragging = true;
                completed = false;
                enterArea = rect.Contains(e.mousePosition);
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
                enterArea = rect.Contains(e.mousePosition);
                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                //����Ƴ�������
                dragging = false;
                completed = true;
                enterArea = rect.Contains(e.mousePosition);
            }
            else
            {
                dragging = false;
                completed = false;
                enterArea = rect.Contains(e.mousePosition);
            }

            completed = completed && e.type == EventType.Used;//�¼�ʹ�ú��������ɣ��ų�DragExited�����

            if (enterArea && completed && !dragging)
            {
                foreach (string path in DragAndDrop.paths)
                {
                    Debug.Log($"path {path}");
                }

                foreach (Object objectReference in DragAndDrop.objectReferences)
                {
                    Debug.Log($"objectReference {objectReference}");
                }
            }

        }
    }
}