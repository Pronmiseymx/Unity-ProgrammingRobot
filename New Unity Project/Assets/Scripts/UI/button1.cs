using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class button1 : MonoBehaviour {

    GameObject panel1;
    GameObject panel2;
    GameObject tb1;
    GameObject tb2;
    static public int op = 1;

    // Use this for initialization
    void Start() {
        panel1 = GameObject.Find("Canvas/Button1/Panel");
        panel2 = GameObject.Find("Canvas/Button2/Panel");
        tb1 = GameObject.Find("Canvas/tb1");
        tb2 = GameObject.Find("Canvas/tb2");
        ckButton1();
    }


    public void ckButton1()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
        tb1.SetActive(true);
        tb2.SetActive(false);
        op = 1;
        /*
        panel1.enabled = true;
        panel2.enabled = false;
        tb1.enabled = true;
        tb2.enabled = false;
        */
    }

    public void ckButton2()
    {
        panel2.SetActive(true);
        panel1.SetActive(false);
        tb2.SetActive(true);
        tb1.SetActive(false);
        op = 2;
        /*
        panel2.enabled = true;
        panel1.enabled = false;
        tb2.enabled = true;
        tb1.enabled = false;
        */
    }
}
