using System;
using UnityEngine;

namespace EditorExtensions
{
    public class GUILayoutAPI
    {
        private string textFieldValue;
        private string textAreaValue;
        private string passwordValue = String.Empty;//GUILayout.PasswordField 的参数需要有默认值，不能为空
        private Vector2 scrollPosition;
        private float sliderValue;
        private int toolbarIndex;
        private bool toggleValue;
        private int selectedGridIndex;
        public void Draw()
        {
            GUILayout.Label("Laybel: Hello IMGUI");

            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            {
                GUILayout.BeginVertical("box");//GUIStyle,参考GUI Skin文档
                {

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextField");
                        this.textFieldValue = GUILayout.TextField(this.textFieldValue);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(50);//默认10px

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

                        GUILayout.FlexibleSpace();//label和button分别为最左最右对其

                        //同时设置按钮的最小、最大长宽
                        if (GUILayout.Button("Button", GUILayout.MinWidth(100), GUILayout.MinHeight(100), GUILayout.MaxHeight(150), GUILayout.MaxWidth(150)))
                        {
                            Debug.Log("Button Clicked.");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Repeat Button");
                        if (GUILayout.RepeatButton("Repeat Button", GUILayout.Width(150), GUILayout.Height(150)))//设置按钮宽高为150px
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

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Horizontal Slider");
                        this.sliderValue = GUILayout.HorizontalSlider(this.sliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Vertical Slider");
                        this.sliderValue = GUILayout.VerticalSlider(this.sliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginArea(new Rect(0, 0, 100, 100));
                    {
                        GUI.Label(new Rect(0, 0, 20, 20), "Area");

                    }
                    GUILayout.EndArea();

                    GUILayout.Window(1, new Rect(0, 0, 100, 100), id =>
                    {

                    }, "Window");

                    this.toolbarIndex = GUILayout.Toolbar(this.toolbarIndex, new string[] { "ToolBar1", "ToolBar2", "ToolBar3", "ToolBar4", "ToolBar5" });

                    this.toggleValue = GUILayout.Toggle(this.toggleValue, "Toggle");

                    this.selectedGridIndex = GUILayout.SelectionGrid(selectedGridIndex, new string[]
                    {
                        "1",
                        "2",
                        "3",
                        "4",
                        "5"
                    }, 2);

                }
                GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }
    }
}
