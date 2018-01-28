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



	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		playerObject.GetComponent<AimTransmit> ().m_AimZone.SetActive(false);
        MaxLevel = playerObject.m_hitBox.m_Level;
        m_Level = Player.MinPlayerLevel;
		time = 0;
        Player.onPlayerLevelChange += OnPlayerLevelChangeHandler;

	}
    // 4

    private void OnPlayerLevelChangeHandler(int playerLevel)
    {
        if( playerLevel == Player.MinPlayerLevel){
            TransmitPlayer();
            return;
        }
        int maxLevelTEp = playerLevel + m_Level;
        int diffMAxLevel = maxLevelTEp-MaxLevel ;
        MaxLevel += diffMAxLevel;


    }

    private void OnDisable()
    {
        Player.onPlayerLevelChange -= OnPlayerLevelChangeHandler;

    }

    // Update is called once per frame
    void Update () {
        
		time += Time.deltaTime;
		if (time > timeTick) {
            time = 0;
           /* if (MaxLevel == Player.MinPlayerLevel)
            {
                TransmitPlayer();
                return;
            }*/

             m_Level++;
            OnLevelChange();
            if(m_Level>=MaxLevel){
                TransmitPlayer();
                return;
                
            }

             playerObject.m_hitBox.m_Level--;
            if (m_Level == MaxLevel){
                TransmitPlayer();
            }
                    

		}
	}


	private void TransmitPlayer(){
		playerObject.transform.position = this.transform.position;
        playerObject.m_hitBox.m_Level = MaxLevel;
		this.gameObject.SetActive (false);
        print ("player lvl "+playerObject.m_hitBox.m_Level);

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
