
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
// https://forum.unity.com/threads/adding-layer-by-script.41970/
#if UNITY_EDITOR
namespace UnityEngine.Rendering.Toon.Samples
{
    [InitializeOnLoad]
    public class SceneLayerSetterForSamples 
    {
        // Start is called before the first frame update
        static SceneLayerSetterForSamples()
        {
            SetLayerName(30, "Postprocessing");
        }

        public static void SetLayerName(int layerIndex, string layerName)
        {
            UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
            if (asset == null)
            {
                return;
            }
            if (asset.Length == 0)
            {
                return;
            }
            SerializedObject serializedObject = new SerializedObject(asset[0]);
            SerializedProperty layers = serializedObject.FindProperty("layers");

            for (int i = 0; i < layers.arraySize; ++i)
            {
                if (layers.GetArrayElementAtIndex(i).stringValue == layerName)
                {
                    return;     // Layer already present, nothing to do.
                }
            }

            //  layers.InsertArrayElementAtIndex(0);
            //  layers.GetArrayElementAtIndex(0).stringValue = layerName;
            Debug.Log("arraySize =  " + layers.arraySize);
            for (int i = 0; i < layers.arraySize; i++)
            {
                if (layers.GetArrayElementAtIndex(i).stringValue == "" && layerIndex == i)
                {
                    // layers.InsertArrayElementAtIndex(i);
                    layers.GetArrayElementAtIndex(i).stringValue = layerName;
                    serializedObject.ApplyModifiedProperties();
                    serializedObject.Update();
                    if (layers.GetArrayElementAtIndex(i).stringValue == layerName)
                    {
                        return;     // to avoid unity locked layer
                    }
                }
            }
        }
    }
}
#endif