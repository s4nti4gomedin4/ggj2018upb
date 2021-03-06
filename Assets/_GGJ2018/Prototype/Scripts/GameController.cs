﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {




    public GameObject m_Splash;
    public GameObject m_MainMenu;
    public Text m_Message;
    public EnemySpawn m_EnemySpawn;
    public Transform m_PlayerPosition;
    public Player m_PlayerPrefab;
    public GameObject m_Ui;
    public Tips m_Tips;

	public static bool m_Playing;

    private void OnEnable()
    {
        Impact.onHitBoxAction += OnHitBoxActionHandler;
        Orgam.onOrgamDestroy += OnOrgamDestroyHandler;
        Player.onPlayerDead += OnPlayerDead;
        MainMenu.OnGameStart += OnGameStartHandler;
    }

    private void OnGameStartHandler(){
    //    OnPlay();
    }

    private void OnDisable()
    {
        Impact.onHitBoxAction -= OnHitBoxActionHandler;
        Orgam.onOrgamDestroy -= OnOrgamDestroyHandler;
        Player.onPlayerDead -= OnPlayerDead;
        MainMenu.OnGameStart -= OnGameStartHandler;


    }

    private void Start()
    {
        m_Playing = false;
        m_Ui.gameObject.SetActive(false);
        m_Splash.SetActive(false);
        m_MainMenu.SetActive(true);
        m_Tips.HideMessag();
    }

    private void Update()
    {
       
        if(Input.anyKeyDown ){
            if(!m_Playing)
            OnPlay();
        }
    }

    private void OnOrgamDestroyHandler()
    {
        m_Ui.gameObject.SetActive(false);
        m_Playing = false;
        m_Splash.SetActive(true);
        m_PlayerPrefab.gameObject.SetActive(false);
        m_Message.text = "Win!!";
        m_EnemySpawn.DestroyChilds();
        StartCoroutine(m_EnemySpawn.DestroyChilds());
    }

    private void OnPlayerDead()
    {
        m_Ui.gameObject.SetActive(false);
        m_Playing = false;
        m_PlayerPrefab.gameObject.SetActive(false);
        m_Splash.SetActive(true);
        m_Message.text = "Lose!!";
        StartCoroutine(m_EnemySpawn.DestroyChilds());
    }

    private void OnPlay()
    {
       
        m_Ui.gameObject.SetActive(true);
        m_Playing = true;
        m_MainMenu.SetActive(false);
        m_Splash.SetActive(false);
        m_EnemySpawn.OnSpawnEnemies();
        var position = m_PlayerPosition.position;
        position.y = m_PlayerPrefab.transform.position.y;
        m_PlayerPrefab.transform.position = position;
        m_PlayerPrefab.gameObject.SetActive(true);
        m_PlayerPrefab.ResetPlayer();
        m_Tips.ShowMessage("Destroy the main organ.");
    }

    private void OnHitBoxActionHandler(HitBox winner, HitBox losse)
    {
       
        winner.m_Level++;
        losse.m_Level--;
    }
}
