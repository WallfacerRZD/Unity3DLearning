using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform startPoint;
    private Transform spawnPoint;
    private Transform quitPoint;
    private Pin currentPin;
    private quitButton button;
    private bool isGameOver;
    public Camera mainCamera;
    public  Text scoreText;
    public int score;
    // Use this for initialization
    public GameObject pinPrefab;
    public GameObject quitButton;
    public float speed = 3;
    void Start()
    {
        isGameOver = false;
        startPoint = GameObject.Find("StartPoint").transform;
        spawnPoint = GameObject.Find("SpawnPoint").transform;
        //quitPoint = GameObject.Find("quitPoint").transform;
        SpawnPin();
    }

    void SpawnPin()
    {
        currentPin = GameObject.Instantiate(pinPrefab, spawnPoint.position, pinPrefab.transform.rotation).GetComponent<Pin>();
    }

    void SpawnButton()
    {
        //button = GameObject.Instantiate(quitButton, quitPoint.position, quitPoint.rotation).GetComponent<>
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                score += 5;
                scoreText.text = score.ToString();
                currentPin.StartFly();
                SpawnPin();
            }

        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        GameObject.Find("Circle").GetComponent<RotateSelf>().enabled = false;
        StartCoroutine(GameOverAnination());
        isGameOver = true;
    }

    IEnumerator GameOverAnination()
    {
        while (true)
        {
            mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, Color.red, speed * Time.deltaTime);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, 4, speed * Time.deltaTime);
            if(Mathf.Abs(mainCamera.orthographicSize - 4) < 0.02f)
            {
                break;
            }
            yield return 0;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    


}
