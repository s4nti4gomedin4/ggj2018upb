using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTransmit : MonoBehaviour {


	private bool isPositionValid=true;
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


			if (isPositionValid) {
				playerTransmit.transform.position=this.transform.position;
				playerTransmit.SetActive (true);
				
			}

		}
	}
	void OnTriggerStay(Collider other)
	{
		print("Stay");

	}

	void OnTriggerEnter(Collider target) {
		print("NOPE");
	}

	void OnTriggerExit(Collider other)
	{
		print ("YEP");
	}

}
