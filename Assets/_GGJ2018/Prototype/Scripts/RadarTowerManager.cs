using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarTowerManager : MonoBehaviour {

	public GameObject[] allies;
	public Vector3 lastTargetPos;

	public float rotationSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,1*rotationSpeed,0);
	}

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.CompareTag ("Player")) {
			//raycast
			RaycastHit hit;
			Vector3 direction = col.gameObject.transform.position - transform.position;
			if (Physics.Raycast (transform.position, direction, out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					lastTargetPos = col.gameObject.transform.position;
					for (int i = 0; i < allies.Length; i++) {
						allies [i].GetComponent<EnemyManager> ().lastTargetPos = lastTargetPos;
						allies [i].GetComponent<EnemyManager> ()._m_ActualEnemyAction = EnemyManager.enemyAction.follow;
						allies [i].GetComponent<EnemyManager> ().StateChange ();
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		for (int i = 0; i < allies.Length; i++) {
			if (allies [i].GetComponent<EnemyManager> ()._m_ActualEnemyAction == EnemyManager.enemyAction.follow) {
				allies [i].GetComponent<EnemyManager> ().lastTargetPos = lastTargetPos;
				allies [i].GetComponent<EnemyManager> ()._m_ActualEnemyAction = EnemyManager.enemyAction.targetLost;
				allies [i].GetComponent<EnemyManager> ().StateChange ();
			}
		}
	}
}
