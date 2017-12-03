using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject go;
    // Use this for initialization
    void Start()
    {
        Debug.Log(go.GetComponent<Transform>().name);
        Debug.Log(go.name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
