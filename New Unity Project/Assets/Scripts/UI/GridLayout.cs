using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridLayout : MonoBehaviour {
    GameObject input;
    public GameObject trigger;
    GameObject TextShow;
    // Use this for initialization
    void Start () {
        init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void init()
    {
        input = GameObject.Find("Canvas/tb2/InputField");
        //trigger = GameObject.Find("Canvas/trigger");
        TextShow = GameObject.Find("Canvas/tb2/ScrollRectPanel/GridLayoutPanel/Text");
        input.SetActive(false);
        trigger.SetActive(false);
    }

    public void showInput()
    {
        TextShow.GetComponent<Text>().text = "";
        input.SetActive(true);
        trigger.SetActive(true);
    }
}
