using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework
{
    public class XMLGUI
    {
        protected List<XMLGUIBase> guiBases = new List<XMLGUIBase>();
        protected Dictionary<string, XMLGUIBase> guiBaseForId = new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            if (this.guiBaseForId.TryGetValue(id, out XMLGUIBase result))
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
            string id = string.Empty;
            Rect position = Rect.zero;

            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                switch (rootNodeChildNode.Name)
                {
                    case "Label":
                        xmlGUIBase = new XMLGUILabel(rootNodeChildNode.InnerText);
                        break;
                    case "TextField":
                        xmlGUIBase = new XMLGUITextField(rootNodeChildNode.InnerText);
                        break;
                    case "TextArea":
                        xmlGUIBase = new XMLGUITextArea(rootNodeChildNode.InnerText);
                        break;
                    case "Button":
                        xmlGUIBase = new XMLGUIButton(rootNodeChildNode.InnerText);
                        break;
                }

                //获取属性id
                if (rootNodeChildNode.HasAttribute("id"))
                    id = rootNodeChildNode.Attributes["id"].Value;

                //获取属性position
                if (rootNodeChildNode.HasAttribute("position"))
                {
                    string positionString = rootNodeChildNode.Attributes["position"].Value;
                    var positionChars = positionString.Split(',');
                    position = new Rect()
                    {
                        x = float.Parse(positionChars[0]),
                        y = float.Parse(positionChars[1]),
                        width = float.Parse(positionChars[2]),
                        height = float.Parse(positionChars[3])
                    };
                }

                //设置属性id
                xmlGUIBase.Id = id;
                //设置属性position
                xmlGUIBase.SetPosition(position);

                if (!string.IsNullOrEmpty(xmlGUIBase.Id))
                {
                    this.guiBaseForId.Add(id, xmlGUIBase);
                }
                this.guiBases.Add(xmlGUIBase);
            }
        }

        public void Draw()
        {
            foreach (var xmlGuiBase in this.guiBases)
            {
                xmlGuiBase.Draw();
            }
        }
    }
}