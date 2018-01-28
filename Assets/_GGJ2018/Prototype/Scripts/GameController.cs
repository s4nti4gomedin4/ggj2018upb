using System;
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

    private bool m_Playing;
    private bool m_MenuStart;

    private void OnEnable()
    {
        Impact.onHitBoxAction += OnHitBoxActionHandler;
        Orgam.onOrgamDestroy += OnOrgamDestroyHandler;
        Player.onPlayerDead += OnPlayerDead;
        MainMenu.OnGameStart += OnGameStartHandler;
    }

    private void OnGameStartHandler(){
        m_MenuStart = true;
        OnPlay();
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
        m_MenuStart = false;

        m_Splash.SetActive(false);
        m_MainMenu.SetActive(true);
    }

    private void Update()
    {
        if(Input.anyKeyDown && !m_Playing && m_MenuStart){
            OnPlay();
        }
    }

    private void OnOrgamDestroyHandler()
    {
        m_Playing = false;
        m_Splash.SetActive(true);
        m_PlayerPrefab.gameObject.SetActive(false);
        m_Message.text = "Win!!";
        m_EnemySpawn.DestroyChilds();
        StartCoroutine(m_EnemySpawn.DestroyChilds());
    }

    private void OnPlayerDead()
    {
        m_Playing = false;
        m_PlayerPrefab.gameObject.SetActive(false);
        m_Splash.SetActive(true);
        m_Message.text = "Lose!!";
        StartCoroutine(m_EnemySpawn.DestroyChilds());
    }

    public void OnPlay()
    {
        m_Playing = true;
        m_MainMenu.SetActive(false);
        m_Splash.SetActive(false);
        m_EnemySpawn.OnSpawnEnemies();
        var position = m_PlayerPosition.position;
        position.y = m_PlayerPrefab.transform.position.y;
        m_PlayerPrefab.transform.position = position;
        m_PlayerPrefab.gameObject.SetActive(true);
        m_PlayerPrefab.ResetPlayer();
    }

    private void OnHitBoxActionHandler(HitBox winner, HitBox losse)
    {
       
        winner.m_Level++;
        losse.m_Level--;
    }
}
