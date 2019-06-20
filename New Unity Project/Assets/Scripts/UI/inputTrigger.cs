using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class inputTrigger : MonoBehaviour {
    GameObject TextShow;//显示面板Text
    GameObject GridLayoutPanel;//显示面板
    GameObject input;//输入框
    GameObject thisGo;//空白处
    

    // Use this for initialization
    void Start () {
        input = GameObject.Find("Canvas/tb2/InputField");
        TextShow = GameObject.Find("Canvas/tb2/ScrollRectPanel/GridLayoutPanel/Text");
        GridLayoutPanel = GameObject.Find("Canvas/tb2/ScrollRectPanel/GridLayoutPanel");
        thisGo = GameObject.Find("Canvas/trigger");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void chick()
    {
        string text;
        int num;//行数
        float size;
        RectTransform textRTF;
        RectTransform panelRTF;
        GridLayoutGroup rtfGlg;

        //是否修改命令
        if (inputChg.isChg == 1)
        {
            Running.DelPrompt();
            inputChg.isChg = 0;
        }

        text = input.GetComponent<InputField>().text;

        num = getRowNum(text);
        Debug.Log(num);
        //修改面板大小
        textRTF = TextShow.GetComponent<RectTransform>();
        panelRTF = GridLayoutPanel.GetComponent<RectTransform>();
        rtfGlg = GridLayoutPanel.GetComponent<GridLayoutGroup>();
        //textRTF.sizeDelta = new Vector2(textRTF.sizeDelta.x, 23*(num+1));
        //panelRTF.sizeDelta = new Vector2(panelRTF.sizeDelta.x, 23 * (num + 1));
        //panelRTF.position = new Vector3(panelRTF.position.x, -46, 0);
        size = 30 * (num);
        if (size < 600) size = 600;
        textRTF.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, size);
        panelRTF.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, size);
        rtfGlg.cellSize = new Vector2(491, size);

        TextShow.GetComponent<Text>().text = text;
        input.SetActive(false);
        thisGo.SetActive(false);

    }

    int getRowNum(string str)
    {
        int num = 1;
        foreach(char ch in str)
        {
            if (ch == '\n')
                num++;
        }
        return num;
    }
}
