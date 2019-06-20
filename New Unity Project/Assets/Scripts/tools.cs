using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tools : MonoBehaviour {

	static int redKey;//红钥匙 1
    static int yellowKey;//黄钥匙 2
    static int Axe;//斧子 3
    static int Hammer;//锤子 4
    static int Board;//木板 5

    static GameObject robot;
    static GameObject board;
    public GameObject bd;

    void Start()
    {
        init();
        robot = GameObject.Find("/Cube");
        board = bd;
    }
    

    static public void init()
    {
        redKey = 0;
        yellowKey = 0;
        Axe = 0;
        Hammer = 0;
        Board = 0;
    }

    static public void getTools(int kind, GameObject oj)
    {//1:红钥匙 //2：黄钥匙 //3：斧子 //4：锤子 //5：木板
        switch (kind)
        {
            case 1: ++redKey;break;
            case 2: ++yellowKey; break;
            case 3: ++Axe; break;
            case 4: ++Hammer; break;
            case 5: ++Board; break;
        }
        Destroy(oj);
    }

    static public void useTools(int kind)
    {//1:红钥匙 //2：黄钥匙 //3：斧子 //4：锤子 //5：木板
        switch(kind)
        {
            case 1: UseRedKey(); break;
            case 2: UseYellowKey(); break;
            case 3: UseAxe(); break;
            case 4: UseHammer(); break;
            case 5: UseBoard(); break;
        }
    }

    static void UseRedKey()
    {
        if (redKey < 1) return;
        redKey--;
        RaycastHit hit;
        bool grounded = Physics.Raycast(robot.transform.position + Vector3.up * 0.2f, robot.transform.forward, out hit, 1f);
        if (grounded)
        {
            Environment.Del(hit.collider.gameObject);
        }
    }
    static void UseYellowKey()
    {
        if (yellowKey < 1) return;
        yellowKey--;
        RaycastHit hit;
        bool grounded = Physics.Raycast(robot.transform.position + Vector3.up * 0.2f, robot.transform.forward, out hit, 1f);
        if (grounded)
        {
            Environment.Del(hit.collider.gameObject);
        }
    }
    static void UseAxe()
    {
        if (Axe < 1) return;
        RaycastHit hit;
        bool grounded = Physics.Raycast(robot.transform.position + Vector3.up * 0.2f, robot.transform.forward, out hit, 1f);
        if (grounded)
        {
            Environment.Del(hit.collider.gameObject);
        }

    }
    static void UseHammer()
    {
        if (Hammer < 1) return;
        RaycastHit hit;
        bool grounded = Physics.Raycast(robot.transform.position + Vector3.up*0.2f, robot.transform.forward, out hit, 1f);
        if (grounded)
        {
            if (hit.collider.transform.tag == "stone")
                Environment.Del(hit.collider.gameObject);
        }
    }
    static void UseBoard()
    {
        Debug.Log(Board);
        if (Board < 1) return;
        RaycastHit hit;
        bool grounded = Physics.Raycast(robot.transform.position-Vector3.up*0.2f, robot.transform.forward - Vector3.up, out hit, 1f);
        if (grounded)
        {
            if (hit.collider.transform.tag == "water2")
            {
                Transform tf = hit.collider.gameObject.transform;
                GameObject oj;
                oj = GameObject.Instantiate(board);
                oj.transform.name = "board2";
                oj.transform.position = tf.transform.position;
                oj.transform.localScale = tf.transform.localScale;
                oj.transform.rotation = tf.transform.rotation;
                Environment.Del(hit.collider.gameObject);
            }
        }
    }
}
