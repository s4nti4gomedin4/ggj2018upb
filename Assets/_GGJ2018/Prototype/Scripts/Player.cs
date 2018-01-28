using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Action<int> onPlayerLevelChange;
    public static Action onPlayerDead;
    public static Action onPlayerStart;

    public int startLevel;
    public Text m_TextLeve;
    public HitBox m_hitBox;
  
    public const int MinPlayerLevel = 2;
    public float sizeOverLevel;

	
    public void ResetPlayer () {
        m_hitBox.isInfected = true;
        m_hitBox.onLevelChange -= OnLevelChange;
        m_hitBox.onLevelChange += OnLevelChange;
        m_hitBox.m_Level = startLevel;
        if(onPlayerStart!=null){
            onPlayerStart();
        }
	}
	
    private void OnLevelChange()
    {
        if(m_hitBox.m_Level<MinPlayerLevel){
            Dead();
            return;
        }


        if (m_TextLeve != null)
            m_TextLeve.text = string.Format("Level: {0:D}", m_hitBox.m_Level-1);

        var scale = transform.localScale;
        scale.x = 1+(m_hitBox.m_Level * sizeOverLevel);
        scale.y = 1 +(m_hitBox.m_Level * sizeOverLevel);
        scale.z = 1+(m_hitBox.m_Level * sizeOverLevel);
        if(scale.x<0.1f){
            scale.x = 0.1f; 
        }
        if (scale.y < 0.1f)
        {
            scale.y = 0.1f;
        }
        if (scale.z < 0.1f)
        {
            scale.z = 0.1f;
        }
        transform.localScale = scale;

        if (onPlayerLevelChange != null)
        {
            onPlayerLevelChange(m_hitBox.m_Level);
        }
    }


    private void Dead()
    {
        if(onPlayerDead!=null){
            onPlayerDead();
        }
    }
}
