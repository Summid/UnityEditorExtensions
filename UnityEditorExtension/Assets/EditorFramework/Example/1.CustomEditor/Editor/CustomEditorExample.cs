using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(1)]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("�����Զ���Ĵ���");
        }
    }

}
