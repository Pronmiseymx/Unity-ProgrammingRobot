using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_bt : MonoBehaviour {
    //开始界面
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void start()
    {
        SceneManager.LoadScene("Choice");
    }
    public void end()
    {
        Application.Quit();
    }
}
