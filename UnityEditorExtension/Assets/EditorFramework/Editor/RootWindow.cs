using System.Reflection;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        private IEnumerable<Type> types;

        [MenuItem("EditorFramework/Open %#e")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private void OnEnable()
        {
            Type editorWindowType = typeof(EditorWindow);
            // FieldInfo editorWindowParent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);//EditorWindow的host

            this.types = AppDomain.CurrentDomain.GetAssemblies()//获取所有程序集
                .SelectMany(assembly => assembly.GetTypes())//将每个程序集中所有Type对象提取出来
                .Where(type => type.IsSubclassOf(editorWindowType))//对Type对象进行筛选
                .Where(type => type.GetCustomAttribute<CustomEditorWindowAttribute>() != null);//并且是被该attribute标记的
        }

        private void OnGUI()
        {
            foreach (var type in types)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(type.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(80)))
                    {
                        GetWindow(type).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
        }


    }
}