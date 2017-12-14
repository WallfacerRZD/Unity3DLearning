using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DstroyedByComtact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int socre;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Can not find 'GameController' script!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
            gameController.Restart();
        }
        Instantiate(explosion, transform.position, transform.rotation);
        gameController.AddScore(socre);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
