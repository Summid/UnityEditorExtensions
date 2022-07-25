using System;
using System.Collections;
using System.Collections.Generic;
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

            this.FirstArena?.Invoke(rects[0]);
            this.SecondArena?.Invoke(rects[1]);
        }

        protected override void OnDispose()
        {
            
        }
    }

}
