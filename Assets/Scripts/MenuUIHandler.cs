using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        var saveData = DataPersistence.Instance.LoadDataValue();
        scoreText.text = $"High score {saveData.score} by {saveData.playerName}";
    }

    public void startNew()
    {
        SceneManager.LoadScene(1);
        DataPersistence.Instance.playerName = inputField.text;

    }

    public void Exit()
    {
        DataPersistence.Instance.SaveDataValues();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
