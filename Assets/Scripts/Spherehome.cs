using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spherehome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject sphere = GameObject.Find("Sphere");
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(250f,-250f,0));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
