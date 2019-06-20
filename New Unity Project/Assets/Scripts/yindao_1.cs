using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yindao_1 : MonoBehaviour {

    public GameObject[] panel;
    int index;
    
	void Start () {
        Debug.Log(panel.Length);
        yindao.panel = panel;
        yindao.num = panel.Length;
        yindao.awake();
    }
	
	void Update () {
		switch(yindao.index)
        {
            case 0: yindao.setText(yindao.panel[yindao.index], "点击按钮可以在两种\n控制模式之间切换"); break;
            case 1: yindao.setText(yindao.panel[yindao.index], "点击指令图标可以给\n机器人添加移动命令"); break;
            case 2: yindao.setText(yindao.panel[yindao.index], "添加的指令将在\n指令框中显示"); break;
            case 3: yindao.setText(yindao.panel[yindao.index], "点击该图标\n执行命令"); break;
            case 4: yindao.setText(yindao.panel[yindao.index], "控制机器人取得水晶\n赢得游戏胜利"); break;
        }
	}
}
