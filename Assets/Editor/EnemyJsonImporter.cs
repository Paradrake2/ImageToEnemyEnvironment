#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;
public class EnemyJsonImporter : EditorWindow
{
    private TextAsset jsonFile;
    private string outputFolder = "Assets/Resources/EnemyDefinitions/";

    [MenuItem("Tools/Import Enemy Definitions from JSON")]
    public static void ShowWindow() => GetWindow<EnemyJsonImporter>("Enemy JSON Importer");
    void OnGUI()
    {
        EditorGUILayout.LabelField("Enemy JSON Importer", EditorStyles.boldLabel);
        jsonFile = (TextAsset)EditorGUILayout.ObjectField("JSON File", jsonFile, typeof(TextAsset), false);
        outputFolder = EditorGUILayout.TextField("Output Folder", outputFolder);

        using (new EditorGUI.DisabledScope(jsonFile == null))
        {
            if (GUILayout.Button("Import"))
            {
                ImportJson(jsonFile.text, jsonFile.name);
            }
        }

        //EditorGUILayout.Space(8);

    }

    void ImportJson(string jsonContent, string fileName)
    {
        EnemyData data;
        try
        {
            data = JsonUtility.FromJson<EnemyData>(jsonContent);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to parse JSON: {e.Message}");
            return;
        }

        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        var def = ScriptableObject.CreateInstance<EnemyDefinition>();
        def.enemyName = string.IsNullOrWhiteSpace(data.name) ? fileName : data.name;
        def.level = Mathf.Max(1, data.level);

        def.hp = Mathf.Max(1, data.stats.hp);
        def.attack = Mathf.Max(0, data.stats.attack);
        def.defense = Mathf.Max(0, data.stats.defense);
        def.speed = Mathf.Max(0, data.stats.speed);

        def.behaviors = EnemyAIBehavior.Melee;
        if (data.behaviors != null && data.behaviors.Length > 0)
        {
            var b = data.behaviors[0].Trim().ToLowerInvariant();
            if (b == "ranged") def.behaviors = EnemyAIBehavior.Ranged;
            else def.behaviors = EnemyAIBehavior.Melee;
        }


        AssetDatabase.CreateAsset(def, Path.Combine(outputFolder, $"{fileName}.asset"));
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorGUIUtility.PingObject(def);
    }
}
#endif