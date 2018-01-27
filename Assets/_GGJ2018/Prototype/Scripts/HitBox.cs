using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    public delegate void HitBoxEvent(HitBox winner,HitBox losser);
    public static event HitBoxEvent onHitBoxAction;

    public int m_Level;
    public bool isInfected;

	

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("hitbox")){
            var otherHitBox = collision.gameObject.GetComponent<HitBox>();
            if(otherHitBox!=null){
                if(otherHitBox.isInfected!=isInfected){
                    if(otherHitBox.m_Level<m_Level){
                        if(onHitBoxAction!=null){
                            onHitBoxAction(this,otherHitBox);
                        }
                    }
                }
            }
        }
    }
}
