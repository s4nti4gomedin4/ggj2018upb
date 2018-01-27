using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

	private NavMeshAgent navAgent;
	public Transform target;
	public Transform lastTargetPos;

	public enum enemyAction
	{
		stand,
		patrol,
		follow,
		attack,
	};
		
	public enum enemyType
	{
		type1,
		type2,
		type3
	};

	private enemyAction m_ActualEnemyAction{
		get{return _m_ActualEnemyAction; }
		set{_m_ActualEnemyAction = value; StateChange (); }
	}
	public enemyAction _m_ActualEnemyAction;

	public enemyType actualEnemyType;



	// Use this for initialization
	void Start () {
		navAgent = GetComponent<NavMeshAgent> ();


	}
	void Update(){

	}
	// Update is called once per frame
	void StateChange () 
	{
		if (actualEnemyType == enemyType.type1) {
			if (m_ActualEnemyAction == enemyAction.stand) {
				//nothing or something
				navAgent.SetDestination(navAgent.transform.position);
			} else if (m_ActualEnemyAction == enemyAction.patrol) {
				//patrol
			}else if (m_ActualEnemyAction == enemyAction.follow) {
				// follow target
				navAgent.SetDestination (target.position);
			}else if (m_ActualEnemyAction == enemyAction.attack) {
				// attack target
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player")) {
			m_ActualEnemyAction = enemyAction.follow;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.CompareTag("Player")) {
			m_ActualEnemyAction = enemyAction.stand;
		}
	}
}
