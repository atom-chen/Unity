using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_MoveTowards : MonoBehaviour {

    /*
     * MoveTowards (current : Vector3, target : Vector3, maxDistanceDelta : float)
     *  当前的地点移向目标
     *      maxDistanceDelta是 正数，当前场景物体 移向 目标
     *                          负值，当前场景物体 远离 目标
     */
    public Vector3 target;
    public float maxDistanceDelta;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float v = maxDistanceDelta;
        transform.position = Vector3.MoveTowards(transform.position, target, v);
	}
}
