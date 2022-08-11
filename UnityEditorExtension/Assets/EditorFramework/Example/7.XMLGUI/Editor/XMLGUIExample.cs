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

        public List<GUIBase> XMLGUI;

        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            this.XMLContent = xmlFileAsset.text;

            this.XMLGUI = new List<GUIBase>();

            var doc = new XmlDocument();
            doc.LoadXml(this.XMLContent);
            var rootNode = doc.SelectSingleNode("GUI");
            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                if (rootNodeChildNode.Name == "Label")
                {
                    this.XMLGUI.Add(new XMLGUILabel(rootNodeChildNode.InnerText));                    
                }
                else if (rootNodeChildNode.Name == "TextField")
                {
                    this.XMLGUI.Add(new XMLGUITextField(rootNodeChildNode.InnerText));                    
                }
            }
        }

        private void OnGUI()
        {
            var selfSize = this.LocalPosition();
            foreach (var guiBase in this.XMLGUI)
            {
                //var rect = GUILayoutUtility.GetRect(selfSize.width, selfSize.height);
                guiBase.OnGUI(default);
            }
        }
    }
}