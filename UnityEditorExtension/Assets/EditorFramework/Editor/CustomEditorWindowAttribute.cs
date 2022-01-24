using System;

namespace EditorFramework
{
    public class CustomEditorWindowAttribute : Attribute
    {
        public int RenderOrder { get; private set; }

        public CustomEditorWindowAttribute(int order = -1)
        {
            this.RenderOrder = order;
        }
    }

}
