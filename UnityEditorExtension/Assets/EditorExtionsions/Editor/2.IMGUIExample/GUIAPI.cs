using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect labelRect = new Rect(20, 60, 200, 20);
        private Rect textFieldRect = new Rect(20, 90, 200, 20);
        private Rect textAreaRect = new Rect(20, 120, 200, 60);

        private string textField;
        private string textArea;

        public void Draw()
        {
            GUI.Label(this.labelRect, "Label:Hello GUI API");
            this.textField = GUI.TextField(this.textFieldRect,this.textField);
            this.textArea = GUI.TextArea(this.textAreaRect,this.textArea);
        }
    }
}
