using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public delegate void  FollowPlayerEvent(Vector3 position);
    public event FollowPlayerEvent onTargetDetected;
    public event FollowPlayerEvent onTargetLost;

    public HitBox mHitBox;

    public void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("hitbox") )
        {
            var m_OtherHitbox = other.gameObject.GetComponent<HitBox>();

            if(m_OtherHitbox!=null ){
                if(mHitBox.isInfected != m_OtherHitbox.isInfected){
                    if (m_OtherHitbox.m_Level < mHitBox.m_Level)
                    {
                        if (onTargetDetected != null)
                        {
                            onTargetDetected(m_OtherHitbox.gameObject.transform.position);
                        }
                    }
                }

            }
        } 
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("hitbox") )
        {
            var m_OtherHitbox = other.gameObject.GetComponent<HitBox>();

            if(m_OtherHitbox!=null ){
                if(mHitBox.isInfected != m_OtherHitbox.isInfected){
                    if (m_OtherHitbox.m_Level < mHitBox.m_Level)
                    {
                        if (onTargetLost != null)
                        {
                            onTargetLost(m_OtherHitbox.gameObject.transform.position);
                        }
                    }
                }

            }
        } 
    }

}
