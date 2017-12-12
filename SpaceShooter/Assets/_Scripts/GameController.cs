using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteriod;
    public Vector3 spawnValue;

	// Use this for initialization
	void Start () {
        Spawn();
	}

    void Spawn()
    {
        Vector3 spawnPositon = new Vector3(
            Random.Range(-spawnValue.x, spawnValue.x),
            spawnValue.y,
            spawnValue.z);

        Quaternion spwnRotation = Quaternion.identity;
        Instantiate(asteriod, spawnPositon, spwnRotation);
    }
	
}
