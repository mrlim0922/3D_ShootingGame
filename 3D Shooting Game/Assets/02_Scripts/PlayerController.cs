using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public Rigidbody PlayerRigidbody;
    public float speed;
    public Boundary boundary;
    public GameObject shot;
    public GameObject LevelUpEffect;
    public AudioSource PlayerAudio;
    public float fireRate = 0f;
    private float nextFire;
    static public int PlayerDamage = 1;
    public int Exp = 10;

    bool IsLevelUP = false;

    // Use this for initialization
    void Start ()
    {
        GameManager.instance.KillCount = 0;
        IsLevelUP = false;
    }	

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, transform);
            PlayerAudio.Play();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        PlayerRigidbody.velocity = movement * speed;

        PlayerRigidbody.position = new Vector3
        (
            Mathf.Clamp(PlayerRigidbody.position.x,
            boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(PlayerRigidbody.position.z,
            boundary.zMin, boundary.zMax)
         );
        if (!IsLevelUP)
        {
            LevelUp();
        }
        else
        {
            if(GameManager.instance.KillCount % Exp != 0)
                IsLevelUP = false;
        }
    }

    public void LevelUp()
    {
        if (GameManager.instance.KillCount != 0 && GameManager.instance.KillCount % Exp == 0)
        {
            Instantiate(LevelUpEffect, transform.position, transform.rotation);
            PlayerDamage += 1;
            IsLevelUP = true;
        }
    }
}
