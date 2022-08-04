using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class SplitView : GUIBase
    {
        public SplitType SplitType = SplitType.Vertical;

        public event Action<Rect> FirstArena, SecondArena;
        public event Action OnBeginResize,OnEndResize;

        public float SplitSize = 200f;//width or height，第一块区域的大小
        public float MinSize = 100f;//区域的最小大小

        private bool resizing;
        public bool Dragging
        {
            get { return this.resizing; }
            set
            {
                if (this.resizing != value)
                {
                    this.resizing = value;
                    if (value)
                    {
                        this.OnBeginResize?.Invoke();
                    }
                    else
                    {
                        this.OnEndResize?.Invoke();
                    }
                }
            }
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.Split(this.SplitType, this.SplitSize, 4);
            var mid = position.SplitRect(this.SplitType, this.SplitSize, 4);

            this.FirstArena?.Invoke(rects[0]);
            this.SecondArena?.Invoke(rects[1]);

            EditorGUI.DrawRect(mid.Zoom(-2,AnchorType.MiddleCenter), Color.gray);


            Event e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                //更改光标样式
                MouseCursor mouseCursor = this.SplitType == SplitType.Vertical ? MouseCursor.ResizeHorizontal : MouseCursor.ResizeVertical;
                EditorGUIUtility.AddCursorRect(mid, mouseCursor);
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
                        if (this.SplitType == SplitType.Vertical)
                        {
                            this.SplitSize += e.delta.x;
                            this.SplitSize = Mathf.Clamp(this.SplitSize, this.MinSize, this.Position.size.x - this.MinSize);
                        }
                        else if (this.SplitType == SplitType.Horizontal)
                        {
                            this.SplitSize += e.delta.y;
                            this.SplitSize = Mathf.Clamp(this.SplitSize, this.MinSize, this.Position.size.y - this.MinSize);
                        }
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
            this.OnBeginResize = null;
            this.OnEndResize = null;
        }
    }

}
