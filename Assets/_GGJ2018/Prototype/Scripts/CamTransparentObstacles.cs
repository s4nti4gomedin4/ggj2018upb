using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTransparentObstacles : MonoBehaviour {
	public MeshRenderer m_mesh;
	public Material m_base;
	public Material m_transparent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			if (hit.collider.gameObject.name == "Enclosure01")
			{
				m_mesh.material = m_transparent;
			} else {
				m_mesh.material = m_base;
			}
		}
		
	}
}
