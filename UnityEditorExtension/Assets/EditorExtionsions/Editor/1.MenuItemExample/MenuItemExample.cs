using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class MenuItemExample
    {
        [MenuItem("EditorExtensions/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
        }

        [MenuItem("EditorExtensions/01.Menu/02.Open Google")]
        static void OpenGoogle()
        {
            Application.OpenURL("https://google.com");
        }
    }
}