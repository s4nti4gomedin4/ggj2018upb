﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Feed : MonoBehaviour {

    public System.Action onFeedDestroy;

    public HitBox m_HitBox;
    public Transform m_FollowEnemy;
    public NavMeshAgent m_Agent;
    public float TimeToFollow = 4;

	// Use this for initialization
	void Start () {
        
        m_HitBox.onLevelChange += OnLevelChange;
        m_HitBox.m_Level = 1;
        StartCoroutine(FollowEnemy());
	}
	
	
    void OnLevelChange(){
        if (m_HitBox != null)
        {
            if (m_HitBox.m_Level < 1)
            {
                if (gameObject != null)
                {
                    Destroy(gameObject, 0.01f);
                    if(onFeedDestroy!=null){
                        onFeedDestroy();
                    }
                }
            }
        }
    }

    private IEnumerator FollowEnemy(){
        if(m_FollowEnemy!=null && m_Agent!=null){
            while (true)
            {
                yield return new WaitForSeconds(TimeToFollow);
                if(this==null){
                    yield break;
                }
                if(m_Agent!=null && m_FollowEnemy!=null)
                m_Agent.SetDestination(m_FollowEnemy.position);
            }
        }

    }
}
