using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float speed;
    public float randomSpeed = 0f;
    public Rigidbody ItemRigidbody;

    // Use this for initialization
    void Start()
    {
        ItemRigidbody.velocity =
            transform.forward * -speed;
    }

    private void Update()
    {
        if (transform.position.z < -25)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.PlayerDamage += 1;
            Destroy(gameObject);
        }
    }
}

