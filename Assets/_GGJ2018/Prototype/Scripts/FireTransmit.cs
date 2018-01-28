using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransmit : MonoBehaviour {


	private bool isOutSide=true;
	private bool isInSide=false;

	public bool isTransmiting;
	public GameObject playerTransmit;
	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		if (!GameController.m_Playing)
			return;
		isTransmiting = playerTransmit.activeInHierarchy;
		if (isTransmiting)
			return;
		var fire = Input.GetAxis ("Fire1");
		if (fire==1) {
			isTransmiting = !isTransmiting;
			if (IsPositionValid()) {
				playerTransmit.transform.position=this.transform.position;
				playerTransmit.SetActive (true);	
			}
		}
	}

	private bool IsPositionValid(){
		return !Physics.Raycast (new Vector3(this.transform.position.x,400,this.transform.position.z),this.transform.position);
	}

}
