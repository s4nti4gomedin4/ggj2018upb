using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody m_rb;
	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}


    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var position = m_rb.position;
        position.x += horizontal * speed ;
        position.z += vertical * speed ;
        m_rb.position = position;
    }
}
