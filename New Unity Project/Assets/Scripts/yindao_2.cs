using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yindao_2 : MonoBehaviour {

    public GameObject[] panel;
    int index;

    void Start()
    {
        yindao.panel = panel;
        yindao.num = panel.Length;
        yindao.awake();
    }

    void Update()
    {
        switch (yindao.index)
        {
            case 0: yindao.setText(yindao.panel[yindao.index], "控制机器人触碰传送阵\n机器人将传送到另一个\n相同颜色的传送阵位置"); break;
            case 1: yindao.setText(yindao.panel[yindao.index], "控制机器人触碰道具\n将拾取该道具"); break;
            case 2: yindao.setText(yindao.panel[yindao.index], "点击道具图标可以\n添加使用道具的指令"); break;
            case 3: yindao.setText(yindao.panel[yindao.index], "点击帮助按钮可以\n查看各种道具的用法"); break;
        }
    }
}
