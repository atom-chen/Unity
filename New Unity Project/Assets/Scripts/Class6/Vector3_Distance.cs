using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Distance : MonoBehaviour {

    /*
     * distance 距离
     *  用于计算 两个坐标点 的距离
     *      Vector3.Distance(a,b) 等同于(a-b).magnitude
     */

    Vector3 v1;
    Vector3 v2;

    float distance;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        v1 = transform.position;
        v2 = new Vector3(1, 0, 0);

        /*
         * Vector3.Distance(a,b) 等同于(a-b).magnitude
         */
        distance = Vector3.Distance(v1, v2);
        Debug.Log(distance);

        distance = (v1 - v2).magnitude;
        Debug.Log(distance);

        distance = Vector3.Dot(v1, v2);
        Debug.Log(distance);
	}
}
