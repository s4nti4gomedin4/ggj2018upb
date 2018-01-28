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
            SetMaterial(m_base);
            m_mesh.material = m_base;
            if (hit.collider.gameObject.CompareTag("wall"))
			{
                m_mesh = hit.collider.gameObject.GetComponent<MeshRenderer>();
                SetMaterial(m_transparent);
			} 
		}
		
	}
    private void SetMaterial(Material newMaterial){
        if(m_mesh!=null){
            m_mesh.material = newMaterial;
        }
    }
}
