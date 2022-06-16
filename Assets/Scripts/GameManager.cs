using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string username { get; set; }
    public string maxUsername { get; set; }
    public int maxScore { get; set; }
    public string date;    
    private string persistencePath;

    [System.Serializable]
    private class BestScore
    {
        public string maxUsername;
        public int maxScore;
        public string date;
    }

    private void Awake()
    {
        persistencePath = Application.persistentDataPath + "/saveFile.json";
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        RetrieveData();
    }

    public void SaveData()
    {
        BestScore bestScore = new BestScore();
        bestScore.maxUsername = this.username;
        bestScore.maxScore = this.maxScore;
        bestScore.date = System.DateTime.Now.ToShortDateString();
        File.WriteAllText(persistencePath,JsonUtility.ToJson(bestScore));
    }

    public void RetrieveData ()
    {
        if(File.Exists(persistencePath))
        {
            BestScore bestScore = JsonUtility.FromJson<BestScore>(File.ReadAllText(persistencePath));
            this.maxUsername = bestScore.maxUsername;
            this.maxScore = bestScore.maxScore;
            this.date = bestScore.date;
        }        
    }
}
