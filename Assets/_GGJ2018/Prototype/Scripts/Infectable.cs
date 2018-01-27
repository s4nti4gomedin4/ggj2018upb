using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {
    public delegate void InfectableEvent(GameObject _Infectable, GameObject _infector);
    public static event InfectableEvent onInfectableAbsorved;
    public float sizeOverLevel;
    public int startLevel=1;
    public int m_Level { 
        get { return _m_Level; }
        set { _m_Level = value;
            OnLevelChange();
            }
    }

    public bool isInfected;

    public float m_TimetoInfected=1;
    
    private int _m_Level;
    public MeshRenderer m_Mesh;
    public Material m_InfectedMaterial;
    public Material m_NormalMaterial;
   

    [SerializeField]
    private float m_TimeEating;

    [SerializeField]
    private float m_timeToEat;
 
	public void Start(){
        ResetInfectable();
		
	}
    public void ResetInfectable(){
        m_Level = startLevel;
        if(isInfected){
            m_Mesh.material = m_InfectedMaterial;
        }else{
            m_Mesh.material = m_NormalMaterial;
        }

    }
	private void OnLevelChange(){
    
        var scale = transform.localScale;
        scale.x = 1+(m_Level * sizeOverLevel);
        scale.z = 1+(m_Level * sizeOverLevel);
        transform.localScale = scale;
    }

    public void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("enemy"))
        {
            var m_player = other.GetComponent<Player>();
            if (m_player != null)
            {
                if (m_player.m_Level >= m_Level && !isInfected)
                {
                    m_TimeEating += Time.deltaTime;
                    if (m_TimeEating > m_timeToEat)
                    {

                        m_Level--;
                        m_TimeEating = 0;
                        if (onInfectableAbsorved != null)
                        {
                            onInfectableAbsorved(this.gameObject, other.gameObject);
                        }
                        if (m_Level == 0)
                        {
                            StartCoroutine(OnInfetcted());
                        }
                    }
                }
            }
            else
            {
                var m_Enemy = other.GetComponent<Infectable>();
                if (m_Enemy.isInfected != isInfected) { 
                    m_TimeEating += Time.deltaTime;
                    if (m_TimeEating > m_timeToEat)
                    {

                        m_Level--;
                        m_TimeEating = 0;
                        if (onInfectableAbsorved != null)
                        {
                            onInfectableAbsorved(this.gameObject, other.gameObject);
                        }
                        if (m_Level == 0)
                        {
                            StartCoroutine(OnInfetcted());
                        }
                    }
                }
                
            }
        }
    }

    public IEnumerator OnInfetcted(){
        yield return null;
        transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
        yield return new WaitForSeconds(m_TimetoInfected);
        isInfected = !isInfected;
        ResetInfectable();
    }
}
