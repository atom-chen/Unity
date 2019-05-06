using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Angle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnGUI()
    {
        GUILayout.TextArea("Angle：" + Vector3.Angle(transform.position, Vector3.right));
    }
}
