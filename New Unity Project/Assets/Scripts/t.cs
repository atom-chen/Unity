using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour {

    public AnimationCurve animCurve;
    float outputY;

	// Use this for initialization
	void Start () {
        outputY = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            outputY = animCurve.Evaluate(Time.deltaTime) * 2f;
            transform.position = new Vector3(transform.position.x + 2f, outputY, transform.position.z);
        }
	}
}
