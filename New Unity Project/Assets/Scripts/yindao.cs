using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yindao : MonoBehaviour {

    static public GameObject[] panel = new GameObject[30];
    static public int index = 0;
    static public int num = 0;
    static public GameObject tishi;
    static public GameObject passBt;


    static public void awake()
    {
        index = 0;
        tishi = GameObject.Find("Canvas/yindao/tishi");
        passBt = GameObject.Find("Canvas/yindao/pass");
        startGuide();
    }

    /// <summary>
    /// 引导开始
    /// </summary>
    static public void startGuide()
    {
        setAllActiveFall();
        panel[0].SetActive(true);
        tishi.SetActive(true);
    }
    
    /// <summary>
    /// 结束引导
    /// </summary>
    public void pass()
    {
        setAllActiveFall();
        tishi.SetActive(false);
        passBt.SetActive(false);
    }

    /// <summary>
    /// 下一步操作
    /// </summary>
    public void clic()
    {
        index++;
        setAllActiveFall();
        if (index >= num)
        {
            this.gameObject.SetActive(false);
            return;
        }
        panel[index].SetActive(true);
    }

    /// <summary>
    /// 将所有引导画面隐藏
    /// </summary>
    static public void setAllActiveFall()
    {
        for (int i = 0; i < num; i++)
        {
            if (panel[i] != null)
            {
                panel[i].SetActive(false);
            }
            else return;
        }
    }


    /// <summary>
    /// 设置提示框文字
    /// </summary>
    static public void setText(GameObject go, string str)
    {
        Transform tf = go.transform;
        for (int i = 0; i < tf.childCount; i++)
        {
            Transform child = tf.GetChild(i);
            if(child.name=="kuang")
            {
                Transform childT = child.transform.GetChild(0);
                Text text = childT.gameObject.GetComponent<Text>();
                text.text = str;
                return;
            }
        }
    }
}
