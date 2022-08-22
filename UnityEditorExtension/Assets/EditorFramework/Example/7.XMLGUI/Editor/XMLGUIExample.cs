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

        private XMLGUI xmlGUI;
        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            this.XMLContent = xmlFileAsset.text;

            this.xmlGUI = new XMLGUI();
            this.xmlGUI.ReadXML(this.XMLContent);

            //≤‚ ‘“ªœ¬
            this.xmlGUI.GetGUIBaseById<XMLGUIButton>("loginButton").OnClick += () =>
            {
                Debug.Log("loginButton Clicked");

                this.xmlGUI.GetGUIBaseById<XMLGUILabel>("label1").Text = "you click the button";
                this.xmlGUI.GetGUIBaseById<XMLGUITextField>("username").Text = "Summid";
                this.xmlGUI.GetGUIBaseById<XMLGUITextArea>("description").Text = "A furry engineer";
                
            };
        }

        private void OnGUI()
        {
            this.xmlGUI.Draw();
        }
    }
}