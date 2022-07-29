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

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.VerticalSplit(200, 4);
            var mid = position.VerticalSplitRect(200, 4);

            this.FirstArena?.Invoke(rects[0]);
            this.SecondArena?.Invoke(rects[1]);

            EditorGUI.DrawRect(mid.Zoom(-2,AnchorType.MiddleCenter), Color.gray);
        }

        protected override void OnDispose()
        {
            this.FirstArena = null;
            this.SecondArena = null;
        }
    }

}
