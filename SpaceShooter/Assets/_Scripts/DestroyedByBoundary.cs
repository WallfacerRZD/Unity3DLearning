using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedByBoundary : MonoBehaviour {

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {

        Destroy(other.gameObject);
        //Debug.Log("Trigger!");
    }
}
