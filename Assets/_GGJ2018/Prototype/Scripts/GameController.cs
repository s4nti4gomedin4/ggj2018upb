using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private void OnEnable()
    {
        Infectable.onInfectableDestroy += OnInfectableDestroyHandler;
    }



    private void OnDisable()
    {
        Infectable.onInfectableDestroy -= OnInfectableDestroyHandler;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnInfectableDestroyHandler(GameObject _Infectable, GameObject _infector)
    {
        var m_Player = _infector.GetComponent<Player>();
        var m_Enemy = _Infectable.GetComponent<Infectable>();
        if(m_Player!=null){
            m_Player.m_Level += m_Enemy.m_Level;
        }
    }
}
