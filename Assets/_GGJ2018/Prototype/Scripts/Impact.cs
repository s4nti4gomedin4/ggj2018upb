using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {


    public static System.Action<HitBox, HitBox> onHitBoxAction;

    public HitBox m_HitBox;

    private void OnTriggerStay(Collider other)
    {


        if (other.gameObject.CompareTag("hitbox"))
        {
            var otherHitBox = other.gameObject.GetComponent<HitBox>();
            if (otherHitBox != null)
            {
               
                if (otherHitBox.isInfected != m_HitBox.isInfected)
                {
                    
                    if (otherHitBox.m_Level < m_HitBox.m_Level)
                    {
                        
                        if (onHitBoxAction != null)
                        {
                            onHitBoxAction(m_HitBox, otherHitBox);
                        }

                    }
                }
            }
        }
    }
}
