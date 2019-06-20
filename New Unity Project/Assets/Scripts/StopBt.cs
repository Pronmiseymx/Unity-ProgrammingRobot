using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopBt : MonoBehaviour {

    GameObject isRecovery;
    // Use this for initialization
    void Start () {
        //this.GetComponent<Button>().interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void click()
    {
        Invoker.Restore();
        Running.initRobot();
        tools.init();
        isRecovery = GameObject.Find("Recovery");
        if (isRecovery != null)
        {
            isRecovery.transform.tag = "isRecovery_Y";
            Debug.Log(isRecovery.transform.tag);
        }

    }

}
