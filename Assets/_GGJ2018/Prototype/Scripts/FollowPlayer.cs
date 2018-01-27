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
        print(other.name);
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("enemy"))
        {
            var m_Player = other.gameObject.GetComponent<Player>();

            if(m_Player!=null ){
                if(!m_Infectable.isInfected && m_Player.m_Level<m_Infectable.m_Level){
                    if (onPlayerDetected != null)
                    {
                        onPlayerDetected(other.gameObject.transform.position);
                    }
                }
            }else{
                var m_Enemy = other.gameObject.GetComponent<Infectable>();
                if(m_Enemy!=null){
                    if(m_Enemy.isInfected!=m_Infectable.isInfected){
                        if (m_Enemy.m_Level < m_Infectable.m_Level)
                        {
                            if (onPlayerDetected != null)
                            {
                                onPlayerDetected(other.gameObject.transform.position);
                            }
                        }
                    }
                }

            }
        } 
    }
    public void OnTriggerExit(Collider other)
    {
        print(other.name);
        if (other.gameObject.CompareTag("Player")|| other.gameObject.CompareTag("enemy"))
        {
           
            var m_Player = other.gameObject.GetComponent<Player>();

            if (m_Player != null )
            {
                if (!m_Infectable.isInfected && m_Player.m_Level < m_Infectable.m_Level)
                {
                    if (onPlayerLost != null)
                    {
                        onPlayerLost(other.gameObject.transform.position);
                    }
                }
            }else{
                var m_Enemy = other.gameObject.GetComponent<Infectable>();
                if (m_Enemy != null)
                {
                    if (m_Enemy.isInfected != m_Infectable.isInfected)
                    {
                        if (m_Enemy.m_Level < m_Infectable.m_Level)
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
    }

}
