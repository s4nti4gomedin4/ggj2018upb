using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float tilt;
    private Rigidbody m_rb;
	// Use this for initialization
	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}


    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        m_rb.velocity = movement * speed;
    }
}
