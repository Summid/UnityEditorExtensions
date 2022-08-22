using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUILabel : XMLGUIBase
    {
        public string Text;

        public XMLGUILabel(string text)
        {
            this.Text = text;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUI.Label(position, this.Text);
        }

        protected override void OnDispose()
        {
            
        }
    }
}