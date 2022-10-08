using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public string playerName { get; set; }
    public int playerScore { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            LoadDataValue();
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveDataValues()
    {
        SaveData saveData = new SaveData();
        saveData.playerName = playerName;
        saveData.score = playerScore;

        string jsonString = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jsonString);

    }

    public SaveData LoadDataValue()
    {
        string filePath = Application.persistentDataPath + "/saveFile.json";
       
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonString);

            return saveData;

        }

        return null;
        
    }

}
