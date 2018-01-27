using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public Text m_TextLeve;
    public int m_Level { 
        get { return _m_Level; }
        set { _m_Level = value;
            OnLevelChange();
            }
    }
    private int _m_Level = 1;
    public float sizeOverLevel;

	// Use this for initialization
	void Start () {
        OnLevelChange();
	}
	
    private void OnLevelChange()
    {
        if (m_TextLeve != null)
            m_TextLeve.text = string.Format("{0:D}", m_Level);

        var scale = transform.localScale;
        scale.x = 1+(m_Level * sizeOverLevel);
        scale.z = 1+(m_Level * sizeOverLevel);
        transform.localScale = scale;
    }
}
