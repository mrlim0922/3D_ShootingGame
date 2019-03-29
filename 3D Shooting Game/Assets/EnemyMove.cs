using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public float speed;
    public float randomSpeed = 0f;
    public Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {

        speed = Random.Range(speed, speed + randomSpeed);

        rigidbody.velocity =
            transform.forward * -speed;
         Destroy(gameObject, 5f);

    }
    private void Update()
    {
        if (transform.position.z < -25)
        {
            Destroy(gameObject);
        }
    }
}
