using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Transform[] m_PositionSpawn;
    public GameObject m_EnemyPrefab;
    public Transform m_EnemyPanelSpawn;
    public int enemyCount;

	// Use this for initialization
	void Start () {
        if(m_PositionSpawn!=null){
            for (int i = 0; i < enemyCount; i++)
            {
                var newEnemy=SpawnEnemy(m_EnemyPrefab, m_PositionSpawn[Random.Range(0, m_PositionSpawn.Length)]);
                int randomIntex = Random.Range(0, m_PositionSpawn.Length);
                int randomIntex2 = randomIntex+1;
                if(randomIntex2>=m_PositionSpawn.Length){
                    randomIntex2 = 0;
                }
                Transform[] mPositions = new Transform[] { m_PositionSpawn[randomIntex],m_PositionSpawn[randomIntex2]};
                newEnemy.patrolPos = mPositions;
            }
        }
	}

    private EnemyManager SpawnEnemy(GameObject enemyPrefab, Transform positionTransform)
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.SetParent(m_EnemyPanelSpawn);
        newEnemy.gameObject.SetActive(true);
        newEnemy.transform.position = positionTransform.position;
        return newEnemy.GetComponentInChildren<EnemyManager>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
