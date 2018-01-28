using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransmit : MonoBehaviour {


	private bool isOutSide=true;
	private bool isInSide=false;

	public bool isTransmiting;
	public GameObject playerTransmit;
	public GameObject transmitAim;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		if (!GameController.m_Playing)
			return;
		isTransmiting = playerTransmit.activeInHierarchy;

		transmitAim.SetActive (!isTransmiting);
		if (isTransmiting)
			return;
		var fire = Input.GetAxis ("Fire1");
		if (fire==1) {
			isTransmiting = !isTransmiting;

				playerTransmit.transform.position=this.transform.position;
				playerTransmit.SetActive (true);	

		}
	}

	private bool IsPositionValid(){
		RaycastHit hit;
		var  validate=Physics.Raycast (this.transform.position, transform.up, 40f);

		return validate ;
	}

}
