using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed;
    public float randomSpeed = 0f;
    public Rigidbody EnemyRigidbody;

    // Use this for initialization
    void Start()
    {
        EnemyRigidbody.velocity =
            transform.forward * -speed;
         //Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if (GameManager.instance.SpawnCount != 0 && GameManager.instance.SpawnCount % 10 == 0)
        {
            speed += 0.5f;
        }

        if (transform.position.z < -25)
        {
            Destroy(gameObject);
        }
    }
}
