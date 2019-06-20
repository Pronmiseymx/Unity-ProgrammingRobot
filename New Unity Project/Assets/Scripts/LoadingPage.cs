using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingPage : MonoBehaviour {
    Slider pro;//进度条
    float tar;//进度值
    AsyncOperation op;//异步对象
    float dtimer;
    string level;
    GameObject send;
    int isok;//玩家是否点击屏幕
    Text text;//提示标签

    void Start () {
        //获取Slider进度条
        GameObject GOpro = GameObject.Find("Canvas/Slider");
        pro = GOpro.GetComponent<Slider>();
        Debug.Log(pro);
        tar = 0.0f;
        dtimer = 0.0f;
        //获取提示标签
        GameObject GOt = GameObject.Find("Canvas/tishi");
        text = GOt.GetComponent<Text>();
        //获取要登录的关卡
        send = GameObject.Find("SendLevel");
        level = send.GetComponent<SendLevel>().level;
        Destroy(send);

        isok = 0;
        pro.value = 0.0f;
        //开启协程
        StartCoroutine(Loading());
    }

	void Update () {
        //使进度条更平滑
        pro.value = Mathf.Lerp(pro.value, tar, dtimer * 0.02f);
        dtimer += Time.deltaTime;
        if(pro.value > 0.99f)
        {
            pro.value = 1;
            text.text = "加载完毕，点击继续";
            if (isok == 1)
            {
                op.allowSceneActivation = true;
            }
        }
    }
    public void clic()
    {
        if(pro.value >= 1)
        {
            isok = 1;
        }
    }
    
    IEnumerator Loading()
    {
        //开启异步加载场景
        op = SceneManager.LoadSceneAsync(level);
        //加载完后不进行场景跳转
        op.allowSceneActivation = false;
        while(true)
        {
            tar = op.progress; //获取进度值
            if(tar >= 0.9f)//Unity的异步加载只能加载到90%
            {
                tar = 1;
                yield break;
            }
            yield return 0;
        }
    }
}
