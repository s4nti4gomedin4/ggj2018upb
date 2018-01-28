using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    private void OnEnable()
    {
        Impact.onHitBoxAction += OnHitBoxActionHandler;
    }

    private void OnDisable()
    {
        Impact.onHitBoxAction -= OnHitBoxActionHandler;
    }


    private void OnHitBoxActionHandler(HitBox winner, HitBox losse)
    {
       
        winner.m_Level++;
        losse.m_Level--;
    }
}
