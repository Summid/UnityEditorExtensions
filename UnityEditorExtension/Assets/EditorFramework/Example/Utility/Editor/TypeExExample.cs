using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    [CustomEditorWindow(3)]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }

        public class MyDescription : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述";
        }

        [MyDesc("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述B";
        }

        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                this.Type = type;
            }
        }

        private IEnumerable<Type> descriptionTypes;
        private IEnumerable<Type> descriptionTypesWithAttribute;
        private void OnEnable()
        {
            this.descriptionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
            this.descriptionTypesWithAttribute = typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            GUILayout.Label("types");
            foreach (var descriptionType in this.descriptionTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(descriptionType.Name);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("with attribute");
            foreach (var descriptionType in this.descriptionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(descriptionType.Name);
                    GUILayout.Label(descriptionType.GetCustomAttribute<MyDescAttribute>().Type);
                }
                GUILayout.EndHorizontal();
            }
        }
    }

}
