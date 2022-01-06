using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Test
{
    [CustomEditor(typeof(MyObject))]
    public class MyObjectInspector : Editor
    {
        List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        bool needInit = true;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            MyObject myObject = (MyObject)target;
            EditorGUILayout.LabelField(myObject.anInt.ToString());
            EditorGUILayout.LabelField(myObject.anString.ToString());
            EditorGUILayout.LabelField(myObject.anIntArray.ToString());

            //myObject.anIntArray = this.list;
            SerializedProperty arrayPro = serializedObject.FindProperty("anIntArray");
            EditorGUILayout.PropertyField(arrayPro, new GUIContent("anIntArray"));
            if(this.needInit)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    arrayPro.InsertArrayElementAtIndex(i);
                    var serializedOB = arrayPro.GetArrayElementAtIndex(i);
                    serializedOB.intValue = list[i];

                }
                this.needInit = false;
            }
            for (int i = 0; i < arrayPro.arraySize; i++)
            {
                var Ob = arrayPro.GetArrayElementAtIndex(i);
                EditorGUILayout.LabelField(Ob.intValue.ToString());
            }
            //foreach(int item in myObject.anIntArray)
            //{
            //    EditorGUILayout.LabelField(item.ToString());
            //}
            //for (int i = 0; i < myObject.anIntArray.Count; i++)
            //{
            //    myObject.anIntArray[i]++;
            //}
            EditorGUILayout.ObjectField(serializedObject.FindProperty("anGameObject"));

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }

}
