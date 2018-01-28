using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orgam : MonoBehaviour {

    public static Action onOrgamDestroy;
    public Tips m_tips;
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("hitbox")){
            var m_otherHitbox = other.GetComponent<HitBox>();
            if(m_otherHitbox!=null && m_otherHitbox.isInfected){
                if(m_otherHitbox.m_Level == HitBox.MaxLevel){
                    DestroyOrgam();
                }else{
                    m_tips.ShowMessage("Need level 14 to destroy organ.");
                }
            }
        }
    }

    private void DestroyOrgam()
    {
        if(onOrgamDestroy!=null){
            onOrgamDestroy();
        }
    }
}
