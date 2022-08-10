using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class EditorPrefsExample
    {
        private const string key = "ThisIsAKey";

        [MenuItem("EditorExtensions/04.Data/EditorPrefs/SaveTime")]
        private static void SaveTime()
        {
            EditorPrefs.SetString(key, DateTime.Now.ToString());
        }

        [MenuItem("EditorExtensions/04.Data/EditorPrefs/ReadTime")]
        private static void ReadTime()
        {
            Debug.Log(EditorPrefs.GetString(key));
        }
    }
}