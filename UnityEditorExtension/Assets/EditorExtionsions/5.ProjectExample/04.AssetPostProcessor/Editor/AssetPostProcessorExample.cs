using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorExtensions
{
    public class AssetPostProcessorExample : AssetPostprocessor
    {
        private void OnPreprocessTexture()
        {
            Debug.Log("OnPreprocessText:" + this.assetPath);
            TextureImporter importer = this.assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;
            importer.maxTextureSize = 512;
            importer.mipmapEnabled = false;
        }

        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("OnPostprocessText" + texture.name);
        }
    }
}