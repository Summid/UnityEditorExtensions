using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetModificationProcessorExample : UnityEditor.AssetModificationProcessor
    {
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log($"OnWillCreateAsset {assetName}");
        }

        private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            Debug.Log($"OnWillDeleteAsset {assetPath}/{options}");

            if (EditorUtility.DisplayDialog("删除目录", "确定要删除吗？", "确定","取消"))
            {
                return AssetDeleteResult.DidNotDelete;
            }
            else
            {
                return AssetDeleteResult.FailedDelete;
            }
        }

        private static AssetMoveResult OnWillMoveAsset(string sourcePath, string destinationPath)
        {
            Debug.Log($"OnWillMoveAsset {sourcePath}=>{destinationPath}");

            if (EditorUtility.DisplayDialog("移动目录", $"确定要移动？{sourcePath}=>{destinationPath}", "确定", "取消"))
            {
                return AssetMoveResult.DidNotMove;
            }
            else
            {
                return AssetMoveResult.FailedMove;
            }
        }

        private static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log($"OnWillSaveAssets {paths}");
            return paths;
        }

        private static bool CanOpenForEdit(string[] assetOrMetaFilePaths, List<string> outNotEditablePaths, StatusQueryOptions statusQuery)
        {
            Debug.Log("CanOpenForEdit:");
            return true;
        }

        private static void FileModeChanged(string[] paths, FileMode fileMode)
        {
            Debug.Log($"FileModeChanged ({fileMode})");

            foreach (string path in paths)
            {
                Debug.Log(path);
            }
        }

        private static bool MakeEditable(string[] paths, string prompt, List<string> strings)
        {
            Debug.Log("MakeEditable");

            foreach (string path in paths)
            {
                Debug.Log(path);
            }

            return true;
        }
    }

}
