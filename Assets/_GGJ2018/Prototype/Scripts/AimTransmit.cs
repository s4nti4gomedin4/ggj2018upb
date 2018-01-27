﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTransmit : MonoBehaviour {
	public float m_ReticleSpeed=0.01f;

	public GameObject m_AimZone;
	public GameObject m_AimReticle;
	private float lastPosX =  0;
	private float lastPosY =  0;

	private Vector3 mousePositionOnAim;
	private const float maxRange=4f;
	private const float minRange=-1*maxRange;
	private const float initialZ=0.13f;

	public bool isActive;
	// Use this for initialization
	void Start () {
		DrawAimZone (isActive);
	}


	void OnDisable (){
		isActive = false;
	}
	// Update is called once per frame
	void Update () {
		var transmit=Input.GetButtonDown("Jump");
		if (transmit) {
			isActive = !isActive;
			DrawAimZone (isActive);
		}
		if (isActive) {
			
			var moveX = Input.GetAxis ("Move X");
			var moveY = Input.GetAxis ("Move Y");

			var deltaMouseX = moveX - lastPosX;
			var deltaMouseY = moveY - lastPosY;
			if (deltaMouseX != 0 || deltaMouseY!=0) {
				m_AimReticle.transform.position = m_AimReticle.transform.position + new Vector3 (deltaMouseX,0,deltaMouseY);
			}
			var distance = m_AimReticle.transform.position - transform.position;
			if (distance.magnitude > maxRange) {
				distance=distance.normalized*maxRange;
				m_AimReticle.transform.position = transform.position + distance;
			}
		}
	}
		
	private float GetMovementValue(float value){

		var direction = Mathf.Sign(value);
		return m_ReticleSpeed*direction*Time.deltaTime;
			
	}
	private void DrawAimZone(bool activate){
		m_AimZone.SetActive (activate);
	}


}
