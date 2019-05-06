using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_RotateTowards : MonoBehaviour {

    /*
     * RotateTowards (current : Vector3, target : Vector3, maxRadiansDelta : float, maxMagnitudeDelta : float)
     *  maxRadiansDelta 当前场景物体 与 目标场景物体 向量方向重叠 的移动速度（匀速移动）
     *  maxMagnitudeDelta 当前场景物体 移动到 目标场景物体 位置 的移动速度（匀速移动）
     */
    public Transform target;
    public float speed = 1f;    //当前场景物体 与 目标场景物体 向量方向重叠 的移动速度（匀速移动）
    public float mag = 0.01f;   //当前场景物体 移动到 目标场景物体 位置 的移动速度（匀速移动）

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(Vector3.zero, transform.position, Color.blue);
        transform.position = Vector3.RotateTowards(transform.position, target.position, Time.deltaTime * speed, mag);
        //                                          当前 场景物体位置   目标 场景物体位置   
	}
}
