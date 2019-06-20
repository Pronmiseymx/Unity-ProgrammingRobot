using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Robot : MonoBehaviour {

    GameObject victory;
    GameObject failure;

    Animator anim;
    AnimatorStateInfo stateinfo;

    static public GameObject Am = null;

    static public int isSend = 0;

    // Use this for initialization
    void Start () {
        victory = GameObject.Find("Canvas/victory");
        failure = GameObject.Find("Canvas/failure");

        victory.SetActive(false);
        failure.SetActive(false);

        anim = this.gameObject.transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.name=="shuijing")
        {
            Invoker.Restore();
            Pass();
            victory.SetActive(true);
        }
        else if(collider.transform.tag == "die" || collider.transform.tag == "water2")
        {
            Invoker.Restore();
            failure.SetActive(true);
        }
        else if(collider.transform.tag == "send")
        {
            isSend++;
        }
        else if(collider.transform.tag == "tools_Yk")
        {//1:红钥匙 //2：黄钥匙 //3：斧子 //4：锤子 //5：木板
            tools.getTools(2, collider.gameObject);
        }
        else if (collider.transform.tag == "tools_Rk")
        {
            tools.getTools(1, collider.gameObject);
        }
        else if (collider.transform.tag == "tools_Axe")
        {
            tools.getTools(3, collider.gameObject);
        }
        else if (collider.transform.tag == "tools_Hammer")
        {
            tools.getTools(4, collider.gameObject);
        }
        else if (collider.transform.tag == "tools_Bd")
        {
            tools.getTools(5, collider.gameObject);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.transform.tag == "send" && (Am==null || collider.gameObject.name != Am.name))
        {
            if (Vector3.Distance(this.transform.position, collider.transform.position)<=0.5f)
            {
                isSend = 0;
                anim.SetInteger("isRun", 0);
                Environment.Send(this.gameObject, collider.gameObject);
                return;
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider == null) return;
        if (collider.transform.tag == "send" && Am!=null && collider.name==Am.name)
        {
            Am = null;
        }
    }

    void Pass()
    {
        SceneInfo_Json json  = new SceneInfo_Json();
        int index = 0;
        string SceneName = SceneManager.GetActiveScene().name;//获取场景名称
        switch (SceneName)
        {
            case "Scenes_1": index = 2; break;
            case "Scenes_2": index = 3; break;
            case "Scenes_3": index = 4; break;
            case "Scenes_4": index = 5; break;
            case "Scenes_5": index = 6; break;

        }
        if(index == 6)
        {
            return;
        }
        json.sceneinfo = json.GetDirectoryState(index);
        json.sceneinfo.isPass = 1;
        json.SetDirectoryState(json.sceneinfo);
    }
}
