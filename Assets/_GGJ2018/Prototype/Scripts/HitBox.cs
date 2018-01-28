﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

   

    public System.Action onLevelChange;
    public const int MaxLevel = 15;

    private int _m_Level;
    public int m_Level
    {
        get { return _m_Level; }
        set
        {
           
            _m_Level = value;
            if(_m_Level>MaxLevel){
                _m_Level = MaxLevel;
            }
            if(onLevelChange!=null){
                onLevelChange();
            }
           
        }
    }
    public bool isInfected;



   
}