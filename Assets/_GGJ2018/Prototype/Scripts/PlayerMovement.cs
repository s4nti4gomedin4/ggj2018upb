using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   

    public float speed;
    public Vector2 speedLimit;
    public float tilt;
    private Rigidbody m_rb;
    public HitBox m_Hitbox;
    public Transform m_player;
	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
        m_Hitbox.onLevelChange += OnLevelChange;
	}

    private void OnLevelChange()
    {
        speed = Mathf.Lerp(speedLimit.x, speedLimit.y, (float)m_Hitbox.m_Level / (float)HitBox.MaxLevel);

    }

    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        //m_rb.velocity = movement * speed;
        //m_rb.velocity = Vector3.zero;
        m_rb.transform.position = m_rb.transform.position + (movement*speed);
        if(movement != Vector3.zero)
        m_player.rotation = Quaternion.LookRotation(movement);
    }
}
