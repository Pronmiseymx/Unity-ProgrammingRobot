using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {
    public float speed = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Revolve();
    }

    void Revolve()
    {
        transform.Rotate(new Vector3(0,1*Time.deltaTime*speed, 0));
    }
}
