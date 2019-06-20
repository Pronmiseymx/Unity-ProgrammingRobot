using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelOrder : MonoBehaviour {

    GameObject panel;
    AudioSource play;

    // Use this for initialization
    void Start () {
        panel = GameObject.Find("Canvas/tb1/ScrollRectPanel/GridLayoutPanel");
        play = GameObject.Find("Audio_del").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click ()
    {
        play.Play();
        GameObject father = this.transform.parent.gameObject;
        Transform panelTF = panel.transform;
        RectTransform panelRT = panel.GetComponent<RectTransform>();
        int count = panelTF.childCount;
        Vector2 pos = new Vector2(panelRT.localPosition.x, panelRT.localPosition.y - 200);

        if(count <= 5)
        {
            AddBox(count+1);
        }
        count = count < 6 ? 6 : count;
        
        Destroy(father);
        panelRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, (count - 1) * 100);
        panelRT.anchoredPosition = pos;
    }

    void AddBox(int num)
    {
        GameObject box = GameObject.Find("Canvas/tb1/box");
        GameObject clone = GameObject.Instantiate(box);
        RectTransform cloneRT = clone.GetComponent<RectTransform>();
        RectTransform panelRT = panel.GetComponent<RectTransform>();

        clone.transform.parent = panel.transform;
        cloneRT.localScale = new Vector3(3.333333f, 1.241914f, 1);
        panelRT.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, num * 100);
    }
}
