using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Choice : MonoBehaviour {
    //选关界面
    GameObject suo;
    GameObject l1;
    GameObject l2;
    GameObject l3;
    GameObject l4;
    GameObject l5;

    GameObject sendlevel;//场景传值空物体


    // Use this for initialization
    void Start () {
        //inti();
        init();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void init()
    {
        suo = GameObject.Find("Canvas/suo");
        l1 = GameObject.Find("Canvas/Button_1");
        l2 = GameObject.Find("Canvas/Button_2");
        l3 = GameObject.Find("Canvas/Button_3");
        l4 = GameObject.Find("Canvas/Button_4");
        l5 = GameObject.Find("Canvas/Button_5");
        sendlevel = GameObject.Find("/SendLevel");

        GameObject[] levlBt = new GameObject[5] {l1 ,l2,l3,l4,l5};

        SceneInfo_Json json = new SceneInfo_Json();
        for (int i = 2; i <= 5; i++)
        {
            json.sceneinfo = json.GetDirectoryState(i);
            if(json.sceneinfo.isPass==0)
            {
                AddObject(levlBt[i-1], suo);
                levlBt[i - 1].GetComponent<Button>().interactable = false;
            }
        }
    }


    void AddObject(GameObject father, GameObject AddKind)
    {
        GameObject clone = GameObject.Instantiate(AddKind);
        RectTransform cloneRT = clone.GetComponent<RectTransform>();

        clone.transform.parent = father.transform;
        cloneRT.anchoredPosition = new Vector2(0, 0);//位置
        cloneRT.localScale = new Vector3(1, 1, 1);
    }

    public void ck1()
    {
        sendlevel.GetComponent<SendLevel>().level = "Scenes_1";
        SceneManager.LoadScene("Loading");
    }
    public void ck2()
    {
        sendlevel.GetComponent<SendLevel>().level = "Scenes_2";
        SceneManager.LoadScene("Loading");
    }
    public void ck3()
    {
        sendlevel.GetComponent<SendLevel>().level = "Scenes_3";
        SceneManager.LoadScene("Loading");
    }
    public void ck4()
    {
        sendlevel.GetComponent<SendLevel>().level = "Scenes_4";
        SceneManager.LoadScene("Loading");
    }
    public void ck5()
    {
        sendlevel.GetComponent<SendLevel>().level = "Scenes_5";
        SceneManager.LoadScene("Loading");
    }
    public void Return()
    {
        SceneManager.LoadScene("Start");
    }
}
