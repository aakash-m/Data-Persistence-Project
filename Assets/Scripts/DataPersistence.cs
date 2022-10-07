using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    private string playerName;
    private int playerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }
    public int GetPlayerScore()
    {
        return playerScore;
    }

    [System.Serializable]
    class SaveData
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

    public void LoadDataValue()
    {
        string filePath = Application.persistentDataPath + "/saveFile.json";
       
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonString);

            playerName = saveData.playerName;
            playerScore = saveData.score;

        }
        
    }

}
