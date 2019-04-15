using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion_asteroid;
    public GameObject explosion_player;

    private GameObject GameControllerObject;
    private GameObject PlayerObject;

    private GameController gameController;
    private PlayerController playerController;

    public int EnemyHP = 3;
    //int count = 0;

    private void Start()
    {
        //GameManager.instance.KillCount = 0;
        GameControllerObject = GameObject.FindWithTag("GameController");

        if (GameControllerObject != null)
        {
            gameController = GameControllerObject.GetComponent<GameController>();
        }

        if (GameControllerObject == null)
        {
            Debug.Log("게임콘트롤러 없음");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        { 
            Instantiate(explosion_player, other.transform.position, other.transform.rotation);
            Instantiate(explosion_asteroid, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.SetGameState(true);

        }
        if (other.tag == "Bolt")
        {
            Debug.Log("-1");
            Destroy(other.gameObject);
            EnemyHP -= PlayerController.PlayerDamage;

            if (EnemyHP <= 0)
            {
                gameController.AddSocre(1);

                Instantiate(explosion_asteroid, transform.position, transform.rotation);
                Destroy(gameObject);
                GameManager.instance.KillCount++;
                //PlayerController.PlayerDamage++;
            }

            if(GameManager.instance.SpawnCount != 0 && GameManager.instance.SpawnCount % 10 == 0)
            {
                EnemyHP += (EnemyHP + 1);
            }
        }
    }
}
