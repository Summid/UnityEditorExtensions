using System.Runtime.InteropServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class GUILayoutExample : EditorWindow
    {
        private string textFieldValue;
        private string textAreaValue;
        private string passwordValue = String.Empty;//GUILayout.PasswordField 的参数需要有默认值，不能为空

        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Laybel: Hello IMGUI");

            GUILayout.BeginVertical("box");//GUIStyle,参考GUI Skin文档
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextField");
                    this.textFieldValue = GUILayout.TextField(this.textFieldValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextArea");
                    this.textAreaValue = GUILayout.TextArea(this.textAreaValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("PasswordField");
                    this.passwordValue = GUILayout.PasswordField(this.passwordValue, '*');
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Button");
                    if (GUILayout.Button("Button"))
                    {
                        Debug.Log("Button Clicked.");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Repeat Button");
                    if (GUILayout.RepeatButton("Repeat Button"))
                    {
                        Debug.Log("Repeat Button Clicked.");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Box");
                    GUILayout.Box("Auto Layout Box");
                }
                GUILayout.EndHorizontal();

            }
            GUILayout.EndVertical();

        }
    }
}
