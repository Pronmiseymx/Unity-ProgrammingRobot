using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class recovery_5 : MonoBehaviour {

    GameObject YL_Key;
    GameObject Red_Key;
    GameObject YL_Door;
    GameObject Red_Door;
    GameObject Hammer;
    GameObject Water2;
    GameObject Board2;
    GameObject Wood;
    GameObject Stone;
    GameObject Axe;
    GameObject Board;

    SceneInfo_Json json;


    public GameObject Yk;
    public GameObject Rk;
    public GameObject Yd;
    public GameObject Rd;
    public GameObject Hm;
    public GameObject Wt2;
    public GameObject Wo;
    public GameObject St;
    public GameObject Ax;
    public GameObject Bd;


    // Use this for initialization
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.tag == "isRecovery_Y")
        {
            Rec();
        }
    }

    void init()
    {
        int index = 0;
        string SceneName = SceneManager.GetActiveScene().name;//获取场景名称
        switch (SceneName)
        {
            case "Scenes_1": index = 1; break;
            case "Scenes_2": index = 2; break;
            case "Scenes_3": index = 3; break;
            case "Scenes_4": index = 4; break;
            case "Scenes_5": index = 5; break;

        }
        json = new SceneInfo_Json();
        json.sceneinfo = json.GetDirectoryState(index);
    }

    void Rec()
    {
        transform.tag = "isRecovery_N";
        for (int i=0; i<json.sceneinfo.cnt; i++)
        {
            switch (json.sceneinfo.kind[i])
            {//1斧头 2木板 3锤子 4红门 5红钥匙 6水 7木堆 8黄门 9黄钥匙 10石头
                case 1:RecAx(i) ; break;
                case 2:RecBd(i); break;
                case 3:RecHm(i); break;
                case 4:RecRd(i); break;
                case 5:RecRk(i); break;
                case 6:RecWt(i); break;
                case 7:RecWo(i); break;
                case 8:RecYd(i); break;
                case 9:RecYk(i); break;
                case 10:RecSt(i); break;

            }

        }
    }
    
    void setSon(GameObject son, Vector3 po, Vector3 sc, Quaternion ra)
    {
        son.transform.position = po;
        son.transform.localScale = sc;
        son.transform.rotation = ra;
    }

    void RecYk(int i)
    {
        //黄钥匙
        YL_Key = GameObject.Find("/YL_Key");
        if (YL_Key != null) return;
        YL_Key = GameObject.Instantiate(Yk);
        YL_Key.transform.name = "YL_Key";
        setSon(YL_Key, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecRk(int i)
    {
        //红钥匙
        Red_Key = GameObject.Find("/Red_Key");
        if (Red_Key != null) return;
        Red_Key = GameObject.Instantiate(Rk);
        Red_Key.transform.name = "Red_Key";
        setSon(Red_Key, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecYd(int i)
    {
        //黄门
        YL_Door = GameObject.Find("/YL_Door");
        if (YL_Door != null) return;
        YL_Door = GameObject.Instantiate(Yd);
        YL_Door.transform.name = "YL_Door";
        setSon(YL_Door, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecRd(int i)
    {
        //红门
        Red_Door = GameObject.Find("/Red_Door");
        if (Red_Door != null) return;
        Red_Door = GameObject.Instantiate(Rd);
        Red_Door.transform.name = "Red_Door";
        setSon(Red_Door, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecHm(int i)
    {
        //锤子
        Hammer = GameObject.Find("/Hammer");
        if (Hammer != null) return;
        Hammer = GameObject.Instantiate(Hm);
        Hammer.transform.name = "Hammer";
        setSon(Hammer, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecWt(int i)
    {//水
        Water2 = GameObject.Find("/Water2");
        if (Water2 != null) return;
        Water2 = GameObject.Instantiate(Wt2);
        Water2.transform.name = "Water2";
        setSon(Water2, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);

        GameObject bd2 = GameObject.Find("/board2");
        if(bd2!=null) Destroy(bd2);
    }

    void RecBd(int i)
    {//木板
        Board = GameObject.Find("/Board");
        if (Board != null) return;
        Board = GameObject.Instantiate(Bd);
        Board.transform.name = "Board";
        setSon(Board, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecWo(int i)
    {//木堆
        Wood = GameObject.Find("/Wood");
        if (Wood != null) return;
        Wood = GameObject.Instantiate(Wo);
        Wood.transform.name = "Wood";
        setSon(Wood, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecSt(int i)
    {//石头
        Stone = GameObject.Find("/Stone");
        if (Stone != null) return;
        Stone = GameObject.Instantiate(St);
        Stone.transform.name = "Stone";
        setSon(Stone, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }

    void RecAx(int i)
    {//锤子
        Axe = GameObject.Find("/Axe");
        if (Axe != null) return;
        Axe = GameObject.Instantiate(Ax);
        Axe.transform.name = "Axe";
        setSon(Axe, json.sceneinfo.po[i], json.sceneinfo.sc[i], json.sceneinfo.ra[i]);
    }
}
