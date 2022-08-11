using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILabel : GUIBase
    {
        public string Text;

        public XMLGUILabel(string text)
        {
            this.Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.Label(this.Text);
        }

        protected override void OnDispose()
        {
            
        }
    }
}