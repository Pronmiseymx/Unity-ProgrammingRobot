using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SceneInfo_Json : MonoBehaviour {
    public SaveData saveData;
    public SceneInfo sceneinfo;
    string path;
    public string jsonName = "SceneData.json";

    /// <summary>
    /// 从json里面读取数据
    /// </summary>
    private SaveData LoadDataFromJson(string p)
    {
        Debug.Log(File.Exists(p));
        if (File.Exists(p))
        {
            string json = File.ReadAllText(p);
            return JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            return new SaveData();
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
    /// 储存关卡信息
    /// </summary>
    public void SetDirectoryState(SceneInfo current)
    {
        path = Application.streamingAssetsPath + "/" + jsonName;
        saveData = LoadDataFromJson(path);
        if(saveData.sceneInfo==null)
        {
            saveData.sceneInfo = new List<SceneInfo>();
        }
        saveData.sceneInfo.RemoveAll(t => t.Level == current.Level);
        saveData.sceneInfo.Add(current);
        SaveDataToJson();
    }

    /// <summary>
    /// 获取关卡信息
    /// </summary>
    public SceneInfo GetDirectoryState(int sceneCount)
    {
        path = Application.streamingAssetsPath + "/"+jsonName;

        saveData = LoadDataFromJson(path);

        if (saveData.sceneInfo!=null && saveData.sceneInfo.Count != 0)
        {
            foreach (var item in saveData.sceneInfo)
            {
                if (item.Level == sceneCount)
                {
                    return item;
                }
            }
        }

        return new SceneInfo(sceneCount, 0, 0,new int[] { }, new Vector3[] { }, new Vector3[] { }, new Quaternion[] { }); //Return clear state if there is no saved data
    }
}



[Serializable]
public struct SaveData
{
    public List<SceneInfo> sceneInfo;
}

[Serializable]
public class SceneInfo
{
    public int Level;
    public int isPass;
    public int cnt;
    public int[] kind;//1斧头 2木板 3锤子 4红门 5红钥匙 6水 7木堆 8黄门 9黄钥匙 10石头
    public Vector3[] po;
    public Vector3[] sc;
    public Quaternion[] ra;

    public SceneInfo(int curLevel, int pass, int c,int[]k, Vector3[] p, Vector3[] s, Quaternion[] r)
    {
        Level = curLevel;
        isPass = pass;
        cnt = c;
        kind = k;
        po = p;
        sc = s;
        ra = r;
    }
}