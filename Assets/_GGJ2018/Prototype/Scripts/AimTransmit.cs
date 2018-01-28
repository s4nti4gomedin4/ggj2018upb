using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTransmit : MonoBehaviour {
	public float m_ReticleSpeed=0.01f;

	public GameObject m_AimZone;
	public GameObject m_AimReticle;
	private float lastPosX =  0;
	private float lastPosY =  0;

	private float maxRange{
		get{
			return CalculateMaxRange();
		}
	}

	public bool isActive;
	// Use this for initialization
	void Start () {
		m_AimReticle.SetActive (true);
	}

	void OnDisable (){
		isActive = false;
	}
	// Update is called once per frame
	void Update () {

	
		var moveX = Input.GetAxis ("Move X");
		var moveY = Input.GetAxis ("Move Y");
		var deltaMouseX = moveX - lastPosX;
		var deltaMouseY = moveY - lastPosY;
		if (deltaMouseX != 0f || deltaMouseY!=0f) {
			m_AimReticle.transform.position = m_AimReticle.transform.position + new Vector3 (deltaMouseX,0,deltaMouseY);
		}
		var distance = m_AimReticle.transform.position - transform.position;
		if (distance.magnitude > maxRange) {
			distance=distance.normalized*maxRange;
			m_AimReticle.transform.position = transform.position + distance;
		}

	}
	private float GetMovementValue(float value){
		var direction = Mathf.Sign(value);
		return m_ReticleSpeed*direction*Time.deltaTime;
	}
	private void DrawAimZone(bool activate){
		m_AimZone.SetActive (activate);
		Cursor.visible = !activate;
	}
	private float CalculateMaxRange(){
		return m_AimZone.transform.lossyScale.x / 2;
	}
}
