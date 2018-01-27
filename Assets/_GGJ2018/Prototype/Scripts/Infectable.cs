using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {

    public float sizeOverLevel;
    public int startLevel=1;
    public int m_Level { 
        get { return _m_Level; }
        set { _m_Level = value;
            OnLevelChange();
            }
    }


    
    private int _m_Level;

    public delegate void InfectableEvent(GameObject _Infectable,GameObject _infector);
    public static event InfectableEvent onInfectableAbsorved;

    [SerializeField]
    private float m_TimeEating;

    [SerializeField]
    private float m_timeToEat;
 
	public void Start(){
		m_Level = startLevel;
	}
	private void OnLevelChange(){
    
        var scale = transform.localScale;
        scale.x = 1+(m_Level * sizeOverLevel);
        scale.z = 1+(m_Level * sizeOverLevel);
        transform.localScale = scale;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var m_player = other.GetComponent<Player>();
            if (m_player != null)
            {
                if (m_player.m_Level >= m_Level) { 
                    m_TimeEating += Time.deltaTime;
                    if (m_TimeEating > m_timeToEat)
                    {

                       m_Level--;
                       m_TimeEating=0;
						if (onInfectableAbsorved != null)
						{
							onInfectableAbsorved(this.gameObject, other.gameObject);
						}
                        if(m_Level==0){
                            
                            Destroy(this.gameObject,0.01f);
                        }
                    }
                }
            }
        }
    }
}
