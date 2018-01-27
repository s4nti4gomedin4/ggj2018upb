using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTransmit : MonoBehaviour {
	public GameObject m_AimZone;
	public GameObject m_AimReticle;

	private Vector3 mousePositionOnAim;
	private const float maxRange=0.48f;
	private const float minRange=-1*maxRange;
	private const float initialZ=0.13f;

	private float mouseOldPositionX=0;
	private float mouseOldPositionY=0;

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
		if (isActive) {

			var moveX = Mathf.Clamp(Input.GetAxis ("Move X"),-1,1);
			var moveY = Mathf.Clamp(Input.GetAxis ("Move Y"),-1,1);

			var valueX = GetLerpedValue (moveX);
			var valueZ = GetLerpedValue (moveY);

			var currentPos = m_AimReticle.transform.localPosition;

			currentPos.x = Mathf.Clamp(currentPos.x+valueX,minRange,maxRange) ;
			currentPos.z = Mathf.Clamp(currentPos.z+valueZ,minRange,maxRange) ;

			//m_AimReticle.transform.localPosition = currentPos;

				
		}

	}
	private float GetLerpedValue(float value){

		var direction = Mathf.Sign(value);
		var finalpos = Mathf.Lerp (minRange, maxRange, Mathf.Abs (value));
		return finalpos*direction;
			
	}
	private void DrawAimZone(bool activate){
		m_AimZone.SetActive (activate);
	}


}
