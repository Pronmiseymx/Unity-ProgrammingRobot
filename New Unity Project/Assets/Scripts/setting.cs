using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour {
    Toggle bgm;
    Slider bgm_slider;
    Text bgm_value;

    Toggle se;
    Slider se_slider;
    Text se_value;

    GameObject x;
    AudioSource BGM;
    AudioSource SE_ADD;
    AudioSource SE_DEL;
    SettingData sdata;
    Setting_Json sj;
    
    void Start ()
    {
        bgm_slider = GameObject.Find("Canvas/setting_box/Panel/bgm_Slider").GetComponent<Slider>();
        bgm_value = GameObject.Find("Canvas/setting_box/Panel/bgm_value").GetComponent<Text>();
        bgm = GameObject.Find("Canvas/setting_box/Panel/bgm").GetComponent<Toggle>();

        se_slider = GameObject.Find("Canvas/setting_box/Panel/se_Slider").GetComponent<Slider>();
        se_value = GameObject.Find("Canvas/setting_box/Panel/se_value").GetComponent<Text>();
        se = GameObject.Find("Canvas/setting_box/Panel/se").GetComponent<Toggle>();

        BGM = GameObject.Find("/Audio_bgm").GetComponent<AudioSource>();
        SE_ADD = GameObject.Find("/Audio_add").GetComponent<AudioSource>();
        SE_DEL = GameObject.Find("/Audio_del").GetComponent<AudioSource>();

        x = GameObject.Find("Canvas/setting_box/x");
        init();
    }
	
    void init()
    {
        sj = new Setting_Json();
        sdata = sj.GetDirectoryState();
        bgm_slider.value = sdata.bgm_value;
        bgm_value.text = sdata.bgm_value.ToString();
        bgm.isOn = sdata.bgm_isActive;
        se_slider.value = sdata.se_value;
        se_value.text = sdata.se_value.ToString();
        se.isOn = sdata.se_isActive;
        Update();
        ClickButton.setting = this.gameObject;
        this.gameObject.SetActive(false);
    }
    
    void Update () {
        if(se.isOn)
        {
            SE_ADD.volume = se_slider.value / 100.0f;
            SE_DEL.volume = se_slider.value / 100.0f;
        }
        else
        {
            SE_ADD.volume = 0;
            SE_DEL.volume = 0;
        }
        se_value.text = se_slider.value.ToString();

        if (bgm.isOn)
        {
            BGM.volume = bgm_slider.value / 100.0f;
        }
        else
        {
            BGM.volume = 0;
        }
        bgm_value.text = bgm_slider.value.ToString();
    }

    public void close()
    {
        updateJson();
        this.gameObject.SetActive(false);
    }

    public void updateJson()
    {
        sdata.bgm_isActive = bgm.isOn;
        sdata.bgm_value = (int)bgm_slider.value;
        sdata.se_isActive = se.isOn;
        sdata.se_value = (int)se_slider.value;

        sj.SetDirectoryState(sdata);
    }
}
