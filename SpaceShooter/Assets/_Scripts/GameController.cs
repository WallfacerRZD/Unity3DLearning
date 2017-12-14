using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject asteriod;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveTime;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private int score;
    private bool restart;
    private bool gameOver;

    // Use this for initialization
    void Start () {
        score = 0;
        UpdateScore();
        restartText.text = "";
        gameOverText.text = "";
        restart = false;
        gameOver = false;
        StartCoroutine(SpawnWaves());
	}

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                //重新加载游戏
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                Vector3 spawnPositon = new Vector3(
                    Random.Range(-spawnValue.x, spawnValue.x),
                    spawnValue.y,
                    spawnValue.z);
                Quaternion spwnRotation = Quaternion.identity;
                Instantiate(asteriod, spawnPositon, spwnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            if (gameOver == true)
            {
                break;
            }
            yield return new WaitForSeconds(waveTime);
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "GameOver!!";
        gameOver = true;
    }

    public void Restart()
    {
        restartText.text = "Press R to restart";
        restart = true;
    }
	
}
