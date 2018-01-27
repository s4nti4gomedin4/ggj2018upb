using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

	private NavMeshAgent navAgent;
	public GameObject targetLostText;
	bool canTargetLost = true;
	//Transform target;
	Vector3 lastTargetPos;


	Vector3 lastPatrolPos;
 	Vector3 actualPatrolPos;

    [Header("Patroll config")]
    public float m_PositionToChangePatroll = 1;


	public enum enemyAction
	{
		stand,
		patrol,
		follow,
		targetLost,
		attack,
		search,
		detect
	};

		
	public enum enemyType
	{
		melee,
		range,
		radar
	};

	private enemyAction m_ActualEnemyAction{
		get{return _m_ActualEnemyAction; }
		set{_m_ActualEnemyAction = value; StateChange (); }
	}


	public enemyType actualEnemyType;

	public enemyAction _m_ActualEnemyAction;

	public Transform[] patrolPos;

	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();
		lastPatrolPos = transform.position;
        StateChange();
	}
	void Update(){
        if(m_ActualEnemyAction == enemyAction.patrol){
            var distance = Vector3.Distance(actualPatrolPos, transform.position);
            if(distance<m_PositionToChangePatroll){
                Patroling();
            }
        }

	}
	// Update is called once per frame
	void StateChange () 
	{
		if (actualEnemyType == enemyType.melee || actualEnemyType == enemyType.range) {
			if (m_ActualEnemyAction == enemyAction.stand) {
				//nothing or something
				//navAgent.SetDestination(navAgent.transform.position);
				navAgent.SetDestination(lastTargetPos);
			} else if (m_ActualEnemyAction == enemyAction.patrol) {
				//patrol
				Patroling();
			}else if (m_ActualEnemyAction == enemyAction.follow) {
				// follow target
				CancelInvoke("WaitForPatrol");
				navAgent.SetDestination(lastTargetPos);
			}else if(m_ActualEnemyAction == enemyAction.targetLost){
				// target Lost
				Invoke("MissingTarget",1);
				CancelInvoke("WaitForPatrol");
				navAgent.SetDestination(lastTargetPos);
				Invoke ("WaitForPatrol", 4);
			}else if (m_ActualEnemyAction == enemyAction.attack) {
				// attack target
			}
		}else if(actualEnemyType == enemyType.radar)
		{
			if (m_ActualEnemyAction == enemyAction.search) {
				//search target
			} else if (m_ActualEnemyAction == enemyAction.detect) {
				//detected target
			}
		}
	}

	void OnTriggerStay(Collider col)
	{
        print("OnTriggerStay "+col.name);
		if (col.gameObject.CompareTag ("Player")) {
			//raycast
			RaycastHit hit;
			Vector3 fromPos = transform.position;
			Vector3 toPos = col.gameObject.transform.position;
			Vector3 direction = toPos - fromPos;
			if (Physics.Raycast (transform.position, direction, out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					lastTargetPos = col.gameObject.transform.position;	
					m_ActualEnemyAction = enemyAction.follow;
				}
			}
		}else if(col.gameObject.CompareTag("PatrolPos"))
		{
			Vector3 _mypos = transform.position;
			float _distance = Vector3.Distance(actualPatrolPos,_mypos);
            print("Iam on patrol point " + _distance);

			if (_distance <= 1) {
				lastPatrolPos = actualPatrolPos;
				Patroling ();
			}

		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag("Player")) {
			m_ActualEnemyAction = enemyAction.targetLost;
		}
	}

	void WaitForPatrol()
	{
		m_ActualEnemyAction = enemyAction.patrol;
	}

	void Patroling()
	{
		int r = Random.Range(0,patrolPos.Length);
		actualPatrolPos = patrolPos [r].position;
		if (lastPatrolPos != actualPatrolPos) {
			navAgent.SetDestination (actualPatrolPos);
		} else {
			Invoke ("Patroling", 0);
		}
	}

	void MissingTarget()
	{
		if (canTargetLost) {
			canTargetLost = false;
			GameObject tlt = Instantiate (targetLostText, gameObject.transform.position, Quaternion.identity) as GameObject;
			tlt.transform.SetParent (this.gameObject.transform);
			Invoke ("WaitForCanTargetLost", 2);
		}
	}

	void WaitForCanTargetLost()
	{
		canTargetLost = true;
	}
}