using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EditorExtensions
{
    public class ReorderableListExample : EditorWindow
    {
        [MenuItem("EditorExtensions/06.ReorderableList/Open")]
        private static void Open()
        {
            GetWindow<ReorderableListExample>().Show();
        }

        private ReorderableList list;
        private List<Vector2> data = new List<Vector2>();

        private void OnEnable()
        {
            this.list = new ReorderableList(this.data, typeof(Vector2));
            this.list.elementHeight = 30;
            this.list.drawHeaderCallback += this.DrawHeader;
            this.list.drawNoneElementCallback += this.DrawNoneElement;
            this.list.drawElementCallback += this.DrawElement;
            this.list.drawElementBackgroundCallback += this.DrawElementBG;
        }

        private void DrawElementBG(Rect rect, int index, bool isActive, bool isFocused)
        {
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
        }

        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            this.data[index] = EditorGUI.Vector2Field(rect, "", this.data[index]);
        }

        private void DrawNoneElement(Rect rect)
        {
            //do nothing
        }

        private void DrawHeader(Rect rect)
        {
            GUI.Box(rect, "header");
        }

        private void OnGUI()
        {
            this.list.DoLayoutList();
        }
    }
}