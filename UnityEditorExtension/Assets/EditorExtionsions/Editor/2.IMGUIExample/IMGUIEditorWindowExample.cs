using System.Globalization;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class IMGUIEditorWindowExample : EditorWindow
    {
        private PageType currentPageType;
        private APIMode currentAPIMode;
        private GUILayoutAPI layoutAPI = new GUILayoutAPI();
        private GUIAPI guiAPI = new GUIAPI();

        [MenuItem("EditorExtensions/02.IMGUI/01.IMGUIEditorWindowExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWindowExample>().Show();
        }

        private enum APIMode
        {
            GUILayout,
            GUI,
        }

        private enum PageType
        {
            Basic,
            Enable,
            Rotate,
            Scale,
            Color,
            Other,
        }

        private void OnGUI()
        {
            this.currentAPIMode = (APIMode)GUILayout.Toolbar((int)this.currentAPIMode, Enum.GetNames(typeof(APIMode)));
            this.currentPageType = (PageType)GUILayout.Toolbar((int)this.currentPageType, Enum.GetNames(typeof(PageType)));

            switch (this.currentPageType)
            {
                case PageType.Basic:
                    this.Basic();
                    break;
                case PageType.Enable:
                    this.Enable();
                    break;
                case PageType.Rotate:
                    this.Rotate();
                    break;
                case PageType.Scale:
                    this.Scale();
                    break;
                case PageType.Color:
                    this.Color();
                    break;
                case PageType.Other:
                    //Render Somthing....
                    break;
            }

        }

        #region Basic
        private void Basic()
        {
            if(this.currentAPIMode == APIMode.GUILayout)
            {
                this.layoutAPI.Draw();
            }
            else if(this.currentAPIMode == APIMode.GUI)
            {
                this.guiAPI.Draw();
            }
        }

        #endregion

        #region Enable
        private bool isEnableGUI;
        private void Enable()
        {
            this.isEnableGUI = GUILayout.Toggle(this.isEnableGUI, "Enable GUILayout");
            if (GUI.enabled != this.isEnableGUI)
            {
                GUI.enabled = this.isEnableGUI;//GUI.enabled控制是否渲染
            }
            this.Basic();
        }

        #endregion

        #region Rotate

        private bool isRotateEffect = false;
        private void Rotate()
        {
            this.isRotateEffect = GUILayout.Toggle(this.isRotateEffect, "Open Rotate Effect");

            if (this.isRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45f, Vector2.one * 200);//45度角，旋转点为(200,200)；屏幕坐标，(0,0)为左上角
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

    }
}
