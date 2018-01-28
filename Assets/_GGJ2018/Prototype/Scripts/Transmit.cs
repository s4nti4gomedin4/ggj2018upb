using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit : MonoBehaviour {

	public Player playerObject;
	public float timeTick;
	private int MaxLevel;
	private float time;
	public float sizeOverLevel;
    private int m_Level;
   

	void OnEnable(){
        MaxLevel = playerObject.m_hitBox.m_Level;
        m_Level = Player.MinPlayerLevel;
		time = 0;
        StartCoroutine(CR_TransmitPlayer());

    }

    
    private IEnumerator CR_TransmitPlayer(){
        yield return new WaitForSeconds(timeTick);
        while(playerObject.m_hitBox.m_Level>Player.MinPlayerLevel){
            m_Level++;
            OnLevelChange();

            playerObject.m_hitBox.m_Level--;
            yield return new WaitForSeconds(timeTick);
        }
        TransmitPlayer();
    }


	private void TransmitPlayer(){
		playerObject.transform.position = this.transform.position;
        playerObject.m_hitBox.m_Level = MaxLevel;
		this.gameObject.SetActive (false);
	}

	private void OnLevelChange()
	{
		var scale = transform.localScale;
        scale.x = 1+(m_Level * sizeOverLevel);
        scale.z = 1+(m_Level * sizeOverLevel);
        if (scale.x < 0.1f)
        {
            scale.x = 0.1f;
        }
        if (scale.y < 0.1f)
        {
            scale.y = 0.1f;
        }
		transform.localScale = scale;
	}
}
