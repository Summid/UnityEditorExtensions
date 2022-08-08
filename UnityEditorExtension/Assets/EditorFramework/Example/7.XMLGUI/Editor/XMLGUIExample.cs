using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(7)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/7.XMLGUI/Editor/GUIExample.xml";

        private string XMLContent;

        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            this.XMLContent = xmlFileAsset.text;
        }

        private void OnGUI()
        {
            var doc = new XmlDocument();
            doc.LoadXml(this.XMLContent);
            var rootNode = doc.SelectSingleNode("GUI");
            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                if (rootNodeChildNode.Name == "Label")
                {
                    GUILayout.Label(rootNodeChildNode.InnerText);
                }
            }
        }
    }
}