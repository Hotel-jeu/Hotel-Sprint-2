using UnityEditor;
using UnityEngine;

public class FindUnusedAssets : EditorWindow
{
    private string searchInFolder = "Assets/MyAssets"; // Specify the directory to search within

    [MenuItem("Tools/Find Unused Assets")]
    public static void ShowWindow()
    {
        var window = GetWindow<FindUnusedAssets>("Find Unused");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Search in Folder", EditorStyles.boldLabel);
        searchInFolder = EditorGUILayout.TextField(searchInFolder);

        if (GUILayout.Button("Find Unused Assets"))
        {
            FindAssets(searchInFolder);
        }
    }

    private static void FindAssets(string folder)
    {
        string[] assets = AssetDatabase.FindAssets("", new[] { folder });
        foreach (string assetGUID in assets)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
            if (AssetDatabase.GetDependencies(assetPath, true).Length == 1)
            {
                // Check if the asset is a script or a built-in Unity asset
                if (!assetPath.StartsWith("Assets/Unity") && !assetPath.EndsWith(".cs"))
                {
                    Debug.Log("Unused Asset: " + assetPath, AssetDatabase.LoadAssetAtPath<Object>(assetPath));
                }
            }
        }
    }
}
