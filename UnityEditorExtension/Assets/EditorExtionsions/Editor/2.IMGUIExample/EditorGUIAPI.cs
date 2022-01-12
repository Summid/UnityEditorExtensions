using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect toggleRect = new Rect(10, 50, 100, 10);
        private Rect lableRect = new Rect(10, 80, 200, 20);
        private Rect textFieldRect = new Rect(10, 120, 100, 20);
        private Rect textAreaRect = new Rect(10, 150, 100, 100);
        private Rect passwordFieldRect = new Rect(10, 260, 100, 20);
        private Rect dropDownButtonRect = new Rect(10, 290, 100, 20);
        private Rect toggleRightRect = new Rect(10, 320, 100, 20);
        private Rect toggleLeftRect = new Rect(10, 350, 100, 20);
        private Rect helpBoxRect = new Rect(10, 380, 200, 200);
        private Rect colorFieldRect = new Rect(10, 590, 100, 20);
        private Rect boundsFieldRect = new Rect(10, 620, 500, 100);

        private bool disableGroupValue = false;
        private string textFieldValue;
        private string textAreaValue;
        private string passwordFieldValue = string.Empty;
        private bool toggleValue;
        private Color colorFieldValue;
        private Bounds boundsFieldValue;

        public void Draw()
        {
            this.disableGroupValue = EditorGUI.Toggle(this.toggleRect, new GUIContent("Disable Group"), this.disableGroupValue);

            EditorGUI.BeginDisabledGroup(this.disableGroupValue);
            {
                EditorGUI.LabelField(this.lableRect, "LabelField");
                this.textFieldValue = EditorGUI.TextField(this.textFieldRect, this.textFieldValue);
                this.textAreaValue = EditorGUI.TextArea(this.textAreaRect, this.textAreaValue);
                this.passwordFieldValue = EditorGUI.PasswordField(this.passwordFieldRect, this.passwordFieldValue);
                if (EditorGUI.DropdownButton(this.dropDownButtonRect, new GUIContent("123"), FocusType.Keyboard))
                {
                    Debug.Log("DropdownButton Clicked");
                }

                this.toggleValue = EditorGUI.Toggle(this.toggleRightRect, this.toggleValue);
                this.toggleValue = EditorGUI.ToggleLeft(this.toggleLeftRect, "´ò¿ª/¹Ø±Õ", this.toggleValue);

                EditorGUI.HelpBox(this.helpBoxRect, "123123123", MessageType.Error);

                this.colorFieldValue = EditorGUI.ColorField(this.colorFieldRect, this.colorFieldValue);

                this.boundsFieldValue = EditorGUI.BoundsField(this.boundsFieldRect, this.boundsFieldValue);
            }
            EditorGUI.EndDisabledGroup();
        }
    }

}
