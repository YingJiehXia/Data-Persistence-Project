using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RecordIO : MonoBehaviour
{
    public string theName;
    public int theScore;

    public static RecordIO Instance;
    private static string savePath => Application.persistentDataPath + "/savefile.json";

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
		}
    }

    [System.Serializable]
    class SaveData {
        public string name;
        public int score;
	}

    public void Save()
    {
        SaveData dataToSave = new SaveData();
        dataToSave.name = theName;
        dataToSave.score = theScore;
        string json = JsonUtility.ToJson(dataToSave);
        File.WriteAllText(savePath, json);
	}
    
    public void Load()
    {
        if (File.Exists(savePath))
        {
            Debug.Log("data loaded");
            SaveData loadedData;
            string json = File.ReadAllText(savePath);
            Debug.Log(json);
            loadedData = JsonUtility.FromJson<SaveData>(json);
            theName = loadedData.name;
            theScore = loadedData.score;
        }
        else {
            Debug.Log("no record");
            theName = "";
            theScore = 0;
		}
    }

}
