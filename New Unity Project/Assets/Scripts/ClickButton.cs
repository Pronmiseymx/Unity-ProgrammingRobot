using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ClickButton : MonoBehaviour {
    //游戏失败  成功  帮助
    string SceneName; //场景名称
    int index; //场景序号
    GameObject help;
    static public GameObject setting;

    GameObject sendlevel;//场景传值空物体

    void Start () {
        help = GameObject.Find("Canvas/help_box");
        help.SetActive(false);
        sendlevel = GameObject.Find("/SendLevel");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Next()
    {
        GetScene();
        if (SceneName == "Scenes_1")
        {
            sendlevel.GetComponent<SendLevel>().level = "Scenes_2";
            SceneManager.LoadScene("Loading");
        }
        else if (SceneName == "Scenes_2")
        {
            sendlevel.GetComponent<SendLevel>().level = "Scenes_3";
            SceneManager.LoadScene("Loading");
        }
        else if (SceneName == "Scenes_3")
        {
            sendlevel.GetComponent<SendLevel>().level = "Scenes_4";
            SceneManager.LoadScene("Loading");
        }
        else if (SceneName == "Scenes_4")
        {
            sendlevel.GetComponent<SendLevel>().level = "Scenes_5";
            SceneManager.LoadScene("Loading");
        }
        else if (SceneName == "Scenes_5")
        {
            SceneManager.LoadScene("Choice");
        }
    }

    public void Back()
    {
        GetScene();
        SceneManager.LoadScene(SceneName);
    }
    void GetScene()//调用此函数获得场景信息
    {
        SceneName = SceneManager.GetActiveScene().name;//获取场景名称
        index = SceneManager.GetActiveScene().buildIndex;//获取场景所在序号
    }

    public void Return()
    {
        SceneManager.LoadScene("Choice");
    }

    public void Help()
    {
        help.SetActive(true);
    }

    public void CloseHelp()
    {
        help.SetActive(false);
    }

    public void set()
    {
        setting.SetActive(true);
    }
}
