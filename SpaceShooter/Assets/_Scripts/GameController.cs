using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject asteriod;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnWaves());
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; ++i)
            {
                Vector3 spawnPositon = new Vector3(
                    Random.Range(-spawnValue.x, spawnValue.x),
                    spawnValue.y,
                    spawnValue.z);
                Quaternion spwnRotation = Quaternion.identity;
                Instantiate(asteriod, spawnPositon, spwnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveTime);
        }
    }
	
}
