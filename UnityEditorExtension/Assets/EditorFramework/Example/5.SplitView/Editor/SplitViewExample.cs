using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(6)]
    public class SplitViewExample : EditorWindow
    {
        private SplitView splitView;

        private void OnEnable()
        {
            this.splitView = new SplitView();
            this.splitView.FirstArena += SplitViewOnFirstArena;
            this.splitView.SecondArena += SplitViewOnSecondArena;
        }

        private void SplitViewOnFirstArena(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "First");
        }

        private void SplitViewOnSecondArena(Rect obj)
        {
            obj.DrawOutline(Color.green);
            GUI.Box(obj, "Second");
        }

        private void OnGUI()
        {
            var position = this.LocalPosition().Zoom(-10, AnchorType.MiddleCenter);
            this.splitView.OnGUI(position);
        }
    }

}
