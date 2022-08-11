using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextField : GUIBase
    {
        public string Text;

        public XMLGUITextField(string text)
        {
            this.Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.TextField(this.Text);
        }

        protected override void OnDispose()
        {
            
        }
    }
}