using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objects;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private int score;
    private float limitX = 4.0f;
    private float startDelay = 3.0f;
    private float spawnDelay = 2.0f;
    public bool isGameActive;

    void Start() { 
        
    }

    // Update is called once per frame
    void Update() { }

    void SpawnRandom()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-limitX, limitX), 0, 0);
        GameObject randomObject = objects[Random.Range(0, objects.Count)];

        Instantiate(randomObject, spawnPos, randomObject.transform.rotation);
    }

    public void UpdateScore(int incomingScore)
    {
        score += incomingScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        
        restartButton.gameObject.SetActive(true);

        CancelInvoke();
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        InvokeRepeating("SpawnRandom", startDelay, spawnDelay);
        score = 0;
        UpdateScore(0);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        isGameActive = true;
    }
}
