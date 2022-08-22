using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUITextArea : XMLGUIBase
    {
        public string Text;

        public XMLGUITextArea(string text)
        {
            this.Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            this.Text = GUI.TextArea(position, this.Text);
        }

        protected override void OnDispose()
        {
            
        }
    }
}