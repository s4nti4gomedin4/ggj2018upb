using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : MonoBehaviour {

    public Text m_Message;
    public Animator m_Animator;
    public float m_TimeMessage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void ShowMessage (string message) {
        CancelInvoke("HideMessag");
        m_Message.text = message;
        m_Animator.SetTrigger("show");
        Invoke("HideMessag",m_TimeMessage);
	}
    public void HideMessag(){
        m_Animator.SetTrigger("hide");
    }


}
