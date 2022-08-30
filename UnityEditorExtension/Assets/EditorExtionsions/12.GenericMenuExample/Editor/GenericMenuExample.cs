using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class GenericMenuExample : EditorWindow
    {
        [MenuItem("EditorExtensions/08.GenericMenu/Open")]
        private static void Open()
        {
            GetWindow<GenericMenuExample>().Show();
        }

        private void OnGUI()
        {
            var e = Event.current;

            if (e != null)
            {             
                if (e.type == EventType.MouseDown && e.button == 1)//我们这里用右键开启genericMenu，也可以用按钮等其他方法
                {
                    var genericMenu = new GenericMenu();
                    genericMenu.AddItem(new GUIContent("功能1"), false, () => { Debug.Log("功能1"); });
                    genericMenu.AddItem(new GUIContent("功能合集/功能2"), false, () => { Debug.Log("功能2"); });
                    genericMenu.AddItem(new GUIContent("功能合集/功能3"), false, () => { Debug.Log("功能3"); });
                    genericMenu.AddSeparator("功能合集/");
                    genericMenu.AddItem(new GUIContent("功能合集/功能4"), false, () => { Debug.Log("功能4"); });
                    genericMenu.ShowAsContext();
                }
            }
        }
    }
}