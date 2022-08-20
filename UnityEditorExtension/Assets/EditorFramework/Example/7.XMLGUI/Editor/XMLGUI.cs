using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        public List<XMLGUIBase> GUIBases = new List<XMLGUIBase>();
        public Dictionary<string, XMLGUIBase> GUIBaseForId = new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            if (this.GUIBaseForId.TryGetValue(id, out XMLGUIBase result))
            {
                return result as T;
            }
            return default;
        }

        public void ReadXML(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            XMLGUIBase xmlGUIBase = default;

            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                string id = string.Empty;
                if(rootNodeChildNode.HasAttribute("id"))
                    id = rootNodeChildNode.Attributes["id"].Value;
                switch (rootNodeChildNode.Name)
                {
                    case "Label":
                        xmlGUIBase = new XMLGUILabel(rootNodeChildNode.InnerText) { Id = id };
                        break;
                    case "TextField":
                        xmlGUIBase = new XMLGUITextField(rootNodeChildNode.InnerText) { Id = id };
                        break;
                    case "TextArea":
                        xmlGUIBase = new XMLGUITextArea(rootNodeChildNode.InnerText) { Id = id };
                        break;
                    case "Button":
                        xmlGUIBase = new XMLGUIButton(rootNodeChildNode.InnerText) { Id = id };
                        break;
                }
                if (!string.IsNullOrEmpty(xmlGUIBase.Id))
                {
                    this.GUIBaseForId.Add(id, xmlGUIBase);
                }
                this.GUIBases.Add(xmlGUIBase);
            }
        }
    }
}