using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtensions
{
    public class AssetDatabaseExample : MonoBehaviour
    {
        private const string FolderPath = "Assets/EditorExtionsions/5.ProjectExample/02.AssetDatabase";
        private const string FolderName = "NewFolder";
        private const string NewFolderPath = FolderPath + "/" + FolderName;
        private const string NewMaterialPath = NewFolderPath + "/New Materials.mat";

        private const string MENU_PATH = "EditorExtensions/03.Project/01.AssetDatabase";

        [MenuItem(MENU_PATH + "CreateMaterial")]
        private static void CreateMaterial()
        {
            if (!Directory.Exists(NewFolderPath))
            {
                string guid = AssetDatabase.CreateFolder(FolderPath, FolderName);
                if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(guid)))
                {
                    Debug.Log("Folder Asset Create! " + guid);
                }
                else
                {
                    Debug.Log(guid);
                }
            }

            Material material = new Material(Shader.Find("Specular"));//随便整一个shader
            AssetDatabase.CreateAsset(material, NewMaterialPath);

            if (AssetDatabase.Contains(material))
            {
                Debug.Log(material.name + " Created");
            }
            else
            {
                Debug.Log("Failed");
            }
        }

        [MenuItem(MENU_PATH + "GetMaterialGUID")]
        private static void GetGUID()
        {
            Debug.Log(AssetDatabase.AssetPathToGUID(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "LoadMaterial")]
        private static void Load()
        {
            Debug.Log(AssetDatabase.LoadAssetAtPath<Material>(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "RenameMaterial")]
        private static void Rename()
        {
            Debug.Log(AssetDatabase.RenameAsset(NewMaterialPath, "NewName"));
        }

        [MenuItem(MENU_PATH + "MoveMaterial")]
        private static void Move()
        {
            Debug.Log(AssetDatabase.MoveAsset(NewMaterialPath, "Assets/move.mat"));
        }

        [MenuItem(MENU_PATH + "CopyMaterial")]
        private static void Copy()
        {
            Debug.Log(AssetDatabase.CopyAsset(NewMaterialPath, "Assets/copy.mat"));
        }

        [MenuItem(MENU_PATH + "DeleteMaterial")]
        private static void Delete()
        {
            if (EditorUtility.DisplayDialog("确认", "是否将文件放入回收站？", "确认", "不"))
            {
                Debug.Log(AssetDatabase.MoveAssetToTrash(NewMaterialPath));
            }
            else
            {
                Debug.Log(AssetDatabase.DeleteAsset(NewMaterialPath));
            }
        }

        [MenuItem(MENU_PATH + "GetMaterialGUID", validate = true)]
        [MenuItem(MENU_PATH + "LoadMaterial", validate = true)]
        [MenuItem(MENU_PATH + "RenameMaterial", validate = true)]
        [MenuItem(MENU_PATH + "MoveMaterial", validate = true)]
        [MenuItem(MENU_PATH + "CopyMaterial", validate = true)]
        [MenuItem(MENU_PATH + "DeleteMaterial", validate = true)]
        private static bool Check()
        {
            return File.Exists(NewMaterialPath);
        }

    }
}