using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour {

    public float tumble;
    public float randomTumble = 0f;
    public Rigidbody rigidbody;
    void Start()
    {
        tumble = Random.Range(tumble, tumble + randomTumble);
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
