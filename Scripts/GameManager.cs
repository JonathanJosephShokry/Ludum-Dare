using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endGameUi;
    public GameObject respawnUi;
    public GameObject pauseUi;
    public GameObject playerPrefab;
    public cameraController cam;
    public mainGood Creature;
    public Slider slider;
    public Text text;
    public GameObject[] enemys;
    public Timer timer;
    public Text score;
    public Text highScoreText;
    public Text highScoreText2;
    public Image fill;
    private string highScore;
    private float highScoreMin;
    private float highScoreSec;
    private float gameScoreMin;
    private float gameScoreSec;

    private void Start()
    {
        Time.timeScale = 1;
        highScore = PlayerPrefs.GetString("Score", highScore);
        if(highScore != null && highScore != "" && highScore[0] != ' ')
        {
            Debug.Log(highScore);
            string[] splitArray = highScore.Split(char.Parse(":"));
            highScoreMin = float.Parse(splitArray[0]);
            highScoreSec = float.Parse(splitArray[1]);
            highScoreText2.text = highScore;
            highScoreText.text = highScore;
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void GameEnded()
    {
        Time.timeScale = 1;
        score.text = timer.Stopp();
        gameScoreMin = float.Parse(timer.Min());
        gameScoreSec = float.Parse(timer.Sec());

        if (highScore == null)
        {
            highScore = score.text;
        }
        else if(highScore != null)
        {
            if(gameScoreMin > highScoreMin)
            {
                highScore = timer.Stopp();
                SaveHighScore(highScore);
            }
            else if(gameScoreMin == highScoreMin)
            {
                if (gameScoreSec > highScoreSec)
                {
                    highScore = timer.Stopp();
                    SaveHighScore(highScore);
                }
            }
        }
        endGameUi.SetActive(true);
        respawnUi.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHealth(float _float)
    {
        if (_float < 0 ) { _float = 0; }
        slider.value = _float / 50;
        text.text = Mathf.Round(_float).ToString();
        if (_float < 10)
        {
            fill.color = Color.red;
        }else
        {
            fill.color = new Color32(0,255,178,255);
        }
    }

    public void PlayerDead()
    {
        respawnUi.SetActive(true);

    }

    public void Respawn()
    {
        Time.timeScale = 1;
        Creature.TakeDamage(20f);
        respawnUi.SetActive(false);
        GameObject lol = Instantiate(playerPrefab, new Vector3(10f, 0f, 0f), Quaternion.identity);
        lol.name = "Player";
        cam.FindPlayer();
    }

    private void SaveHighScore(string _score)
    {
        PlayerPrefs.SetString("Score", _score);
        highScoreText.text = _score;
        highScoreText2.text = _score;
    }

    public void one()
    {
        Time.timeScale = 1;
    }

    public void two()
    {
        Time.timeScale = 2;
    }

    public void four()
    {
        Time.timeScale = 4;
    }

    public void Resume()
    {
        pauseUi.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pauseUi.SetActive(true);
        Time.timeScale = 0;
    }
}
