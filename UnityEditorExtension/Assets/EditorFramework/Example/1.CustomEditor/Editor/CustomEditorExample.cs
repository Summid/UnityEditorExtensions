using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("这是自定义的窗口");
        }
    }

}
