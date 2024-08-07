using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR 
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI bestPlayerAndScoreText;

    private void Start()
    {
        RecordIO.Instance.Load();
        string theBestPlayerName = RecordIO.Instance.theName;
        string theBestScore = RecordIO.Instance.theScore.ToString();
        Debug.Log("theBestPlayer: " + theBestPlayerName);
        Debug.Log("theBestScore: " + theBestScore);
        bestPlayerAndScoreText.text = $"Best Score: {theBestPlayerName}: {theBestScore}";
    }

    public void SetPlayerName() 
	{
        RecordIO.Instance.theName = playerNameInput.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
	}
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
