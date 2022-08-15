using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace EditorExtensions
{
    [InitializeOnLoad]//�༭��֧�֣�����ʱҲ�ᴥ�������ؽű�ʱ��ʼ��
    public class EditorEventAttributeExample : MonoBehaviour
    {
        //��̬���죬�����һ�α���ȡʱ��Ч
        static EditorEventAttributeExample()
        {
            Debug.Log("EditorEventAttributeExample");
        }

        [InitializeOnLoadMethod]//�༭��֧�֣�����ʱҲ�ᴥ�������ڱ�Ǿ�̬����
        static void InitializeOnLoadMethod()
        {
            Debug.Log("InitializeOnLoadMethod");
        }

        //[RuntimeInitializeOnLoadMethod]//����ʱ֧��

        [DidReloadScripts()]
        static void OnScriptReload()
        {
            Debug.Log("�ű��������");
        }

        [PostProcessScene]//���س�������Ч
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        [PostProcessBuild]//build����������
        static void OnPostProcessBuild(BuildTarget target,string pathToBuildProject)
        {
            Debug.Log("OnPostProcessBuild");
        }

        [OnOpenAsset(1)]//˫����assetʱ����
        static bool OpenAsset(int instanceID,int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID).name;
            Debug.Log("Open Asset step:1 (" + name + ")");
            return false;//we did not handle the open
            //�����������Դ�򿪲������򷵻�true
            //�����ԴӦ�����ⲿ���ߴ򿪣��򷵻�false
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