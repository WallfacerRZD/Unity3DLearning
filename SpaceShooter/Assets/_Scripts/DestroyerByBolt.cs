using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerByBolt : MonoBehaviour {

    public GameObject playerExplosion;
    public GameObject gameControllerObject;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            Destroy(gameObject);
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameController gameController = gameControllerObject.GetComponent<GameController>();
            gameController.GameOver();
            gameController.Restart();
        }
    }
}
