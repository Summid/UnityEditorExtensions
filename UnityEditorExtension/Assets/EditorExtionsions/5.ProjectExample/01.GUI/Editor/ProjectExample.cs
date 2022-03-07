using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public class ProjectExample
    {
        private const string PATH = "EditorExtensions/02.IMGUI/04.Enable Custom Project";

        private static bool customProjectEnabled = false;

        [MenuItem(PATH)]
        private static void Enable()
        {
            if (customProjectEnabled)
            {
                customProjectEnabled = false;
                UnregisterProject();
            }
            else
            {
                customProjectEnabled = true;
                RegisterProject();

                //ProjectWindowUtil.CreateFolder();
            }

            Menu.SetChecked(PATH, customProjectEnabled);
            EditorApplication.RepaintProjectWindow();
        }

        static ProjectExample()
        {
            Menu.SetChecked(PATH, customProjectEnabled);
        }

        private static void RegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjcetGUI;
            EditorApplication.projectChanged += OnProjectChanged;
        }

        private static void UnregisterProject()
        {
            EditorApplication.projectWindowItemOnGUI -= OnProjcetGUI;
            EditorApplication.projectChanged -= OnProjectChanged;

        }

        private static void OnProjcetGUI(string guid, Rect selectionRect)
        {
            try
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guid);

                string[] files = Directory.GetFiles(assetPath);

                Rect countLabelRect = selectionRect;
                countLabelRect.x += 200;
                GUI.Label(countLabelRect, files.Length.ToString());

            }
            catch (Exception ex)
            {
                
            }
        }

        private static void OnProjectChanged()
        {
            Debug.Log("project changed");
        }
    }
}