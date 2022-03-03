using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    [InitializeOnLoad]
    public static class HierarchyExample
    {
        private static bool customHierarchyEnable = false;

        private const string PATH = "EditorExtensions/02.IMGUI/03.Enable Custom Hierarchy";

        static HierarchyExample()
        {
            Menu.SetChecked(PATH, customHierarchyEnable);
        }

        [MenuItem(PATH)]
        private static void EnableCustomHierarchy()
        {
            if (customHierarchyEnable)
            {
                customHierarchyEnable = false;
                UnregisterHierarchy();
            }
            else
            {
                customHierarchyEnable = true;
                RegisterHierarchy();
            }

            Menu.SetChecked(PATH, customHierarchyEnable);

            EditorApplication.RepaintHierarchyWindow();//每次设置后就立即绘制
        }

        private static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }

        private static void UnregisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;

        }

        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj)
            {
                Rect tagLabelRect = selectionRect;
                tagLabelRect.x += 100;
                GUI.Label(tagLabelRect, obj.tag);

                Rect layerLabelRect = selectionRect;
                layerLabelRect.x += 200;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            }
        }

        private static void OnHierarchyChanged()
        {
            Debug.Log("OnHierarchyChanged");
        }
    }
}