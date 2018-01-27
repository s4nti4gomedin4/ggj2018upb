using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


    public Text m_TextLeve;
    public int m_Level;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(m_TextLeve!=null)
        m_TextLeve.text = string.Format("{0:D}", m_Level);
	}
}
