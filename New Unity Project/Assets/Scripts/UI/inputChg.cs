using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputChg : MonoBehaviour {

    static public int isChg = 0;

    public void changed()
    {
        isChg = 1;
    }
}
