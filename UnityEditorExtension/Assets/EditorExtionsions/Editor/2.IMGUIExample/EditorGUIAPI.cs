using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class EditorGUIAPI
    {
        private Rect toggleRect = new Rect(10, 50, 100, 10);
        private Rect lableRect = new Rect(10, 80, 200, 20);

        private bool disableGroupValue = false;

        public void Draw()
        {
            this.disableGroupValue = EditorGUI.Toggle(this.toggleRect, new GUIContent("Disable Group"), this.disableGroupValue);

            EditorGUI.BeginDisabledGroup(this.disableGroupValue);
            {
                EditorGUI.LabelField(this.lableRect, "LabelField");

            }
            EditorGUI.EndDisabledGroup();
        }
    }

}
