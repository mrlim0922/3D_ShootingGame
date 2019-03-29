using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

    public Rigidbody rigidbody;
    public float speed;
    public Boundary boundary;
    public GameObject shot;
    public AudioSource audio;
    public float fireRate = 0f;
    private float nextFire;
    // Use this for initialization
    void Start () {
		
	}	
	// Update is called once per frame
	void Update () {

        if(Input.GetButtonDown("Fire1")  && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, transform);
            audio.Play();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x,
            boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(rigidbody.position.z,
            boundary.zMin, boundary.zMax)
         );

     
	}
}
