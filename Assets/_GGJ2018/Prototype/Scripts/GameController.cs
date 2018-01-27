using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private void OnEnable()
    {
        Infectable.onInfectableAbsorved += OnInfectableAbsorvedHandler;
    }



    private void OnDisable()
    {
        Infectable.onInfectableAbsorved -= OnInfectableAbsorvedHandler;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnInfectableAbsorvedHandler(GameObject _Infectable, GameObject _infector)
    {
        var m_Player = _infector.GetComponent<Player>();
        var m_Enemy = _Infectable.GetComponent<Infectable>();
        if(m_Player!=null){
            m_Player.m_Level +=1;
        }
    }
}
