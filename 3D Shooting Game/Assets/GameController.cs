using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text scoreText;
    public GameObject gameoverText;
    public bool isGameover = false;
    private int score = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
        UpdateSocre();
    }

    public void SetGameover(bool gameOverValue)
    {
        isGameover = gameOverValue;
    }

    private void Update()
    {
        if(isGameover)
        {
            gameoverText.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("2dshooting");


        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
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
