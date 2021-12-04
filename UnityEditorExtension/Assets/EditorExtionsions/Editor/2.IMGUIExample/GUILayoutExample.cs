using System.Globalization;
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
        private PageType currentPageType;

        [MenuItem("EditorExtensions/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private enum PageType
        {
            Basic,
            Rotate,
            Scale,
            Color,
            Other,
        }

        private void OnGUI()
        {
            currentPageType = (PageType)GUILayout.Toolbar((int)currentPageType, Enum.GetNames(typeof(PageType)));

            if (this.currentPageType == PageType.Basic)
            {
                this.Basic();
            }
            else if (this.currentPageType == PageType.Rotate)
            {
                this.Rotate();
            }
            else if (this.currentPageType == PageType.Scale)
            {
                this.Scale();
            }
            else if (this.currentPageType == PageType.Color)
            {
                this.Color();
            }
            else if (this.currentPageType == PageType.Other)
            {
                //Render somethin...
            }

        }



        #region Rotate

        private bool isRotateEffect = false;
        private void Rotate()
        {
            this.isRotateEffect = GUILayout.Toggle(this.isRotateEffect, "Open Rotate Effect");

            if (this.isRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45f, Vector2.one * 200);//45都角，旋转点为(200,200)；屏幕坐标，(0,0)为左上角
            }

            this.Basic();
        }

        #endregion

        #region Scale

        private bool isScaleEffect = false;

        private void Scale()
        {
            this.isScaleEffect = GUILayout.Toggle(this.isScaleEffect, "Scale Effect");

            if (this.isScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(Vector2.one * 0.5f, Vector2.one * 200);
            }

            this.Basic();
        }

        #endregion

        #region  Color

        private bool isColorEffect = false;

        private void Color()
        {
            this.isColorEffect = GUILayout.Toggle(this.isColorEffect, "Color Effect");

            if (this.isColorEffect)
            {
                GUI.color = UnityEngine.Color.green;
            }

            this.Basic();
        }

        #endregion

        #region Basic
        private string textFieldValue;
        private string textAreaValue;
        private string passwordValue = String.Empty;//GUILayout.PasswordField 的参数需要有默认值，不能为空
        private Vector2 scrollPosition;
        private float sliderValue;
        private int toolbarIndex;
        private bool toggleValue;
        private int selectedGridIndex;
        private void Basic()
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
        #endregion

    }
}
