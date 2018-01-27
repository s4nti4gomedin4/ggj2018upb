using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransmit : MonoBehaviour {

	public bool isTransmiting;
	public GameObject playerTransmit;
	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		isTransmiting = playerTransmit.activeInHierarchy;
		if (isTransmiting)
			return;
		var fire = Input.GetAxis ("Fire1");
		if (fire==1) {
			isTransmiting = !isTransmiting;
			playerTransmit.transform.position= this.transform.position;
			playerTransmit.SetActive (true);

		}

			

	}
}
