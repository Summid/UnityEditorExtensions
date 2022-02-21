using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    [CustomPreview(typeof(GameObject))]
    public class ObjectivePreviewExample : ObjectPreview
    {
        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            //base.OnPreviewGUI(r, background);
            GUI.Label(r, target.name + " ‘§¿¿¡À");
        }
    }
}