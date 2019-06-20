using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {

    static GameObject Particle;//粒子
    static GameObject robot;
    static GameObject send;
    static GameObject am;
    static GameObject oj;//创建物体
    static Vector3 ve;//物体位置
    static Vector3 sca;
    static Quaternion rot;
    static string Name;

    static int op;//1:传送 2：销毁 3：创建
    public GameObject p;//粒子(中间)


    // Use this for initialization
    void Start () {
        Particle = p;
        op = -1;
    }
	
	// Update is called once per frame
	void Update () {
        switch(op)
        {
            case 1: sendS();break;
            case 2: DelS();break;
            case 3: CreatS();break;
        }
        op = -1;
	}

    static public void Send(GameObject Probot, GameObject Psend)
    {
        robot = Probot;
        send = Psend;
        op = 1;
    }
    static public void Del(GameObject Pam)
    {
        am = Pam;
        op = 2;
    }
    static public void Creat(GameObject go, Vector3 pos, Vector3 sc, Quaternion ro, string nm)
    {
        op = 3; 
        oj = go; 
        ve = pos; 
        sca = sc; 
        rot = ro; 
        Name = nm;
    }                                 

    void CreatS()
    {
        GameObject gmoj;
        gmoj = GameObject.Instantiate(oj);
        gmoj.transform.name = name;
        gmoj.transform.position = ve;
        gmoj.transform.localScale = sca;
        gmoj.transform.rotation = rot;
    }

    void sendS()
    {
        GameObject send1 = GameObject.Find("send_1_B");
        GameObject send2 = GameObject.Find("send_1_E");
        GameObject send3 = GameObject.Find("send_2_B");
        GameObject send4 = GameObject.Find("send_2_E");
        GameObject Am = send;
        switch(send.transform.name)
        {
            case "send_1_B": Am = send2; break;
            case "send_1_E": Am = send1; break;
            case "send_2_B": Am = send4; break;
            case "send_2_E": Am = send3; break;
        }
        Robot.isSend = 0;
        Robot.Am = Am;
        robot.transform.position = Am.transform.position;
        robot.transform.forward = Am.transform.forward;
        Invoker.nowP = robot.transform.position;
        Invoker.index++;
        Invoker.SetAnimatorIdle();
    }

    public void DelS()
    {
        GameObject clone = GameObject.Instantiate(Particle);

        op = 2;
        clone.transform.parent = am.transform;
        clone.transform.position = am.transform.position;
        clone.transform.localScale = new Vector3(1, 1, 1);
        Invoke("Delayed", 1f);
    }

    void Delayed()
    {
        Destroy(am);
        Debug.Log("1");
    }
}
