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
                if (e.type == EventType.MouseDown && e.button == 1)//�����������Ҽ�����genericMenu��Ҳ�����ð�ť����������
                {
                    var genericMenu = new GenericMenu();
                    genericMenu.AddItem(new GUIContent("����1"), false, () => { Debug.Log("����1"); });
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����2"), false, () => { Debug.Log("����2"); });
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����3"), false, () => { Debug.Log("����3"); });
                    genericMenu.AddSeparator("���ܺϼ�/");
                    genericMenu.AddItem(new GUIContent("���ܺϼ�/����4"), false, () => { Debug.Log("����4"); });
                    genericMenu.ShowAsContext();
                }
            }
        }
    }
}