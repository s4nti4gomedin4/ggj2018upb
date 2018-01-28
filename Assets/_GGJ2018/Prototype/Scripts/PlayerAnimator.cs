using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public HitBox m_Hitbox;
    public Animator m_Animator;

	// Use this for initialization
	void Start () {
        m_Hitbox.onLevelUp += OnLevelChangeHandle;
        Player.onPlayerDead += OnPlayerDead;
        Player.onPlayerStart += OnPlayerStart;
	}
	
	// Update is called once per frame
    void OnLevelChangeHandle () {
        if(m_Animator!=null && m_Animator.isActiveAndEnabled){
            m_Animator.SetTrigger("attack");
        }
	}
    void OnPlayerDead(){
        if (m_Animator != null && m_Animator.isActiveAndEnabled)
        {
            m_Animator.SetTrigger("dead");
        }
    }

    void OnPlayerStart()
    {
        if (m_Animator != null && m_Animator.isActiveAndEnabled)
        {
            m_Animator.SetTrigger("rezz");
        }
    }
}
