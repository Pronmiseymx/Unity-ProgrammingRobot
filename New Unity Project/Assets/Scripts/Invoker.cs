using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour {
    
    public Recerver r;

    static public int isGo;//是否执行命令

    static List<Command> cmdList;//命令列表
    static List<Vector3> NextP;//目标点
    static public Vector3 nowP;//当前位置
    public GameObject robot;

    static upCommond upcmd;
    static downCommond downcmd;
    static leftCommond leftcmd;
    static rightCommond rightcmd;

    static redKeyCommond rkcmd;
    static yellowKeyCommond ykcmd;
    static AxeCommond axecmd;
    static HammerCommond hammercmd;
    static BoardCommond boardcmd;

    static Animator anim;
    AnimatorStateInfo stateinfo;
    static public int index;

    static public bool isStop;
    // Use this for initialization
    void Start () {
        anim = robot.transform.GetComponent<Animator>();
        init();
        index = 0;
        isGo = 0;
        isStop = false;
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("isTk", 0);
        if (IsInvoking()) Debug.Log("invoke");
        if (isGo == 1)
        {
            Executecmd();
        }
        if (isStop == true)
        {
            CancelInvoke("Delayed");
            isStop = false;
        }
    }

    void init()
    {
        nowP = robot.transform.position;
        cmdList = new List<Command>();
        NextP = new List<Vector3>();
        upcmd = new upCommond();
        downcmd = new downCommond();
        leftcmd = new leftCommond();
        rightcmd = new rightCommond();
        rkcmd = new redKeyCommond();
        ykcmd = new yellowKeyCommond();
        axecmd = new AxeCommond();
        hammercmd = new HammerCommond();
        boardcmd = new BoardCommond();

    }

    static public void Restore()
    {//复原
        isGo = 0;
        cmdList.Clear();
        NextP.Clear();
        SetAnimatorIdle();
        isStop = true;
        Running.liftBanBt();
        index = 0;
    }

    static void Addcmd(Command cmd)
    {//添加命令
        if(cmd != null)
        {
            cmdList.Add(cmd);
            Debug.Log("成功添加命令，共：" + cmdList.Count + "个命令");
        }
    }

    void Executecmd()
    {//执行命令
        float dis;
        Animator anim = robot.GetComponent<Animator>();
        if (cmdList.Count <= 0)
        {//无命令
            Restore();
            return;
        }
        if (index >= cmdList.Count)
        {//命令执行完
            Restore();
            return;
        }
        if (CheckNextOp() == true)
        {
            dis = Vector3.Distance(robot.transform.position, nowP + NextP[index]);
            if(dis < 0.2f && Robot.isSend < 2)
            {
                robot.transform.position = nowP + NextP[index];
                nowP = robot.transform.position;
                index++;
                if (CheckNextOp() == true) return;
                SetAnimatorIdle();
                return;
            }
            cmdList[index].Execute(r);
        }
        else
        {
            stateinfo = anim.GetCurrentAnimatorStateInfo(0);
            if (stateinfo.IsName("Idle") == false) return;
            cmdList[index].Execute(r);
            isGo = 0;
            index++;
            Invoke("Delayed", 2f);
        }

        
    }
    void Delayed()
    {
        isGo = 1;
    }

    static public void SetAnimatorIdle()
    {
        anim.SetInteger("isRun", 0);
        anim.SetInteger("isTk", 0);
    }

    static void AddNextP(Vector3 ve)
    {//添加下一个目标点
        if (ve == null)
            return;
        NextP.Add(ve);
    }

    static public void AddNextOp(int op)
    {// 1:上 2:下 3:左 4:右 
     //5:红钥匙 6:黄钥匙 7:斧子 8:锤子 9:木板
        switch (op)
        {
            case 1:
                Addcmd(upcmd);
                AddNextP(Vector3.forward * 3);
                break;
            case 2:
                Addcmd(downcmd);
                AddNextP(Vector3.back * 3);
                break;
            case 3:
                Addcmd(leftcmd);
                AddNextP(Vector3.left * 3);
                break;
            case 4:
                Addcmd(rightcmd);
                AddNextP(Vector3.right * 3);
                break;
            case 5:
                Addcmd(rkcmd);
                AddNextP(Vector3.forward * (-9999));
                break;
            case 6:
                Addcmd(ykcmd);
                AddNextP(Vector3.forward * (-9999));
                break;
            case 7:
                Addcmd(axecmd);
                AddNextP(Vector3.forward * (-9999));
                break;
            case 8:
                Addcmd(hammercmd);
                AddNextP(Vector3.forward * (-9999));
                break;
            case 9:
                Addcmd(boardcmd);
                AddNextP(Vector3.forward * (-9999));
                break;
        }
    }

    bool CheckNextOp()
    {//接下来的操作是否为移动
        if (index >= cmdList.Count) return false;
        if (NextP[index] == (Vector3.forward * (-9999))) return false;
        return true;
    }
}
