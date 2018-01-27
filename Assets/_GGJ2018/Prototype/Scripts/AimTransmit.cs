using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTransmit : MonoBehaviour {
	public GameObject m_AimZone;
	private bool isActive;
	// Use this for initialization
	void Start () {
		DrawAimZone (isActive);
	}
	
	// Update is called once per frame
	void Update () {
		var transmit=Input.GetButtonDown("Jump");
		if (transmit) {
			isActive = !isActive;
			DrawAimZone (isActive);
		}



	}

	private void DrawAimZone(bool activate){
		m_AimZone.SetActive (activate);
	}
}
