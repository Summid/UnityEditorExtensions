using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorExtensions
{
    public class IMGUIRuntimeExample : MonoBehaviour
    {
        private GUILayoutAPI layoutAPI = new GUILayoutAPI();
        private GUIAPI guiAPI = new GUIAPI();
        private int index;
        private void OnGUI()
        {
            this.index = GUILayout.Toolbar(this.index, new string[] { "GUILayoutAPI", "GUIAPI" });

            if (this.index == 0)
            {
                this.layoutAPI.Draw();
            }
            else if (this.index == 1)
            {
                this.guiAPI.Draw();
            }

        }
    }
}