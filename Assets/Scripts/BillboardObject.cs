using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//http://wiki.unity3d.com/index.php/CameraFacingBillboard
public class BillboardObject : MonoBehaviour {
	//public Camera m_Camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Orient the camera after all movement is completed this frame to avoid jittering
	void LateUpdate()
	{
		//Debug.Log(Camera.main.name);
		//transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
		//	m_Camera.transform.rotation * Vector3.up);
		if(Camera.main != null)
		{
			transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
				Camera.main.transform.rotation * Vector3.up);
		}
		else Debug.Log("GAG");
		//transform.LookAt(transform.position - Camera.main.transform.position, Vector3.up);
	}
}
