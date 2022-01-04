using UnityEngine;

namespace EditorExtensions
{
    public class GUIAPI
    {
        private Rect labelRect = new Rect(20, 60, 200, 20);
        private Rect textFieldRect = new Rect(20, 90, 200, 20);
        private Rect textAreaRect = new Rect(20, 120, 200, 60);
        private Rect textPasswordFieldRect = new Rect(20, 200, 200, 20);
        private Rect buttonRect = new Rect(20, 230, 200, 20);
        private Rect repeatButtonRect = new Rect(20, 260, 200, 20);
        private Rect toggleRect = new Rect(20, 290, 200, 20);
        private Rect toolbarRect = new Rect(20, 320, 400, 20);
        private Rect boxRect = new Rect(20, 350, 100, 100);
        private Rect horizontalSliderRect = new Rect(20, 460, 100, 20);
        private Rect verticalSliderRect = new Rect(20, 490, 20, 100);
        private Rect groupRect = new Rect(20, 610, 100, 20);
        private Rect windowRect = new Rect(20, 640, 100, 100);

        private string textField;
        private string textArea;
        private string passwordFieldValue = string.Empty;
        private bool toggleValue;
        private int toolbarIndex;
        private float hSliderValue;
        private float vSliderValue;
        private Vector2 scrollPositon = Vector2.zero;

        public void Draw()
        {
            this.scrollPositon = GUI.BeginScrollView(new Rect(20, 60, 400, 700), this.scrollPositon, new Rect(0, 0, 1000, 1000), true, true);//参数1：滚动视图所呈现的范围；参数3：滚动试图内部的范围
            GUI.Label(this.labelRect, "Label:Hello GUI API");
            this.textField = GUI.TextField(this.textFieldRect, this.textField);
            this.textArea = GUI.TextArea(this.textAreaRect, this.textArea);
            this.passwordFieldValue = GUI.PasswordField(this.textPasswordFieldRect, this.passwordFieldValue, '*');

            if (GUI.Button(this.buttonRect, "Button"))
            {
                Debug.Log("Button clicked");
            }

            if (GUI.RepeatButton(this.repeatButtonRect, "Repeat Button"))
            {
                Debug.Log("Repeat button clicked");
            }

            this.toggleValue = GUI.Toggle(this.toggleRect, this.toggleValue, "Toggle");

            this.toolbarIndex = GUI.Toolbar(this.toolbarRect, this.toolbarIndex, new string[] { "1", "2", "3" });

            GUI.Box(this.boxRect, "this is box");

            this.hSliderValue = GUI.HorizontalSlider(this.horizontalSliderRect, this.hSliderValue, 0f, 1f);
            this.vSliderValue = GUI.VerticalSlider(this.verticalSliderRect, this.vSliderValue, 0f, 1f);

            GUI.BeginGroup(this.groupRect, "Group");

            GUI.EndGroup();

            GUI.Window(10000, this.windowRect, (id) =>
            {

            }, "Window");

            GUI.EndScrollView();
        }
    }
}
