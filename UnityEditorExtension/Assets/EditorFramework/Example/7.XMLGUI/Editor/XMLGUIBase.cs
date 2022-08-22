using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework
{
    public abstract class XMLGUIBase : GUIBase
    {
        public string Id { get; set; }

        public void SetPosition(Rect position)
        {
            this.Position = position;
        }

        public void Draw()
        {
            this.OnGUI(this.Position);
        }
    }
}