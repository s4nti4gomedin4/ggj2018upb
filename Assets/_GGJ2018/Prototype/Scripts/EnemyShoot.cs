using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class EnemyShoot : MonoBehaviour {

	public HitBox hit;
	public Animator anim;
	bool death;
	// Use this for initialization
	void Start () {
		hit.onLevelUp += Shoot;
		hit.onLevelChange += Level;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Shoot()
	{
		anim.SetTrigger ("attack");
	}

	public void Death()
	{
		death = true;
		anim.SetTrigger ("death");
	}

	public void Level()
	{
		if (hit.m_Level == 0) {
			Death ();
		} else if(death){
			anim.SetTrigger ("Res");
		}
	}

}
