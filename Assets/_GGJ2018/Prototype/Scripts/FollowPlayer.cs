using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public delegate void  FollowPlayerEvent(Vector3 position);
    public event FollowPlayerEvent onPlayerDetected;
    public event FollowPlayerEvent onPlayerLost;

    public Infectable m_Infectable;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var m_Player = other.gameObject.GetComponent<Player>();

            if(m_Player!=null){
                if(m_Player.m_Level<m_Infectable.m_Level){
                    if (onPlayerDetected != null)
                    {
                        onPlayerDetected(other.gameObject.transform.position);
                    }
                }
            }
        } 
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           
            var m_Player = other.gameObject.GetComponent<Player>();

            if (m_Player != null)
            {
                if (m_Player.m_Level < m_Infectable.m_Level)
                {
                    if (onPlayerLost != null)
                    {
                        onPlayerLost(other.gameObject.transform.position);
                    }
                }
            }
        } 
    }

}
