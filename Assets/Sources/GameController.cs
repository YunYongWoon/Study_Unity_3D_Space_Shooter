using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject[] hazards;
    public float startWait = 1;
    public float spawnWait = 0.75f;
    public float waveWait = 2;

    public Text scoreText;
    public Text restartText;
    public Text GameOverText;

    int score;
    bool gameover;
    bool restart;

    void Start() {
        score = 0;
        restartText.text = "";
        GameOverText.text = "";
        gameover = false;
        restart = false;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    public void AddScore(int newScore) {
        score += newScore;
        UpdateScore();
    }

    public void GameOver() {
        GameOverText.text = "Game Over!!!";
        gameover = true;
    }

    void UpdateScore() {
        scoreText.text = "Score : "+score;
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);

        while (true) {
            for (int i = 0; i < 10; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-5,5), 5, 16);
                Quaternion spawnRotation = Quaternion.Euler(new Vector3(0, 180, 0));

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover == true) { 
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    void Update() {
        if(restart == true) {
            if (Input.GetKeyDown(KeyCode.R) == true) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
