using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public List<GameObject> powerUPs = new List<GameObject>();

    private Vector2 screenborder = new Vector2();

    public float currentGameTime;

    public float nextEnemySpawn = 20f;
    public int powerUpCounter = 0;


    public Camera _cam;
    public TextMeshProUGUI TimerTxt;
    public TextMeshProUGUI ScoreTxt;

    public int GameScore = 0;
    public bool GamePause = false;

    public bool GameOver = false;

    private int Delay = 1;
    private float _secondsTimer;

    [SerializeField]
    private PauseMenuHandler _pauseMenu;


    private void Start()
    {
        screenborder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 5));

        TimerTxt = GameObject.FindGameObjectWithTag("GameTime").GetComponent<TextMeshProUGUI>();
        ScoreTxt = GameObject.FindGameObjectWithTag("GameScore").GetComponent<TextMeshProUGUI>();

        Time.timeScale = 1.0f;

    }

    private void Update()
    {
        if(!GamePause)
        {
            _secondsTimer += Time.deltaTime;
            if (_secondsTimer >= Delay)
            {
                _secondsTimer = 0f;
                AddScore(1);
            }

            if (nextEnemySpawn > 0)
            {
                nextEnemySpawn -= Time.deltaTime;
            }
            else
            {
                spawnNextEnemy();
                powerUpCounter++;
                nextEnemySpawn = 5f;
            }

            if(powerUpCounter == 10)
            {
                spawnPowerUp();
                powerUpCounter = 0;
            }

            updateTimer();
        }

        CheckGameState();
    }

    private void CheckGameState()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            _pauseMenu.MenuState(true);
            _pauseMenu.headerText.text = "Total Score:";
            _pauseMenu.resumeButton.gameObject.SetActive(false);
            GameOver = true;
        }
    }

    private void updateTimer()
    {
        currentGameTime += Time.deltaTime;

        float minutes = Mathf.FloorToInt(currentGameTime / 60);
        float seconds = Mathf.FloorToInt(currentGameTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void AddScore(int score)
    {
        GameScore += score;
        ScoreTxt.text = GameScore.ToString();
    }

    private void spawnNextEnemy()
    {
        Vector3 spawnposition = new Vector3(Random.Range(-screenborder.x, screenborder.x), screenborder.y + 4, 4);
        Instantiate(enemies[Random.Range(0, enemies.Count)], spawnposition, Quaternion.identity);
    }

    private void spawnPowerUp()
    {
        Vector3 spawnposition = new Vector3(Random.Range(-screenborder.x, screenborder.x), screenborder.y + 4, 4);
        Instantiate(powerUPs[Random.Range(0, powerUPs.Count)], spawnposition, Quaternion.identity);
    }

}
