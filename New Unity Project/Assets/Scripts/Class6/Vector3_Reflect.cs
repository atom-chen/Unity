using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3_Reflect : MonoBehaviour {

    /*
     * Reflect (inDirection : Vector3, inNormal : Vector3)
     *  沿着法线反射向量
     *      镜面反射
     */
    public Transform target;
    public Vector3 rail;            //镜面反射的 法线（中心线）

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 heading = transform.position - target.position;
        Vector3 reflect = Vector3.Reflect(heading, rail);

        Debug.DrawLine(transform.position, target.position, Color.green);
        Debug.DrawLine(transform.position, reflect, Color.red);
	}
}
