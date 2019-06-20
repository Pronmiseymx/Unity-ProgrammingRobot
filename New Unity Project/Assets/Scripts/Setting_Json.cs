using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Setting_Json : MonoBehaviour {

    SettingData saveData;
    string path;
    public string jsonName = "SettingData.json";

    /// <summary>
    /// 从json里面读取数据
    /// </summary>
    private SettingData LoadDataFromJson(string p)
    {
        if (File.Exists(p))
        {
            string json = File.ReadAllText(p);
            return JsonUtility.FromJson<SettingData>(json);
        }
        else
        {
            return new SettingData();
        }
    }

    /// <summary>
    /// 储存数据到json
    /// </summary>
    private void SaveDataToJson()
    {
        path = Application.streamingAssetsPath + "/" + jsonName;
        string json = JsonUtility.ToJson(saveData, true);
        StreamWriter sw = File.CreateText(path);
        sw.Close();
        File.WriteAllText(path, json);
        Debug.Log("OK");
    }

    /// <summary>
    /// 储存设置信息
    /// </summary>
    public void SetDirectoryState(SettingData info)
    {
        path = Application.streamingAssetsPath + "/" + jsonName;
        saveData = LoadDataFromJson(path);
        saveData.bgm_isActive = info.bgm_isActive;
        saveData.bgm_value = info.bgm_value;
        saveData.se_isActive = info.se_isActive;
        saveData.se_value = info.se_value;
        SaveDataToJson();
    }

    /// <summary>
    /// 获取设置信息
    /// </summary>
    public SettingData GetDirectoryState()
    {
        path = Application.streamingAssetsPath + "/" + jsonName;
        if(File.Exists(path)==true)
        {
            saveData = LoadDataFromJson(path);
            return saveData;
        }
        saveData.bgm_isActive = true;
        saveData.bgm_value = 15;
        saveData.se_isActive = true;
        saveData.se_value = 15;
        return saveData;
    }
}    

public struct SettingData
{
    public bool bgm_isActive;
    public int bgm_value;
    public bool se_isActive;
    public int se_value;
}

