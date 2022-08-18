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
                switch (rootNodeChildNode.Name)
                {
                    case "Label":
                        this.XMLGUI.Add(new XMLGUILabel(rootNodeChildNode.InnerText));
                        break;
                    case "TextField":
                        this.XMLGUI.Add(new XMLGUITextField(rootNodeChildNode.InnerText));
                        break;
                    case "TextArea":
                        this.XMLGUI.Add(new XMLGUITextArea(rootNodeChildNode.InnerText));
                        break;
                    case "Button":
                        this.XMLGUI.Add(new XMLGUIButton(rootNodeChildNode.InnerText));
                        break;
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