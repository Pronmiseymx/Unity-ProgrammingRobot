using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddOrder : MonoBehaviour {
    GameObject up;
    GameObject down;
    GameObject left;
    GameObject right;
    GameObject redKey;//红钥匙
    GameObject yellowKey;//黄钥匙
    GameObject Axe;//斧子
    GameObject Hammer;//锤子
    GameObject Board;//木板

    GameObject AddKind;
    GameObject panel;
    GameObject box;
    string Name;

    AudioSource play;

    void Start () {
        play = GameObject.Find("Audio_add").GetComponent<AudioSource>();
        init();
    }
	
	void Update () {
		
	}

    void init()
    {
        panel = GameObject.Find("Canvas/tb1/ScrollRectPanel/GridLayoutPanel");
        up    = GameObject.Find("Canvas/tb1/up");
        down  = GameObject.Find("Canvas/tb1/down");
        left  = GameObject.Find("Canvas/tb1/left");
        right = GameObject.Find("Canvas/tb1/right");
        box   = GameObject.Find("Canvas/tb1/box");
        redKey    = GameObject.Find("Canvas/tools_box/redKey");
        yellowKey = GameObject.Find("Canvas/tools_box/yellowKey");
        Axe       = GameObject.Find("Canvas/tools_box/Axe");
        Hammer    = GameObject.Find("Canvas/tools_box/Hammer");
        Board     = GameObject.Find("Canvas/tools_box/Board");

        Name = transform.name;
        switch (Name)
        {//获取该指令类型
            case "up": AddKind = up;break;
            case "down": AddKind = down;break;
            case "left": AddKind = left;break;
            case "right":AddKind = right;break;
            case "redKey": AddKind = redKey; break;
            case "yellowKey": AddKind = yellowKey; break;
            case "Axe": AddKind = Axe; break;
            case "Hammer": AddKind = Hammer; break;
            case "Board": AddKind = Board; break;
        }
    }

    public void Click()
    {
        play.Play();
        Transform panelTF = panel.transform;
        for(int i=0; i< panelTF.childCount; i++)
        {//查询空着的指令框
            if (panelTF.GetChild(i).transform.childCount != 0) continue;
            AddObject(panelTF.GetChild(i).gameObject, AddKind);//添加指令
            if (i>=4)
            {
                AddBox(panelTF.childCount+1);//添加新的指令框
            }
            return;
        }
    }

    void AddObject(GameObject box, GameObject AddKind)
    {
        GameObject clone =  GameObject.Instantiate(AddKind);
        RectTransform cloneRT = clone.GetComponent<RectTransform>();

        clone.transform.parent = box.transform;
        cloneRT.anchoredPosition = new Vector2(0,0);//位置
        cloneRT.localScale = new Vector3(1, 1, 1);
    }

    void AddBox(int num)
    {
        GameObject clone = GameObject.Instantiate(box);
        RectTransform cloneRT = clone.GetComponent<RectTransform>();
        RectTransform panelRT = panel.GetComponent<RectTransform>();
        
        clone.transform.parent = panel.transform;//设为子物体
        cloneRT.localScale = new Vector3(3.333333f, 1.241914f, 1);
        panelRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, num * 100);
        panelRT.anchoredPosition = new Vector2(5, -250+num*50);
    }
}
