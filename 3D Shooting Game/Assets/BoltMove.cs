using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMove : MonoBehaviour {

    public float speed;
    public Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody.velocity =
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
