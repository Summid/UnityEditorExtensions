using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class GUILayoutExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Hello IMGUI");
        }
    }
}
