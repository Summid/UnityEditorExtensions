using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(1)]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("这是自定义的窗口");
        }
    }

}
