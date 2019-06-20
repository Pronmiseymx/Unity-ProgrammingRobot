using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLevel : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
        GameObject.DontDestroyOnLoad(this.gameObject);
	}
}
