using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infectable : MonoBehaviour {

    public int m_Level;

    public delegate void InfectableEvent(GameObject _Infectable,GameObject _infector);
    public static event InfectableEvent onInfectableDestroy;

    [SerializeField]
    private float m_TimeEating;

    [SerializeField]
    private float m_timeToEat;

	

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var m_player = other.GetComponent<Player>();
            if (m_player != null)
            {
                if (m_player.m_Level <= m_Level) { 
                    m_TimeEating += Time.deltaTime;
                    if (m_TimeEating > m_timeToEat)
                    {

                        if (onInfectableDestroy != null)
                        {
                            onInfectableDestroy(this.gameObject, other.gameObject);
                        }
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
