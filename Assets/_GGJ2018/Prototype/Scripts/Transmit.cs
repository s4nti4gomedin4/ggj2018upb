using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmit : MonoBehaviour {

	public Player playerObject;
	public float timeTick;
	private int MaxLevel;
	private float time;
	public float sizeOverLevel;

	public int m_Level { 
		get { return _m_Level; }
		set { _m_Level = value;
			OnLevelChange();
		}
	}
	private int _m_Level = 1;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable(){
		playerObject.GetComponent<AimTransmit> ().m_AimZone.SetActive(false);
		MaxLevel = playerObject.m_Level;
		m_Level = 1;
		time = 0;

	}

	// Update is called once per frame
	void Update () {
		print ("max lvl "+MaxLevel);
		time += Time.deltaTime;
		if (time > timeTick) {
			time = 0;
			if (MaxLevel == 1) {
				TransmitPlayer ();
				return;
			}


			m_Level++;
			playerObject.m_Level--;
			if(m_Level==MaxLevel)
			TransmitPlayer ();
		}
	}
	private void TransmitPlayer(){
		playerObject.transform.position = this.transform.position;
		playerObject.m_Level = MaxLevel;
		this.gameObject.SetActive (false);
		print ("player lvl "+playerObject.m_Level);

	}

	private void OnLevelChange()
	{
		var scale = transform.localScale;
		scale.x = 1+(m_Level * sizeOverLevel);
		scale.z = 1+(m_Level * sizeOverLevel);
		transform.localScale = scale;
	}
}
