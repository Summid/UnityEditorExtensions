using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class PopupWindowExample : EditorWindow
    {
        [MenuItem("EditorExtensions/09.PopupWindow/Open")]
        private static void Open()
        {
            GetWindow<PopupWindowExample>().Show();
        }

        private Rect buttonRect;
        private void OnGUI()
        {
            if (GUILayout.Button("Popup Options", GUILayout.Width(200)))
            {
                PopupWindow.Show(this.buttonRect, new PopupWindowContentExample());
            }

            if(Event.current.type == EventType.Repaint)
                this.buttonRect = GUILayoutUtility.GetLastRect();
        }

        public class PopupWindowContentExample : PopupWindowContent
        {
            public override Vector2 GetWindowSize()
            {
                return new Vector2(200, 150);
            }

            private bool toggle1 = true;
            private bool toggle2 = true;
            private bool toggle3 = true;

            public override void OnGUI(Rect rect)
            {
                GUILayout.Label("Popup Options Example", EditorStyles.boldLabel);

                this.toggle1 = EditorGUILayout.Toggle("Toggle 1", this.toggle1);
                this.toggle2 = EditorGUILayout.Toggle("Toggle 2", this.toggle2);
                this.toggle3 = EditorGUILayout.Toggle("Toggle 3", this.toggle3);
            }

            public override void OnOpen()
            {
                Debug.Log("On Open");
            }

            public override void OnClose()
            {
                Debug.Log("On Close");
            }
        }
    }
}