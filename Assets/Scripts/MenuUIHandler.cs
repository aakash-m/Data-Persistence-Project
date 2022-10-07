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

    private void Start()
    {
        DataPersistence.Instance.LoadDataValue();
        if (DataPersistence.Instance.GetPlayerScore() != 0)
        {
            scoreText.text = $"Best Score: {DataPersistence.Instance.GetPlayerScore()}";
        }


    }

    public void startNew()
    {
        SceneManager.LoadScene(1);
        DataPersistence.Instance.SetPlayerName(inputField.text);
        DataPersistence.Instance.SaveDataValues();

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
