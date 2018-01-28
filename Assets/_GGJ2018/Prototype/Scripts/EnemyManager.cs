
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

	public NavMeshAgent navAgent;
    public GameObject targetLostText;
	public GameObject targetDetectedText;
	bool canTargetLost = true;

	//Transform target;
	public Vector3 m_TargetPosition;


	Vector3 lastPatrolPos;
 	Vector3 actualPatrolPos;

    [Header("Patroll config")]
    public float m_PositionToChangePatroll = 1;
    public FollowPlayer m_FollowPlayer;


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
    public enemyAction _m_ActualEnemyAction;
	private enemyAction m_ActualEnemyAction{
		get{return _m_ActualEnemyAction; }
		set{_m_ActualEnemyAction = value; StateChange (); }
	}


	public enemyType actualEnemyType;

	

	public Transform[] patrolPos;

	// Use this for initialization
	void Start () {
		lastPatrolPos = transform.position;
        m_FollowPlayer.onTargetDetected += OnTargetDetectedHandler;
        m_FollowPlayer.onTargetLost += OnTargeLostHandler;
        m_ActualEnemyAction = enemyAction.patrol;
	}
    void Update()
    {
        if (m_ActualEnemyAction == enemyAction.patrol)
        {
            var distance = Vector3.Distance(actualPatrolPos, transform.position);
            if (distance < m_PositionToChangePatroll)
            {
                Patroling();
            }
        }

    }
    private void OnTargeLostHandler(Vector3 position)
    {
        if ( m_ActualEnemyAction == enemyAction.follow)
        {
            m_TargetPosition = position;
            m_ActualEnemyAction = enemyAction.targetLost;
        }
    }


    private void OnTargetDetectedHandler(Vector3 position)
    {
        if (m_ActualEnemyAction == enemyAction.patrol || m_ActualEnemyAction == enemyAction.follow)
        {
            m_TargetPosition = position;
            m_ActualEnemyAction = enemyAction.follow;
        }
    }


	// Update is called once per frame
	public void StateChange () 
	{
		if (actualEnemyType == enemyType.melee || actualEnemyType == enemyType.range) {
			if (m_ActualEnemyAction == enemyAction.stand) {
				//nothing or something
				navAgent.SetDestination(m_TargetPosition);
			} else if (m_ActualEnemyAction == enemyAction.patrol) {
				//patrol
				Patroling();
			}else if (m_ActualEnemyAction == enemyAction.follow) {
				// follow target
                DetectedTarget();
				CancelInvoke("WaitForPatrol");
				navAgent.SetDestination(m_TargetPosition);
			}else if(m_ActualEnemyAction == enemyAction.targetLost){
                // target Lost
                MissingTarget();
				//Invoke("MissingTarget",1);
				CancelInvoke("WaitForPatrol");
				navAgent.SetDestination(m_TargetPosition);
				Invoke ("WaitForPatrol", 4);
			}else if (m_ActualEnemyAction == enemyAction.attack) {
                // attack target
                print("Attack");
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
        if(col.gameObject.CompareTag("PatrolPos"))
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
        targetLostText.SetActive(false);
        targetDetectedText.SetActive(false);
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
			Invoke ("WaitForCanTargetLost", 2);
		}
        targetLostText.SetActive(true);
        targetDetectedText.SetActive(false);
	}
    void DetectedTarget()
    {
        targetLostText.SetActive(false);
        targetDetectedText.SetActive(true);
    }

	void WaitForCanTargetLost()
	{
		canTargetLost = true;
	}
}