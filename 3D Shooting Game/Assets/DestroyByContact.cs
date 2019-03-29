using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion_asteroid;
    public GameObject explosion_player;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
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
            gameController.SetGameover(true);

        }
        if (other.tag == "Bolt")
        {
            gameController.AddSocre(1);

            Instantiate(explosion_asteroid, transform.position, transform.rotation);         
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }


    }


}
