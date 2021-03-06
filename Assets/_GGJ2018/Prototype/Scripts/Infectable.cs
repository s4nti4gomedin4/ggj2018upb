﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Infectable : MonoBehaviour {


    public static Action OnDeath;
    public static Action OnLevelUp;

    public float sizeOverLevel;
    public int startLevel=1;
    public HitBox m_hitBox;


    public float m_TimetoInfected=1;

	public SkinnedMeshRenderer m_Mesh;
    public Material m_InfectedMaterial;
    public Material m_NormalMaterial;
    public Material m_FeedMaterial;
    private int m_LastPlayerLevel;

	public NavMeshAgent navAgent;

    [SerializeField]
    private float m_TimeEating;

    [SerializeField]
    private float m_timeToEat;

    private void OnEnable()
    {
        Player.onPlayerLevelChange += OnPlayerLevelChange;
    }

    private void OnPlayerLevelChange(int newLevel)
    {
        m_LastPlayerLevel = newLevel;
        LoadMaterial();
    }
    private void OnDisable()
    {
        Player.onPlayerLevelChange -= OnPlayerLevelChange;

    }

    public Material GetNormalMaterial()
    {
        if (m_LastPlayerLevel > m_hitBox.m_Level)
        {
            return m_FeedMaterial;
        }
        else
        {
            return m_NormalMaterial;
        }
    }
    public void Start(){
        m_hitBox.onLevelChange += OnLevelChange;
        m_hitBox.onLevelUp += OnlevelUpHandler;
        ResetInfectable();
		
	}

    private void OnlevelUpHandler()
    {
        if(OnLevelUp!=null){
            OnLevelUp();
        }
    }

    public void ResetInfectable(){
		navAgent.enabled = true;
        m_hitBox.m_Level = startLevel;
        LoadMaterial();


    }

    private void LoadMaterial()
    {
        if (m_hitBox.isInfected)
        {
            m_Mesh.material = m_InfectedMaterial;
        }
        else
        {
            m_Mesh.material = GetNormalMaterial();
        }
    }

    private void OnLevelChange(){
    
        var scale = transform.localScale;
        scale.x = 1+(m_hitBox.m_Level * sizeOverLevel);
        scale.z = 1+(m_hitBox.m_Level * sizeOverLevel);
        if (scale.x < 0.1f)
        {
            scale.x = 0.1f;
        }
        if (scale.y < 0.1f)
        {
            scale.y = 0.1f;
        }
        transform.localScale = scale;

        StartCoroutine(ActivateHitBox());
        if(m_hitBox.m_Level==0){
            StartCoroutine(OnInfetcted());
        }
    }
    private IEnumerator ActivateHitBox(){
        m_hitBox.gameObject.SetActive(false);
        yield return new WaitForSeconds(m_timeToEat);
        m_hitBox.gameObject.SetActive(true);

    }

   
    public IEnumerator OnInfetcted(){
		navAgent.enabled = false;

        //transform.localScale = new Vector3(0.1f, 1f, 0.1f);
        //yield return new WaitForSeconds(m_TimetoInfected);
        m_hitBox.isInfected = !m_hitBox.isInfected;
		yield return new WaitForSeconds(m_TimetoInfected);
        ResetInfectable();
    }
}
