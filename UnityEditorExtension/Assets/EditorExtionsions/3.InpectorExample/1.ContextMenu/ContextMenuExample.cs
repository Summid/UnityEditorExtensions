using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class ContextMenuExample : MonoBehaviour
    {
        [ContextMenu("Hello ContextMenu")]
        private void HelloContextMenu()
        {
            Debug.Log("Hello ContextMenu");
        }

        [ContextMenuItem("Print Value", "HelloContextMenuItem")]
        [SerializeField]
        private string contextMenuItemValue;

        private void HelloContextMenuItem()
        {
            Debug.Log(this.contextMenuItemValue);
        }


#if UNITY_EDITOR

        private const string findScriptPath = "CONTEXT/MonoBehaviour/FindScript";
        [UnityEditor.MenuItem(findScriptPath)]
        static void FindScript(UnityEditor.MenuCommand command)
        {
            UnityEditor.Selection.activeObject = UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }


        private const string cameraScriptPath = "CONTEXT/Camera/LogSelf";
        [UnityEditor.MenuItem(cameraScriptPath)]
        static void LogSelf(UnityEditor.MenuCommand command)
        {
            Debug.Log(command.context);
        }

#endif
    }
}