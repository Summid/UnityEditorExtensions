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

            this.types = editorWindowType.GetSubTypesWithClassAttributeInAssemblies<CustomEditorWindowAttribute>()
                .OrderBy(type => type.GetCustomAttribute<CustomEditorWindowAttribute>().RenderOrder);//根据RenderOrder来进行排序
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