using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject BulletPrefab;
    public float speed = 3;
	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = GameObject.Instantiate(BulletPrefab, this.transform.position, this.transform.rotation);
            Rigidbody rgb = bullet.GetComponent<Rigidbody>();
            rgb.velocity = transform.forward * speed;
        }
    }
}
