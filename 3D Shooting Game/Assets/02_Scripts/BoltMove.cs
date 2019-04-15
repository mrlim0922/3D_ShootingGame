using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour {

    public float speed;
    public Rigidbody BoltRigidbody;

	// Use this for initialization
	void Start () {
        BoltRigidbody.velocity =
            transform.up * speed;
       // Destroy(gameObject, 5f);
	}
    private void Update()
    {      
        if(transform.position.z > 25)
        {
            Destroy(gameObject);
        }
    }

}
