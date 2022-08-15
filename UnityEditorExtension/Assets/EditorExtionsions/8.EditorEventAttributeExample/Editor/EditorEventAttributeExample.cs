using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace EditorExtensions
{
    [InitializeOnLoad]//编辑器支持，运行时也会触发，加载脚本时初始化
    public class EditorEventAttributeExample : MonoBehaviour
    {
        //静态构造，该类第一次被获取时生效
        static EditorEventAttributeExample()
        {
            Debug.Log("EditorEventAttributeExample");
        }

        [InitializeOnLoadMethod]//编辑器支持，运行时也会触发，用于标记静态方法
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }

        //[RuntimeInitializeOnLoadMethod]//运行时支持

        [DidReloadScripts()]
        static void OnScriptReload()
        {
            Debug.Log("脚本加载完毕");
        }

        [PostProcessScene]//加载场景后生效
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        [PostProcessBuild]//build、打包后调用
        static void OnPostProcessBuild(BuildTarget target,string pathToBuildProject)
        {
            Debug.Log("OnPostProcessBuild");
        }

        [OnOpenAsset(1)]//双击打开asset时调用
        static bool OpenAsset(int instanceID,int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:1 (" + name + ")");
            return false;//we did not handle the open
            //如果处理了资源打开操作，则返回true
            //如果资源应该由外部工具打开，则返回false
        }
        
        [OnOpenAsset(2)]
        static bool OpenAsset2(int instanceID,int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:2 (" + name + ")");
            return false;
        }


    }
}