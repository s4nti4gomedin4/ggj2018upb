using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Action<int> onPlayerLevelChange;
    public static Action onPlayerDead;
    public static Action onPlayerWin;

    public int startLevel;
    public Text m_TextLeve;
    public HitBox m_hitBox;
  
    private int _m_Level = 1;
    public float sizeOverLevel;

	// Use this for initialization
	void Start () {
        m_hitBox.isInfected = true;
        m_hitBox.onLevelChange += OnLevelChange;
        m_hitBox.m_Level = startLevel;
	}
	
    private void OnLevelChange()
    {
        if(m_hitBox.m_Level<2){
            Dead();
            return;
        }
        if (m_hitBox.m_Level > HitBox.MaxLevel-2)
        {
            Win();
            return;
        }

        if (m_TextLeve != null)
            m_TextLeve.text = string.Format("{0:D}", m_hitBox.m_Level);

        var scale = transform.localScale;
        scale.x = 1+(m_hitBox.m_Level * sizeOverLevel);
        scale.z = 1+(m_hitBox.m_Level * sizeOverLevel);
        if(scale.x<0.1f){
            scale.x = 0.1f; 
        }
        if (scale.y < 0.1f)
        {
            scale.y = 0.1f;
        }
        transform.localScale = scale;

        if (onPlayerLevelChange != null)
        {
            onPlayerLevelChange(m_hitBox.m_Level);
        }
    }

    private void Win()
    {
        if (onPlayerWin != null)
        {
            onPlayerWin();
        }
    }

    private void Dead()
    {
        if(onPlayerDead!=null){
            onPlayerDead();
        }
    }
}
