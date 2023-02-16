using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    [Serializable]
    public class HighscoreContainer
    {
        public HighscoreEntry[] Highscores;
    }

    [Serializable]
    public class HighscoreEntry
    {
        public string Name;
        public int Score;
    }

    private const string FileName = "highscore.json";
    private const int MaxHighscore = 5;

    private string HighscoreFilePath => Path.Combine(Application.persistentDataPath, FileName);

    private List<HighscoreEntry> _highscore = new List<HighscoreEntry>();

    private void Awake()
    {
        Load();
    }

    private void OnDestroy()
    {
        Save();
    }

    private void Save()
    {
        var highscoreContainer = new HighscoreContainer()
        {
            Highscores = _highscore.ToArray()
        };

        var json = JsonUtility.ToJson(highscoreContainer);
        File.WriteAllText(HighscoreFilePath, json);
    }

    private void Load()
    {
        Debug.Log(HighscoreFilePath);

        if(!File.Exists(HighscoreFilePath))
        {
            return;
        }

        var json = File.ReadAllText(HighscoreFilePath);
        var highscoreContainer = JsonUtility.FromJson<HighscoreContainer>(json);

        if(highscoreContainer == null || highscoreContainer.Highscores == null)
        {
            return;
        }

        _highscore = new List<HighscoreEntry>(highscoreContainer.Highscores);
    }

    private void Add(HighscoreEntry entry)
    {
        _highscore.Insert(0, entry);

        _highscore = _highscore.Take(MaxHighscore).ToList();
    }

    public void Add(string playerName, int Score)
    {
        var entry = new HighscoreEntry()
        {
            Name = playerName,
            Score = Score
        };

        Add(entry);

    }

    public List<HighscoreEntry> List()
    {
        return _highscore;
    }
}
