using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState1 { InGame, GameOver};

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public GameObject gameoverText;

    public Text scoreText;

    public Vector3 spawnValues;

    public float spawnWait;
    public float startWait;
    public float waveWait;

    public bool GameState = false;

    public int hazardCount;
    private int score = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        UpdateSocre();
        GameManager.instance.SpawnCount = 0;
    }

    private void Update()
    {
        if (GameState == true)
        {
            gameoverText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (!GameState)
        {
            if (GameManager.instance.SpawnCount != 0 && GameManager.instance.SpawnCount % 10 == 0)
            {
                waveWait -= 1f;
            }

            GameManager.instance.SpawnCount += 1;

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 
                    spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void SetGameState(bool gameState)
    {
        GameState = gameState;
    }

    public void AddSocre(int scoreValue)
    {
        score = score + scoreValue;
        UpdateSocre();
    }
   
    void UpdateSocre()
    {
        scoreText.text = "Score: " + score;
    }
}
