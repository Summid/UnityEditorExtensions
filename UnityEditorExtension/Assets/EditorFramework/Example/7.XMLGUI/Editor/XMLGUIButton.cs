using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUIButton : XMLGUIBase
    {
        public string Label;

        public XMLGUIButton(string label)
        {
            this.Label = label;
        }

        public event Action OnClick;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (GUILayout.Button(this.Label))
            {
                this.OnClick?.Invoke();
            }
        }

        protected override void OnDispose()
        {
            
        }
    }
}