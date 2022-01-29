using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class GUIContentAndGUIStyleExample : EditorWindow
    {
        [MenuItem("EditorExtensions/02.IMGUI/02.GUIContentAndGUIStyle")]
        private static void Open()
        {
            GetWindow<GUIContentAndGUIStyleExample>().Show();
        }

        private enum Mode { GUIContent, GUIStyle }

        private int toolbarIndex;

        private GUIStyle boxStyle = "box";

        //用到的时候才初始化
        private Lazy<GUIStyle> fontStyle = new Lazy<GUIStyle>(() => 
        {
            GUIStyle retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });

        private Lazy<GUIStyle> buttonStyle = new Lazy<GUIStyle>(() => 
        {
            GUIStyle retStyle = new GUIStyle("button");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;
            retStyle.normal.textColor = Color.green;
            retStyle.hover.textColor = Color.blue;
            retStyle.focused.textColor = Color.red;
            retStyle.active.textColor = Color.cyan;
            retStyle.normal.background = Texture2D.whiteTexture;
            return retStyle;
        });


        private void OnGUI()
        {
            this.toolbarIndex = GUILayout.Toolbar(this.toolbarIndex, Enum.GetNames(typeof(Mode)));

            if(this.toolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("把鼠标放在我身上");
                GUILayout.Label(new GUIContent("把鼠标放在我身上"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上", "已经放好了 Yeah"));
                GUILayout.Label(new GUIContent("把鼠标放在我身上", Texture2D.whiteTexture));
                GUILayout.Label(new GUIContent("把鼠标放在我身上", Texture2D.whiteTexture, "这个也放好了 Yeah"));

            }
            else if (this.toolbarIndex == (int)Mode.GUIStyle)
            {
                GUILayout.Label("Style of default");
                GUILayout.Label("Style of Box", this.boxStyle);
                GUILayout.Label("Style font", this.fontStyle.Value);
                GUILayout.Button("Style buton", this.buttonStyle.Value);
            }
        }
    }
}