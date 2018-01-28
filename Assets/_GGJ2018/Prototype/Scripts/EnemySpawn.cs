
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public Transform[] m_PositionSpawn;
    public GameObject m_EnemyPrefab;
    public Transform m_EnemyPanelSpawn;
    public int enemyCount;
    public int feedCount;

    public Feed m_FeedPrefab;

    public List<Infectable> m_Fectables;
   
    public Vector2 offset;

	// Use this for initialization
    IEnumerator StartSpawn () {
        m_Fectables = new List<Infectable>();
        yield return DestroyChilds();
        if(m_PositionSpawn!=null){
            for (int i = 0; i < enemyCount; i++)
            {
                var PositionAnemy = m_PositionSpawn[Random.Range(0, m_PositionSpawn.Length)].position;
                PositionAnemy.x += Random.Range(offset.x, offset.y);
                PositionAnemy.y += Random.Range(offset.x, offset.y);
                 var newEnemy=SpawnEnemy(m_EnemyPrefab, PositionAnemy);
                int randomIntex = Random.Range(0, m_PositionSpawn.Length);
                int randomIntex2 = randomIntex+1;
                if(randomIntex2>=m_PositionSpawn.Length){
                    randomIntex2 = 0;
                }
                Transform[] mPositions = new Transform[] { m_PositionSpawn[randomIntex],m_PositionSpawn[randomIntex2]};
                newEnemy.patrolPos = mPositions;
                var infectableNew = newEnemy.GetComponent<Infectable>();
                infectableNew.startLevel=Random.Range(5,HitBox.MaxLevel);
                m_Fectables.Add(infectableNew);
                yield return null;
            }
        }
        for (int i = 0; i < feedCount; i++)
        {
            yield return CreateNewFeed();
        }
    }

    public IEnumerator DestroyChilds()
    {
        if (m_EnemyPanelSpawn != null)
        {
            for (int i = 0; i < m_EnemyPanelSpawn.childCount; i++)
            {
                Destroy(m_EnemyPanelSpawn.GetChild(i).gameObject, 0.01f);
                yield return null;
            }
        }
    }
        

    public void OnSpawnEnemies()
    {
        StartCoroutine(StartSpawn());
    }


    private EnemyManager SpawnEnemy(GameObject enemyPrefab, Vector3 newPosition)
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.SetParent(m_EnemyPanelSpawn);
        newEnemy.gameObject.SetActive(true);
        newEnemy.transform.position = newPosition;
        return newEnemy.GetComponentInChildren<EnemyManager>();
    }

    // Update is called once per frame
    void OnFeedDestroy () {
        StartCoroutine(CreateNewFeed());
    }
    public IEnumerator CreateNewFeed(){
       
        yield return null;
        var newFeed = Instantiate(m_FeedPrefab);
        newFeed.transform.SetParent(m_EnemyPanelSpawn);
        newFeed.gameObject.SetActive(true);
        newFeed.onFeedDestroy += OnFeedDestroy;
        var newPosition = m_PositionSpawn[Random.Range(0, m_PositionSpawn.Length)].position;
        newPosition.y = m_FeedPrefab.transform.position.y;
        var PositionAnemy = m_PositionSpawn[Random.Range(0, m_PositionSpawn.Length)].position;
        PositionAnemy.x += Random.Range(offset.x, offset.y);
        PositionAnemy.y += Random.Range(offset.x, offset.y);
        newFeed.transform.position = PositionAnemy ;
        var EnemyTransform = GetEnemyPositionRandom();
        if(EnemyTransform!=null){
            newFeed.m_FollowEnemy = EnemyTransform;
        }else{
            newFeed.m_FollowEnemy = m_PositionSpawn[Random.Range(0, m_PositionSpawn.Length)];
        }

    }

    public Transform GetEnemyPositionRandom(){
        List<Transform> enemyes = new List<Transform>();
        for (int i = 0; i < m_Fectables.Count; i++)
        {
            if (!m_Fectables[i].m_hitBox.isInfected)
            {
                enemyes.Add(m_Fectables[i].transform);
            }
        }
        if (enemyes.Count > 0)
            return enemyes[Random.Range(0, enemyes.Count)];
        else
            return null;
    }
}
