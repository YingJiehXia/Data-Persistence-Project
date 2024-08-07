using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class LoadGameRank : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerText;
    public string bestPlayerName;
    public int bestScore;
    private string savePath;
   
    private void Awake()
    {
        LoadBestScore();
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SetBestPlayerText()
    { 
	    if (bestPlayerName == "")
        {
            bestPlayerText.text = "Best Score: 0";
		}
        else 
		{
            bestPlayerText.text = $"Best Score -  + {bestPlayerName} : {bestScore}";
		}
	}

    public void LoadBestScore() 
	{
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = loadedData.theBestPlayerName;
            bestScore = loadedData.theBestScore;
		}
    }

    public void SaveBestScore()
    {
        SaveData theBestData = new SaveData();
        theBestData.theBestScore = bestScore;
        theBestData.theBestPlayerName = bestPlayerName;
        string json = JsonUtility.ToJson(theBestData);
        File.WriteAllText(savePath, json);
	}

    [System.Serializable]
    class SaveData 
	{
        public int theBestScore;
        public string theBestPlayerName;
	}
}
