using System.Reflection;
using System;
using UnityEngine;
using UnityEditor;
using System.Linq;


namespace EditorFramework
{
    public class RootWindow : EditorWindow
    {
        [MenuItem("EditorFramework/Open %#e")]
        static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private void OnEnable()
        {
            Type editorWindowType = typeof(EditorWindow);
            // FieldInfo editorWindowParent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);//EditorWindow的host

            var editorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()//获取所有程序集
                .SelectMany(assembly => assembly.GetTypes())//将每个程序集中所有Type对象提取出来
                .Where(type => type.IsSubclassOf(editorWindowType));//对Type对象进行筛选

            foreach (var windowType in editorWindowTypes)
            {
                Debug.Log(windowType.Name);
            }
        }


    }
}