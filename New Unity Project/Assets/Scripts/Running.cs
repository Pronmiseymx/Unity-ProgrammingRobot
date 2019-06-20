using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Running : MonoBehaviour {

    GameObject TextShow;//显示面板Text
    GameObject panelShow;

    static GameObject startp;
    static GameObject player;
    public GameObject ziwuti;//子物体
    static GameObject[] Prompts = new GameObject[1000];//提示条
    static int[] Lines = new int[1000];//错误行数
    int errorNum; //错误数量
    
    static GameObject startBt;
    static GameObject stopBt;
    static GameObject BanBt;

    // Use this for initialization
    void Start () {
        errorNum = 0;

        TextShow = GameObject.Find("Canvas/tb2/ScrollRectPanel/GridLayoutPanel/Text");
        panelShow = GameObject.Find("Canvas/tb1/ScrollRectPanel/GridLayoutPanel");
        startp = GameObject.Find("ground/StartP");
        player = GameObject.Find("/Cube");

        startBt = GameObject.Find("Canvas/RunningBt");
        stopBt = GameObject.Find("Canvas/StopBt");
        BanBt = GameObject.Find("Canvas/Running_BanCk");

        BanBt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void banBt()
    {
        startBt.GetComponent<Button>().interactable = false;
        //stopBt.GetComponent<Button>().interactable = true;
        BanBt.SetActive(true);
    }

    static public void liftBanBt()
    {
        startBt.GetComponent<Button>().interactable = true;
        //stopBt.GetComponent<Button>().interactable = false;
        BanBt.SetActive(false);
    }

    static public void initRobot()
    {
        player.transform.forward = startp.transform.forward;
        player.transform.position = startp.transform.position;
        Invoker.nowP = startp.transform.position;
        Robot.isSend = 1;
    }

    public void Go()//运行
    {
        initRobot();
        tools.init();
        GameObject isRecovery;
        isRecovery = GameObject.Find("Recovery");
        if (isRecovery != null)
        {
            isRecovery.transform.tag = "isRecovery_Y";
            Debug.Log(isRecovery.transform.tag);
        }

        if (button1.op == 1)
        {//图形模式
            Transform panelTF = panelShow.transform;

            for (int i = 0; i < panelTF.childCount; i++)
            {
                if (panelTF.GetChild(i).transform.childCount == 0)
                {
                    break;
                }
                Transform child =  panelTF.GetChild(i).transform.GetChild(0);
                switch (child.tag)
                {
                    case "up": Invoker.AddNextOp(1); break;
                    case "down": Invoker.AddNextOp(2); break;
                    case "left": Invoker.AddNextOp(3); break;
                    case "right": Invoker.AddNextOp(4); break;
                    case "yellowKey": Invoker.AddNextOp(6); break;
                    case "redKey": Invoker.AddNextOp(5); break;
                    case "Axe": Invoker.AddNextOp(7); break;
                    case "Hammer": Invoker.AddNextOp(8); break;
                    case "Board": Invoker.AddNextOp(9); break;
                }
            }
            Invoker.isGo = 1;
            banBt();
        }
        else if(button1.op == 2)
        {//代码模式
            string code;

            errorNum = 0;
            if (TextShow.GetComponent<Text>().text == "")
                return;
            code = TextShow.GetComponent<Text>().text;
            checkCode(code);
            if (errorNum>0)
            {
                CreatePrompt();
                return;
            }
            Invoker.isGo = 1;
            banBt();
        }
    }

    void CreatePrompt()
    {//创建提示条
        //float posY = 155.5f;
        float posY = -21;
        RectTransform rtf;

        DelPrompt();
        for (int i = 0; i < errorNum; i++)
        {
            Prompts[i] = GameObject.Instantiate(ziwuti);
            Prompts[i].transform.parent = TextShow.transform;
            rtf = Prompts[i].GetComponent<RectTransform>();
            rtf.pivot = new Vector2(0.5f, 0.5f);
            rtf.anchorMax = new Vector2(0.5f, 1);
            rtf.anchorMin = new Vector2(0.5f, 1);
            rtf.anchoredPosition = new Vector2(-10, posY - Lines[i] * 28);
            //Prompts[i].transform.set
            //Prompts[i].transform.localPosition = new Vector3(-10, posY - Lines[i] * 28);
        }
    }
    
    static public void DelPrompt()
    {//删除提示条
        for(int i=0; i<1000; i++)
        {
            if(Prompts[i] != null)
            {
                Destroy(Prompts[i]);
            }
        }
    }

    void checkCode(string code)
    {
        string[] ops;
        //ops = code.Split(new string[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries);
        ops = code.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        for(int i=0; i<ops.Length; i++)
        {
            if (ops[i].Trim() == "MoveUp") Invoker.AddNextOp(1);
            else if (ops[i].Trim() == "MoveDown") Invoker.AddNextOp(2);
            else if (ops[i].Trim() == "MoveLeft") Invoker.AddNextOp(3);
            else if (ops[i].Trim() == "MoveRight") Invoker.AddNextOp(4);
            else if (ops[i].Trim() == "UseRedKey") Invoker.AddNextOp(5);
            else if (ops[i].Trim() == "UseYellowKey") Invoker.AddNextOp(6);
            else if (ops[i].Trim() == "UseAxe") Invoker.AddNextOp(7);
            else if (ops[i].Trim() == "UseHammer") Invoker.AddNextOp(8);
            else if (ops[i].Trim() == "UseBoard") Invoker.AddNextOp(9);
            else if (ops[i].Trim() == "") continue;
            else Lines[errorNum++] = i;
        }
    }

}
