using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreList : MonoBehaviour
{
    public HighscoreManager manager;
    public Transform HighscoreContainer;
    public Transform HighscoreEntryTransform;

    private List<Transform> highscoreEntryTransformList;

    public Button resumeButton;

    private void Awake()
    {
        LoadHighScoreTable();
    }
    public void LoadHighScoreTable()
    {

        HighscoreEntryTransform.gameObject.SetActive(false);

        var highscores = manager.List();

        //Sort List
        for (int i = 0; i < highscores.Count; i++)
        {
            for (int j = i + 1; j < highscores.Count; j++)
            {
                if (highscores[j].Score > highscores[i].Score)
                {
                    var tmp = highscores[i];
                    highscores[i] = highscores[j];
                    highscores[j] = tmp;
                }
            }
        }

        if (highscores.Count > 5)
        {
            for (int h = highscores.Count; h > 5; h--)
            {
                highscores.RemoveAt(5);
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (var entry in highscores)
        {
            CreateHighScoreEntryTransform(entry, HighscoreContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighscoreManager.HighscoreEntry highscoreEntry, Transform Container, List<Transform> transformlist)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(HighscoreEntryTransform, Container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformlist.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;
        }


        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.Score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.Name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformlist.Add(entryTransform);
        highscoreEntryTransformList = transformlist;

    }

    public void CleanList()
    {
        foreach (var entry in highscoreEntryTransformList)
        {
            Destroy(entry.gameObject);
        }
    }
}
