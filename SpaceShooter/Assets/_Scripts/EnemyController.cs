using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Transform shotSpawn;
    //public Transform playerPostion;
    public GameObject bolt;
    public float fireInterval;
    private float lastFire;
	
	// Update is called once per frame
	void Update () {
        if (Time.time - lastFire > fireInterval)
        {
            lastFire = Time.time;
            Instantiate(bolt, shotSpawn);
            //Debug.Log(shotSpawn);
        }
	}
}
