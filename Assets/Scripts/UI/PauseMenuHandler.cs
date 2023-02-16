using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class PauseMenuHandler : MonoBehaviour
{
    public GameObject menu;
    public GameObject scoreboard;

    public TextMeshProUGUI headerText;
    public TextMeshProUGUI scoreText;

    private string _playername;

    public TMP_InputField input;

    public GameObject resumeButton;

    public GameLoop loop;
    private bool _open = false;
    private bool _scoreboard = false;

    public HighscoreList highscoreList;
    public HighscoreManager manager;

    private void Awake()
    {
        ScoreBoardState(false);
        menu.SetActive(false);
    }

    private void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (!loop.GameOver || !_scoreboard)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) // || Implement Mobile UI Button
            {
                _open = !_open;
                MenuState(_open);
            }
        }
    }

    public void MenuState(bool state)
    {
        if (state)
        {
            menu.SetActive(true);
            scoreText.text = loop.GameScore.ToString();

            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
            menu.SetActive(false);
            _open = false;

        }
    }

    public void ScoreBoardState(bool state)
    {
        if (state)
        {
            if (loop.GameOver) { scoreboard.GetComponent<HighscoreList>().resumeButton.gameObject.SetActive(false); MenuState(false); }
            scoreboard.SetActive(true);
            scoreboard.GetComponent<HighscoreList>().CleanList();
            scoreboard.GetComponent<HighscoreList>().LoadHighScoreTable();
            MenuState(false);
            Time.timeScale = 0f;
        }
        else
        {
            scoreboard.SetActive(false);
            Time.timeScale = 1.0f;
            _scoreboard = false;

        }
    }

    public void returntoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void changePlayerName(string value)
    {
        _playername = value;
    }

    public void AddToHighScore()
    {
        if (_playername != null)
        {
            manager.Add(_playername, loop.GameScore);
            resumeButton.gameObject.SetActive(false);
            loop.GameOver = true;
        }
    }
}
