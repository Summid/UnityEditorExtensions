using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public event Action<Rect> FirstArena, SecondArena;

        public float SplitWidth = 200f;
        public float MinSize = 100f;

        public bool Dragging = false;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.VerticalSplit(this.SplitWidth, 4);
            var mid = position.VerticalSplitRect(this.SplitWidth, 4);

            this.FirstArena?.Invoke(rects[0]);
            this.SecondArena?.Invoke(rects[1]);

            EditorGUI.DrawRect(mid.Zoom(-2,AnchorType.MiddleCenter), Color.gray);


            Event e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                //更改光标样式
                EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal);
            }

            //拖拽修改左右rect的宽
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                        this.Dragging = true;
                    break;
                case EventType.MouseDrag:
                    if (this.Dragging)
                    {
                        this.SplitWidth += e.delta.x;
                        this.SplitWidth = Mathf.Clamp(this.SplitWidth, this.MinSize, this.Position.size.x - this.MinSize);

                        e.Use();
                    }
                    break;
                case EventType.MouseUp:
                    if (this.Dragging)
                        this.Dragging = false;
                    break;
            }
        }

        protected override void OnDispose()
        {
            this.FirstArena = null;
            this.SecondArena = null;
        }
    }

}
