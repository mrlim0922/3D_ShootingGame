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

    public int EnemyMaxHP = 3;
    public int EnemyCurrentHP = 3;

    protected GameObject EnemyHPBar;
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

        EnemyHPBar = (GameObject)Instantiate(Resources.Load("HPBar"), transform.position
            + new Vector3(0f, 0, 0.7f), Quaternion.Euler(0f, 0f, 0f)) as GameObject;

    }
    private void Update()
    {
        EnemyHPBar.GetComponent<HpBar>().HP(EnemyMaxHP, EnemyCurrentHP);
    }

    void LateUpdate()
    {
        EnemyHPBar.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position
            + new Vector3(0f, 0, 0.7f));
    }

    public void Damage(int temp)
    {
        EnemyCurrentHP -= temp;

        if (EnemyCurrentHP <= 0)
        {
            gameController.AddSocre(1);

            Instantiate(explosion_asteroid, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(EnemyHPBar);
            GameManager.instance.KillCount++;
            //PlayerController.PlayerDamage++;
        }

        if (GameManager.instance.SpawnCount != 0 && GameManager.instance.SpawnCount % 10 == 0)
        {
            EnemyMaxHP += (EnemyMaxHP + 1);
        }
    }

    public void PlayerDeath(Collider other)
    {
        Instantiate(explosion_player, other.transform.position, other.transform.rotation);
        Instantiate(explosion_asteroid, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
        Destroy(EnemyHPBar);
        gameController.SetGameState(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerDeath(other);
        }
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
            Damage(PlayerController.PlayerDamage);
        }
    }
}
